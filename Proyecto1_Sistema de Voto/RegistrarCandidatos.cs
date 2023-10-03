﻿using Proyecto1_Sistema_de_Voto.clases;
using Proyecto1_Sistema_de_Voto.Mail;
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
    public partial class RegistrarCandidatos : Form 
    {
        private string cedulaValidation = "[0-9]";

        private string mensaje = "Estimado/a {0} se ha realizado su registra a la candidatura";

        private string mailValidation = @"^([^@]*@[^@]*)$";

        public RegistrarCandidatos () 
        {
            InitializeComponent();
        }

        private bool Validaciones()
        {
            if (txtNombre.Text.Length == 0)
            {
                MessageBox.Show("Ingrese el nombre del candidato.");
                txtNombre.Focus();
                return false;
            }

            if (txtCedula.Text.Length == 0)
            {
                MessageBox.Show("Ingrese el n° de cédula del candidato.");
                txtCedula.Focus();
                return false;
            }

            if (txtCedula.Text.Length > 10 || txtCedula.Text.Length < 10)
            {
                MessageBox.Show("Ingrese un n° de cédula válido.");
                txtCedula.Focus();
                return false;
            }

            Regex rg = new Regex(cedulaValidation);

            MatchCollection matches = rg.Matches(txtCedula.Text);

            if (matches.Count == 0)
            {
                MessageBox.Show("Ingrese un n° de cédula válido.");
                txtCedula.Focus();
                return false;
            }

            if (txtLista.Text.Length == 0)
            {
                MessageBox.Show("Ingrese la lista del candidato.");
                txtLista.Focus();
                return false;
            }

            if (txtMail.Text.Length == 0)
            {
                MessageBox.Show("Ingrese el correo electrónico del candidato.");
                txtMail.Focus();
                return false;
            }

            rg = new Regex(mailValidation);
            matches = rg.Matches(txtMail.Text);

            if (matches.Count == 0)
            {
                MessageBox.Show("Ingrese un correo electrónico válido.");
                txtMail.Focus();
                return false;
            }
            return true;
        }


        //Usaré este método para mostrar la notificación de candidato registrado(Aun no se como hacerlo xd)
        private void Formulario(object formulario)
        {
            if (this.panelNotificación.Controls.Count > 0)
                this.panelNotificación.Controls.RemoveAt(0);
            Form form = formulario as Form;
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            this.panelNotificación.Controls.Add(form);
            this.panelNotificación.Tag = form;
            form.Show();
        }

        private void btnSalir_Click (object sender, EventArgs e) 
        {
            this.Hide();
            MenuAdministrador menu = new MenuAdministrador();
            menu.ShowDialog();
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //Formulario(new Notificacion());
            if (Validaciones())
            {
                if (ArchivosCandidatos.ReadFile(txtCedula.Text) != null)
                {
                    MessageBox.Show("El candidato ya existe.");
                    //Descomentar para eliminar candidato creado de prueba
                    //ArchivosCandidatos.DeleteFile(txtCedula.Text);
                }
                else
                {
                    Candidato candidato = new Candidato(txtCedula.Text, txtNombre.Text, txtLista.Text, txtMail.Text);
                    ArchivosCandidatos.CreateFile(candidato);

                    Mail.Mail.SendMail(candidato._sMail, "Registro Candidatura", $"Estimado/a {candidato._sNombre} se ha realizado su registro exitosamente\nFecha: {DateTime.Now.ToLongDateString()}\nHora: {DateTime.Now.ToLongTimeString()}\nLe deseamos éxito en las elecciones");
                }
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (Validaciones())
            {
                if (ArchivosCandidatos.ReadFile(txtCedula.Text) != null)
                {
                    Candidato candidato = new Candidato(txtCedula.Text, txtNombre.Text, txtLista.Text, txtMail.Text);
                    ArchivosCandidatos.UpdateFile(candidato);

                    Mail.Mail.SendMail(candidato._sMail, "Actualización Candidatura", $"Estimado/a {candidato._sNombre} se han actualizado sus datos exitosamente\nFecha: {DateTime.Now.ToLongDateString()}\nHora: {DateTime.Now.ToLongTimeString()}\nLe deseamos éxito en las elecciones");
                }
                else
                {
                    MessageBox.Show("El candidato no existe.");
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Validaciones())
            {
                if (ArchivosCandidatos.ReadFile(txtCedula.Text) != null)
                {
                    Candidato candidato = new Candidato(txtCedula.Text, txtNombre.Text, txtLista.Text, txtMail.Text);
                    ArchivosCandidatos.DeleteFile(txtCedula.Text);
                    Mail.Mail.SendMail(candidato._sMail, "Eliminación Candidatura", $"Estimado/a {candidato._sNombre} se han eliminado sus datos\nFecha: {DateTime.Now.ToLongDateString()}\nHora: {DateTime.Now.ToLongTimeString()}\nLe deseamos éxito en las próximas elecciones");
                }
                else
                {
                    MessageBox.Show("El candidato no existe.");
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtBuscar.Text.Length == 0)
            {
                MessageBox.Show("Ingrese el n° de cedula del candidato que desea buscar.");
            }
            else
            {
                var candidato = ArchivosCandidatos.ReadFile(txtBuscar.Text);
                if (candidato != null)
                {
                    txtCedula.Text = candidato._sCedula;
                    txtNombre.Text = candidato._sNombre;
                    txtLista.Text = candidato._sLista;
                    txtMail.Text = candidato._sMail;
                }
            }
        }
    }
}
