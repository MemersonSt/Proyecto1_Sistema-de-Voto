using Proyecto1_Sistema_de_Voto.Clases;
using Proyecto1_Sistema_de_Voto.Models;
using Proyecto1_Sistema_de_Voto.VotosUsuarios;
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

        public DatosDelVotante()
        {
            InitializeComponent();
        }

        private bool Validaciones () 
        {
            Regex rx = new Regex(cedulaValidation);
            MatchCollection matches = rx.Matches(textCedula.Text);

            if (txtMail.Text.Length == 0)
            {
                MessageBox.Show("Ingrese su correo electrónico.");
                txtMail.Focus();
                return false;
            }

            if (textCedula.Text.Length == 0) 
            {
                MessageBox.Show("Ingrese su n° de cédula.");
                textCedula.Focus();
                return false;
            }

            if (textCedula.Text.Length > 10 || textCedula.Text.Length < 10) 
            {
                MessageBox.Show("Ingrese un n° de cédula válido.");
                textCedula.Focus();
                return false;
            }

            if (matches.Count == 0) 
            {
                MessageBox.Show("Ingrese un n° cédula válido");
                return false;
            }

            if (textNombre.Text.Length == 0) 
            {
                MessageBox.Show("Ingrese sus nombres.");
                textNombre.Focus();
                return false;
            }

            if (textApellido.Text.Length == 0) 
            {
                MessageBox.Show("Ingrese sus apellidos.");
                textApellido.Focus();
                return false;
            }

            if (textPassword.Text.Length == 0) 
            {
                MessageBox.Show("Ingrese una contraseña.");
                textPassword.Focus();
                return false;
            }

            if (cboxProvincia.Text.Length == 0) 
            {
                MessageBox.Show("Ingrese una de las opcíones disponibles.");
                cboxProvincia.Focus();
                return false;
            }

            if (cbSexo.Text.Length == 0)
            {
                MessageBox.Show("Ingrese una de las opcíones disponibles.");
                cbSexo.Focus();
                return false;
            }

            return true;
        }

        private void btnContinuar_Click (object sender, EventArgs e) 
        {
            if (Validaciones()) 
            {
                var usuario = ArchivosUsuarios.ReadUserByCedula(textCedula.Text);
                if (usuario != null)
                {
                    if (usuario._sCEDULA == textCedula.Text)
                    {
                        MessageBox.Show("El usuario ya existe.");
                    }
                    else
                    {
                        Usuario user = new Usuario(txtMail.Text, textCedula.Text, textNombre.Text, textApellido.Text, textPassword.Text, cboxProvincia.Text, false, cbSexo.Text, "A", DateTime.Now);
                        ArchivosUsuarios.CreateUser(user);
                        MessageBox.Show("Inscripción exitosa");
                        this.Hide();
                        Login abrir = new Login();
                        abrir.ShowDialog();
                        this.Close();
                    }
                }
                else
                {
                    Usuario user = new Usuario(txtMail.Text, textCedula.Text, textNombre.Text, textApellido.Text, textPassword.Text, cboxProvincia.Text, false, cbSexo.Text, "A", DateTime.Now);
                    ArchivosUsuarios.CreateUser(user);
                    MessageBox.Show("Inscripción exitosa");
                    this.Hide();
                    Login abrir = new Login();
                    abrir.ShowDialog();
                    this.Close();
                }

            }
        }

        private void btnVolver_Click (object sender, EventArgs e) 
        {
            this.Hide();
            Login login = new Login();
            login.ShowDialog();
            this.Close();
        }
    }
}
