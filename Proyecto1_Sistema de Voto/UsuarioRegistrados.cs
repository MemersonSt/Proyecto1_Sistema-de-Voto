using Proyecto1_Sistema_de_Voto.Clases;
using Proyecto1_Sistema_de_Voto.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.TextFormatting;

namespace Proyecto1_Sistema_de_Voto {
    public partial class UsuarioRegistrados : Form {
        public UsuarioRegistrados () {
            InitializeComponent();
        }

        private void UsuarioRegistrados_Load (object sender, EventArgs e) {
            List<Usuario> listaUsuarios = ArchivosUsuarios.ReadList();
            foreach (Usuario usuario in listaUsuarios) {
                Panel panelUsuario = CrearPanelCandidato(usuario);
                flowLayoutPanel1.Controls.Add(panelUsuario);
            }
            RedondearPanel(contenedorUsuarios, 12);
            panel1.Visible = false;
        }

        private Panel CrearPanelCandidato (Usuario usuario) {
            Panel panelUsuarios = new Panel {
                Size = new Size(566, 106),
                BackColor = Color.FromArgb(18, 110, 130),
            };

            Label nombreUsuario = CrearLabel(usuario._sNombres, new Size(248, 19), new Point(27, 13), 12, FontStyle.Bold, Color.White);
            Label nrCedula = CrearLabel("Nr. Cedula:", new Size(88, 19), new Point(343, 13), 12, FontStyle.Bold, Color.White);
            Label cedula = CrearLabel(usuario._sCedula, new Size(99, 19), new Point(433, 13), 10, FontStyle.Regular, Color.White);
            Label ciudad = CrearLabel("Ciudad:", new Size(66, 19), new Point(27, 65), 12, FontStyle.Bold, Color.White);
            Label provincia = CrearLabel(usuario._sProvincia, new Size(99, 19), new Point(99, 65), 12, FontStyle.Regular, Color.White);
            Label votacion; // Declaración fuera del bloque if/else

            if (usuario._bEstado == true) {
                votacion = CrearLabel("Voto Realizado", new Size(179, 19), new Point(353, 65), 12, FontStyle.Regular, Color.White);
            } else {
                votacion = CrearLabel("Voto No Realizado", new Size(179, 19), new Point(353, 65), 12, FontStyle.Regular, Color.White);
            }

            panelUsuarios.Controls.AddRange(new Control [] { nombreUsuario, nrCedula, cedula, ciudad, provincia, votacion });
            RedondearPanel(panelUsuarios, 10);

            return panelUsuarios;
        }

        private Label CrearLabel (string text, Size size, Point location, int fontSize, FontStyle fontStyle, Color foreColor) {
            return new Label {
                Size = size,
                Text = text,
                Location = location,
                Font = new Font("Cambria", fontSize, fontStyle),
                ForeColor = foreColor
            };
        }

        private void RedondearPanel (Panel panel, int radio) {
            GraphicsPath formaPanel = new GraphicsPath();
            formaPanel.AddArc(0, 0, radio, radio, 180, 90);
            formaPanel.AddArc(panel.Width - radio, 0, radio, radio, 270, 90);
            formaPanel.AddArc(panel.Width - radio, panel.Height - radio, radio, radio, 0, 90);
            formaPanel.AddArc(0, panel.Height - radio, radio, radio, 90, 90);
            formaPanel.CloseAllFigures();

            panel.Region = new Region(formaPanel);
        }

        private void btnRegresar_Click (object sender, EventArgs e) {
            this.Hide();
            MenuAdministrador regresar = new MenuAdministrador();
            regresar.ShowDialog();
            this.Close();
        }
    }
}
