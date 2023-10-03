using Proyecto1_Sistema_de_Voto.clases;
using Proyecto1_Sistema_de_Voto.Clases;
using Proyecto1_Sistema_de_Voto.Models;
using Proyecto1_Sistema_de_Voto.VotosUsuarios;
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
    public partial class Login : Form 
    {

        public Login () 
        {
            InitializeComponent();
        }

        private void InicioSesion_Load (object sender, EventArgs e) 
        {
            //RedondearPanel(panel1, 10);
        }

        private void RedondearPanel (Panel panel, int radio) 
        {
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

        private void btnRegistrar_Click (object sender, EventArgs e) {
            this.Hide();
            DatosDelVotante registrar = new DatosDelVotante();
            registrar.ShowDialog();
            this.Close();
        }

        private void btnIngresar_Click (object sender, EventArgs e) {
            

            var user = ArchivosUsuarios.ReadFile(txtCedula.Text);
            if (user != null) {
                if (user._sCedula == txtCedula.Text && user._sContraseña == textPasword.Text) {
                    ArchivosUsuarios.datosUsuarioLogin = user;

                    this.Hide();
                    RegistrarVotos abrir = new RegistrarVotos();
                    abrir.ShowDialog();
                    this.Close();
                } else {
                    MessageBox.Show("Datos incorrectos.");
                }
            } else if (txtCedula.Text == Admin._sUserName && textPasword.Text == Admin._sPassword) {
                this.Hide();
                MenuAdministrador menu = new MenuAdministrador();
                menu.ShowDialog();
                this.Close();
            }
        }
    }
}
