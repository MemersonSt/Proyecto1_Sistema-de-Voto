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

namespace Proyecto1_Sistema_de_Voto.VotosUsuarios {
    public partial class RegistrarVotos : Form {
        
        public RegistrarVotos () {
            InitializeComponent();
        }

        private void RegistrarVotos_Load (object sender, EventArgs e) {
            List<Candidato> listaCandidatos = ArchivosCandidatos.ReadList();
            if (listaCandidatos.Count == 0) {
                MessageBox.Show("No se encontraron candidatos en la lista.");
            } else {
                foreach (Candidato candidato in listaCandidatos) {
                    Panel panelCandidato = new Panel();
                    panelCandidato.Size = new Size(140, 180);
                    panelCandidato.BackColor = Color.FromArgb(20, 108, 148);
                    panelCandidato.Margin = new Padding(10, 10, 20, 10);

                    Label nombreCandidato = new Label();
                    nombreCandidato.Size = new Size(120, 50);
                    nombreCandidato.Text = candidato._sNombre;
                    nombreCandidato.Location = new Point(6, 7);
                    nombreCandidato.Font = new Font("Cambria", 16, FontStyle.Bold);
                    nombreCandidato.ForeColor = Color.White;
                    Label lista = new Label();
                    lista.Size = new Size(53, 17);
                    lista.Location = new Point(8, 74);
                    lista.Font = new Font("Cambria", 10, FontStyle.Bold);
                    lista.Text = "Lista:";

                    Label listaCandidato = new Label();
                    listaCandidato.Text = candidato._sLista;
                    listaCandidato.Size = new Size(50, 15);
                    listaCandidato.Location = new Point(58, 76);

                    Button votar = new Button();
                    votar.Size = new Size(118, 35);
                    votar.Location = new Point(9, 125);
                    votar.BackColor = Color.FromArgb(25, 167, 206);
                    votar.FlatStyle = FlatStyle.Flat;
                    votar.FlatAppearance.BorderSize = 0;
                    votar.Text = "Votar";
                    RedondearPanel(panelCandidato, 10);
                    panelCandidato.Controls.Add(nombreCandidato);
                    panelCandidato.Controls.Add(lista);
                    panelCandidato.Controls.Add(listaCandidato);
                    panelCandidato.Controls.Add(votar);
                    flowLayoutPanel1.Controls.Add(panelCandidato);
                }
            }
            RedondearPanel(panelContenedor, 12);
            panel1.Visible = false;
        }

        private void RedondearPanel (Panel panel, int radio) {
            // Crear un gráfico de la forma del panel
            GraphicsPath formaPanel = new GraphicsPath();
            formaPanel.AddArc(0, 0, radio, radio, 180, 90); // Esquina superior izquierda
            formaPanel.AddArc(panel.Width - radio, 0, radio, radio, 270, 90); // Esquina superior derecha
            formaPanel.AddArc(panel.Width - radio, panel.Height - radio, radio, radio, 0, 90); // Esquina inferior derecha
            formaPanel.AddArc(0, panel.Height - radio, radio, radio, 90, 90); // Esquina inferior izquierda
            formaPanel.CloseAllFigures(); // Cerrar la figura

            // Configurar la región del panel con la forma redondeada
            panel.Region = new Region(formaPanel);
        }
    }
}
