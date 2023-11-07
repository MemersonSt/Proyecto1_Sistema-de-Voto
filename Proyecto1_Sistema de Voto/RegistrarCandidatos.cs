using Proyecto1_Sistema_de_Voto.clases;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Proyecto1_Sistema_de_Voto 
{
    public partial class RegistrarCandidatos : Form 
    {
        private string cedulaValidation = "[0-9]";

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
            if (Validaciones())
            {
                var cand = ArchivosCandidatos.ReadCandidateByCedula(txtCedula.Text);
                if (cand != null && cand._sESTADO == "A")
                {
                    if (cand._sCEDULA == txtCedula.Text)
                    {
                        MessageBox.Show("El candidato ya existe.");
                    }
                    else
                    {
                        Candidato candidato = new Candidato(txtCedula.Text, txtNombre.Text, txtLista.Text, txtMail.Text, "A", DateTime.Now);
                        ArchivosCandidatos.CreateCandidate(candidato);

                        Mail.Mail.SendMail(candidato._sMAIL, "Registro Candidatura", $"Estimado/a {candidato._sNOMBRE} se ha realizado su registro exitosamente\nFecha: {DateTime.Now.ToLongDateString()}\nHora: {DateTime.Now.ToLongTimeString()}\nLe deseamos éxito en las elecciones");

                        MessageBox.Show($"El candidato {txtNombre.Text} ha sido registrado.");
                    }
                }
                else if (cand != null && cand._sESTADO == "I")
                {
                    Candidato candidato = new Candidato(txtCedula.Text, txtNombre.Text, txtLista.Text, txtMail.Text, "A", DateTime.Now);
                    ArchivosCandidatos.UpdateCandidate(candidato);

                    Mail.Mail.SendMail(candidato._sMAIL, "Registro Candidatura", $"Estimado/a {candidato._sNOMBRE} se ha realizado su registro exitosamente\nFecha: {DateTime.Now.ToLongDateString()}\nHora: {DateTime.Now.ToLongTimeString()}\nLe deseamos éxito en las elecciones");

                    MessageBox.Show($"El candidato {txtNombre.Text} ha sido registrado.");
                }
                else
                {
                    Candidato candidato = new Candidato(txtCedula.Text, txtNombre.Text, txtLista.Text, txtMail.Text, "A", DateTime.Now);
                    ArchivosCandidatos.CreateCandidate(candidato);

                    Mail.Mail.SendMail(candidato._sMAIL, "Registro Candidatura", $"Estimado/a {candidato._sNOMBRE} se ha realizado su registro exitosamente\nFecha: {DateTime.Now.ToLongDateString()}\nHora: {DateTime.Now.ToLongTimeString()}\nLe deseamos éxito en las elecciones");

                    MessageBox.Show($"El candidato {txtNombre.Text} ha sido registrado.");
                }
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (Validaciones())
            {
                var cand = ArchivosCandidatos.ReadCandidateByCedula(txtCedula.Text);
                if (cand != null && cand._sESTADO == "A")
                {
                    Candidato candidato = new Candidato(txtCedula.Text, txtNombre.Text, txtLista.Text, txtMail.Text, "A", DateTime.Now);
                    ArchivosCandidatos.UpdateCandidate(candidato);

                    Mail.Mail.SendMail(candidato._sMAIL, "Actualización Candidatura", $"Estimado/a {candidato._sNOMBRE} se han actualizado sus datos exitosamente\nFecha: {DateTime.Now.ToLongDateString()}\nHora: {DateTime.Now.ToLongTimeString()}\nLe deseamos éxito en las elecciones");

                    MessageBox.Show($"El candidato {txtNombre.Text} ha sido actualizado.");
                }
                else if (cand != null && cand._sESTADO == "I")
                {
                    MessageBox.Show("El candidato no existe.");
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
                var cand = ArchivosCandidatos.ReadCandidateByCedula(txtCedula.Text);
                if (cand != null && cand._sESTADO == "A")
                {
                    string message = $"Está seguro/a de eliminar el candidato {txtNombre.Text}?";
                    string caption = "Eliminando";
                    var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        Candidato candidato = new Candidato(txtCedula.Text, txtNombre.Text, txtLista.Text, txtMail.Text, "I", DateTime.Now);
                        ArchivosCandidatos.DeleteCandidate(candidato);

                        Mail.Mail.SendMail(candidato._sMAIL, "Eliminación Candidatura", $"Estimado/a {candidato._sNOMBRE} se han eliminado sus datos\nFecha: {DateTime.Now.ToLongDateString()}\nHora: {DateTime.Now.ToLongTimeString()}\nLe deseamos éxito en las próximas elecciones");

                        MessageBox.Show($"El candidato {txtNombre.Text} ha sido eliminado.");
                    }
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
                var candidato = ArchivosCandidatos.ReadCandidateByCedula(txtBuscar.Text);
                if (candidato != null)
                {
                    txtCedula.Text = candidato._sCEDULA;
                    txtNombre.Text = candidato._sNOMBRE;
                    txtLista.Text = candidato._sLISTA;
                    txtMail.Text = candidato._sMAIL;
                }
            }
        }
    }
}
