using Proyecto1_Sistema_de_Voto.clases;
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

namespace Proyecto1_Sistema_de_Voto 
{
    public partial class ListaCandidatos : Form 
    {
        public ListaCandidatos () 
        {
            InitializeComponent();
        }

        private void ListaCandidatos_Load (object sender, EventArgs e) 
        {
            List<Candidato> listaCandidatos = ArchivosCandidatos.ReadCandidateList();
            foreach (Candidato candidato in listaCandidatos) 
            {
                if (candidato._sESTADO == "A")
                {
                    Panel panelCandidato = CrearPanelCandidato(candidato);
                    flowLayoutPanel1.Controls.Add(panelCandidato);
                }
            }
            panel1.Visible = false;
            RedondearPanel(panelContenedor, 12);
        }

        private Panel CrearPanelCandidato (Candidato candidato) 
        {
            Panel panelCandidato = new Panel 
            {
                Size = new Size(512, 88),
                BackColor = Color.FromArgb(18, 110, 130),
            };

            Label nombreCandidato = CrearLabel(candidato._sNOMBRE, new Size(120, 50), new Point(27, 13), 12, FontStyle.Bold, Color.White);
            Label lista = CrearLabel("Lista:", new Size(49, 19), new Point(374, 13), 12, FontStyle.Bold, Color.White);
            Label listaCandidato = CrearLabel(candidato._sLISTA, new Size(49, 19), new Point(429, 13), 10, FontStyle.Regular, Color.White);
            Label correoCandidato = CrearLabel(candidato._sMAIL, new Size(247, 19), new Point(231, 51), 12, FontStyle.Regular, Color.White);

            panelCandidato.Controls.AddRange(new Control [] { nombreCandidato, lista, listaCandidato, correoCandidato});
            RedondearPanel(panelCandidato, 10);

            return panelCandidato;
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
