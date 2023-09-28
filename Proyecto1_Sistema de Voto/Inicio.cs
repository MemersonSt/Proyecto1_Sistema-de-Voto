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
    public partial class formInicio : Form {
        public formInicio () {
            InitializeComponent();
        }

        private void Formulario(object formulario) {
            if (this.panelContenedor.Controls.Count > 0)
                this.panelContenedor.Controls.RemoveAt(0);
            Form form = formulario as Form;
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(form);
            this.panelContenedor.Tag = form;
            form.Show();
        }

        private void btnIniciarVoto_Click (object sender, EventArgs e) {
            InicioSesion votar = new InicioSesion();
            votar.ShowDialog();
            this.Close();
        }

        private void btnAdministrador_Click (object sender, EventArgs e) {
            InicioSesion iniciar = new InicioSesion();
            iniciar.ShowDialog();
        }

        private void formInicio_Load (object sender, EventArgs e) {
        }
    }
}
