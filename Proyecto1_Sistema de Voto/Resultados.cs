using Proyecto1_Sistema_de_Voto.clases;
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

namespace Proyecto1_Sistema_de_Voto {
    public partial class Resultados : Form {
        public Resultados () {
            InitializeComponent();
        }

        private void Votos_Load (object sender, EventArgs e) {
            //List<Voto> cantVotos = ArchivosVotos.GetVotos();

            //int cantidadVotos = cantVotos.Count;
            
            
            int total = ArchivosVotos.GetVotos().Count;
            
            foreach (var item in ArchivosCandidatos.ReadList())
            {
                List<Voto> listVoto = new List<Voto>();

                foreach (var item1 in ArchivosVotos.GetVotos())
                {
                    if (item._sNombre.Equals(item1._sCandidato))
                    {
                        listVoto.Add(item1);
                    }
                }

                int cant = listVoto.Count;
                Panel panelCandidato = CrearPanelCandidato(item._sNombre, cant, total);
                flowLayoutPanel1.Controls.Add(panelCandidato);
            }
            /*
            foreach (var item in ArchivosCandidatos.ReadList())
            {
                int cant = listVoto.Count;
                Panel panelCandidato = CrearPanelCandidato(item._sNombre, cant, total);
                flowLayoutPanel1.Controls.Add(panelCandidato);
            }*/

            //Dictionary<string, int> votosPorCandidato = new Dictionary<string, int>();

            /*foreach (var voto in listaVotos) {
                Panel panelCandidato = CrearPanelCandidato(voto._sCandidato, cantVotos);
                flowLayoutPanel1.Controls.Add(panelCandidato);
            }*/

            // Ahora tenemos un diccionario con los candidatos y la cantidad de votos recibidos

            /*foreach (var kvp in votosPorCandidato) {
                Panel panelCandidato = CrearPanelCandidato(kvp.Key, kvp.Value);
                flowLayoutPanel1.Controls.Add(panelCandidato);
            }*/
        }

        private Panel CrearPanelCandidato (string candidato, int votos, int total) {
            Panel panelCandidato = new Panel {
                Size = new Size(256, 147),
                BackColor = Color.FromArgb(20, 108, 148),
                Margin = new Padding(10, 10, 10, 10)
            };

            Label nombreCandidato = CrearLabel(candidato, new Size(230, 25), new Point(6, 7), 16, FontStyle.Bold, Color.White);
            Label lista = CrearLabel("Votos:", new Size(53, 17), new Point(8, 42), 10, FontStyle.Bold, Color.White);
            Label listaCandidato = CrearLabel(ArchivosVotos.CalcularPorcentaje(votos,total), new Size(41, 15), new Point(51, 44), 10, FontStyle.Regular, Color.White);

            ProgressBar progressBar = crearProgress(new Size(225, 23), new Point(11, 98));
            progressBar.Value = votos; // Puedes ajustar el valor de la ProgressBar según la cantidad de votos
            progressBar.Maximum = total;
            progressBar.Minimum = 0;

            panelCandidato.Controls.AddRange(new Control [] { nombreCandidato, lista, listaCandidato, progressBar });
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

        private ProgressBar crearProgress (Size size, Point location) {
            return new ProgressBar {
                Size = size,
                Location = location,
                BackColor = Color.FromArgb(25, 167, 206),
                Value = 50,
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
