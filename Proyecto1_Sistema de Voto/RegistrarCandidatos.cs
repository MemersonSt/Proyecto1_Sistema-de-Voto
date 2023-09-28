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
    public partial class RegistrarCandidatos : Form {
        public RegistrarCandidatos () {
            InitializeComponent();
        }

        private void btnSalir_Click (object sender, EventArgs e) {
            this.Hide();
            InicioSesion log = new InicioSesion();
            log.ShowDialog();
            this.Close();
        }
    }
}
