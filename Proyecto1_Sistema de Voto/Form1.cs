using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto1_Sistema_de_Voto {
    public partial class Form1 : Form {
        public Form1 () {
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
            DatosDelVotante votar = new DatosDelVotante();
            votar.ShowDialog();
            this.Close();
        }
    }
}
