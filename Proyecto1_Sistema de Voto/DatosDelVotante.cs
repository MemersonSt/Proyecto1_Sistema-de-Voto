﻿using Proyecto1_Sistema_de_Voto.Clases;
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

namespace Proyecto1_Sistema_de_Voto {
    public partial class DatosDelVotante : Form {
        private string cedulaValidation = "[0-9]";

        public DatosDelVotante () {
            InitializeComponent();
        }

        private bool Validaciones () {
            Regex rx = new Regex(cedulaValidation);
            MatchCollection matches = rx.Matches(textCedula.Text);

            if (textCedula.Text.Length == 0) {
                MessageBox.Show("Ingrese su n° de cédula.");
                textCedula.Focus();
                return false;
            }

            if (textCedula.Text.Length > 10 || textCedula.Text.Length < 10) {
                MessageBox.Show("Ingrese un n° de cédula válido.");
                textCedula.Focus();
                return false;
            }

            if (matches.Count == 0) {
                MessageBox.Show("Ingrese un n° cédula válido");
                return false;
            }

            if (textNombre.Text.Length == 0) {
                MessageBox.Show("Ingrese sus nombres.");
                textNombre.Focus();
                return false;
            }

            if (textApellido.Text.Length == 0) {
                MessageBox.Show("Ingrese sus apellidos.");
                textApellido.Focus();
                return false;
            }

            if (textPassword.Text.Length == 0) {
                MessageBox.Show("Ingrese una contraseña.");
                textPassword.Focus();
                return false;
            }

            if (cboxProvincia.Text.Length == 0) {
                MessageBox.Show("Ingrese una de las opcíones disponibles.");
                cboxProvincia.Focus();
                return false;
            }

            return true;
        }

        private void btnContinuar_Click (object sender, EventArgs e) {
            if (Validaciones()) {
                if (ArchivosUsuarios.ReadFile(textCedula.Text) != null) {
                    MessageBox.Show("El usuario ya existe.");
                    //ArchivosUsuarios.DeleteFile(txtCedula.Text);
                } else {
                    Usuario user = new Usuario(textCedula.Text, textNombre.Text, textApellido.Text, textPassword.Text, cboxProvincia.Text);
                    ArchivosUsuarios.CreateFile(user);
                    MessageBox.Show("Inscripción exitosa");
                    this.Hide();
                    InicioSesion log = new InicioSesion();
                    log.ShowDialog();
                    this.Close();
                    //Usuario usuario = ArchivosUsuarios.ReadFile(txtCedula.Text);
                    //MessageBox.Show(usuario._sCedula + " , " + usuario._sNombres + " , " + usuario._sApellidos + " , " + usuario._sContraseña + " , " + usuario._sProvincia);
                }
            }
        }

        private void btnVolver_Click (object sender, EventArgs e) {
            this.Hide();
            InicioSesion login = new InicioSesion();
            login.ShowDialog();
            this.Close();
        }
    }
}
