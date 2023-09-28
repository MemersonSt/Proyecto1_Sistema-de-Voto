using Proyecto1_Sistema_de_Voto.Clases;
using Proyecto1_Sistema_de_Voto.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto1_Sistema_de_Voto 
{
    public partial class DatosDelVotante : Form 
    {
        private string cedulaValidation = "[0-9]";

        public DatosDelVotante () 
        {
            InitializeComponent();
        }

        private bool Validaciones()
        {
            Regex rx = new Regex(cedulaValidation);
            MatchCollection matches = rx.Matches(txtCedula.Text);

            if (txtCedula.Text.Length == 0)
            {
                MessageBox.Show("Ingrese su n° de cédula.");
                txtCedula.Focus();
                return false;
            }

            if (txtCedula.Text.Length > 10 || txtCedula.Text.Length < 10)
            {
                MessageBox.Show("Ingrese un n° de cédula válido.");
                txtCedula.Focus();
                return false;
            }

            if (matches.Count == 0)
            {
                MessageBox.Show("Ingrese un n° cédula válido");
                return false;
            }

            if (txtNombres.Text.Length == 0)
            {
                MessageBox.Show("Ingrese sus nombres.");
                txtNombres.Focus();
                return false;
            }

            if (txtApellidos.Text.Length == 0)
            {
                MessageBox.Show("Ingrese sus apellidos.");
                txtApellidos.Focus();
                return false;
            }

            if (txtContraseña.Text.Length == 0)
            {
                MessageBox.Show("Ingrese una contraseña.");
                txtContraseña.Focus();
                return false;
            }

            if (cboxProvincia.Text.Length == 0)
            {
                MessageBox.Show("Ingrese una de las opcíones disponibles.");
                cboxProvincia.Focus();
                return false;
            }

            return true;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.ShowDialog();
            this.Close();
        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            if (Validaciones())
            {
                if (ArchivosUsuarios.ReadFile(txtCedula.Text) != null)
                {
                    MessageBox.Show("El usuario ya existe.");
                    //ArchivosUsuarios.DeleteFile(txtCedula.Text);
                }
                else
                {
                    Usuario user = new Usuario(txtCedula.Text, txtNombres.Text, txtApellidos.Text, txtContraseña.Text, cboxProvincia.Text);
                    ArchivosUsuarios.CreateFile(user);
                    MessageBox.Show("Inscripción exitosa");
                    this.Hide();
                    Login log = new Login();
                    log.ShowDialog();
                    this.Close();
                    //Usuario usuario = ArchivosUsuarios.ReadFile(txtCedula.Text);
                    //MessageBox.Show(usuario._sCedula + " , " + usuario._sNombres + " , " + usuario._sApellidos + " , " + usuario._sContraseña + " , " + usuario._sProvincia);
                }
            }
        }
    }
}
