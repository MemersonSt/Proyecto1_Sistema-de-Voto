using Proyecto1_Sistema_de_Voto.clases;
using Proyecto1_Sistema_de_Voto.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using Proyecto1_Sistema_de_Voto.Clases;

namespace Proyecto1_Sistema_de_Voto.VotosUsuarios {
    public partial class RegistrarVotos : Form {
        //string nombreUsuario = ArchivosUsuarios.datosUsuarioLogin._sNombres;
        //string apellidoUsuario = ArchivosUsuarios.datosUsuarioLogin._sApellidos;
        //string cedulaUsuario = ArchivosUsuarios.datosUsuarioLogin._sCedula;
        //string provinciaUsuario = ArchivosUsuarios.datosUsuarioLogin._sProvincia;
        
        public RegistrarVotos () {
            InitializeComponent();
        }

        

        private void RegistrarVotos_Load (object sender, EventArgs e) {
            List<Candidato> listaCandidatos = ArchivosCandidatos.ReadCandidateList();

            if (listaCandidatos.Count == 0) 
            {
                MessageBox.Show("No se encontraron candidatos en la lista.");
                return; // Salir si no hay candidatos
            }

            foreach (Candidato candidato in listaCandidatos) 
            {
                Panel panelCandidato = CrearPanelCandidato(candidato);
                flowLayoutPanel1.Controls.Add(panelCandidato);
            }

            RedondearPanel(panelContenedor, 12);
            panel1.Visible = false;
        }

        private Panel CrearPanelCandidato (Candidato candidato) 
        {
            Panel panelCandidato = new Panel 
            {
                Size = new Size(140, 180),
                BackColor = Color.FromArgb(18, 110, 130),
                Margin = new Padding(10, 10, 20, 10)
            };

            Label nombreCandidato = CrearLabel(candidato._sNOMBRE, new Size(120, 50), new Point(6, 7), 16, FontStyle.Bold, Color.White);
            Label lista = CrearLabel("Lista:", new Size(53, 17), new Point(8, 74), 10, FontStyle.Bold, Color.White);
            Label listaCandidato = CrearLabel(candidato._sLISTA, new Size(50, 15), new Point(58, 76), 10, FontStyle.Regular, Color.White);

            Button votar = new Button {
                Size = new Size(118, 35),
                Location = new Point(9, 125),
                BackColor = Color.FromArgb(19, 44, 51),
                ForeColor = Color.FromArgb(216, 227, 231),
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0 },
                Text = "Votar"
            };

            Font boldFont = new Font(votar.Font.FontFamily,10 , FontStyle.Bold);
            votar.Font = boldFont;

            votar.Click += (sender, e) =>
            {
                // Lógica para registrar el voto 
                var sesionUsuario = ArchivosUsuarios.datosUsuarioLogin;
                //sesionUsuario._sVoto = false;
                if (sesionUsuario._bESTADO_VOTO == false)
                {
                    sesionUsuario._bESTADO_VOTO = true;
                    ArchivosUsuarios.UpdateFile(sesionUsuario);

                    //Instancia objeto voto 
                    Voto voto = new Voto(candidato._sNOMBRE, "A", DateTime.Now);

                    //Guarda el voto en el directorio ArchivosVotos
                    ArchivosVotos.CreateFile(voto);

                    votar.Enabled = false;

                    this.Hide();
                    CertificadoVotacion certificado = new CertificadoVotacion();
                    certificado.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show($"Estimado/a {sesionUsuario._sNOMBRES} solo puede votar una vez");

                    this.Hide();
                    Login log = new Login();
                    log.ShowDialog();
                    this.Close();
                }
            };

            panelCandidato.Controls.AddRange(new Control [] { nombreCandidato, lista, listaCandidato, votar });
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

        private void btnGeneralCertificado_Click (object sender, EventArgs e) {
            this.Hide();
            CertificadoVotacion certificadoVotacion = new CertificadoVotacion();
            certificadoVotacion.ShowDialog();
            this.Close();
        }

        private void btnSalir_Click (object sender, EventArgs e) {
            this.Hide();
            Login login = new Login();
            login.ShowDialog();
            this.Close();
        }
    }
}
