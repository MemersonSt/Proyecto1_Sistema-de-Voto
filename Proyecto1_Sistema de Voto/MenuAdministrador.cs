using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto1_Sistema_de_Voto 
{
    public partial class MenuAdministrador : Form 
    {
        public MenuAdministrador () 
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.ShowDialog();
            this.Close();
        }

        private void btnRegistrarCandidatos_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegistrarCandidatos candidatos = new RegistrarCandidatos();
            candidatos.ShowDialog();
            this.Close();
        }

        private void btnListaCandidatos_Click (object sender, EventArgs e) {
            this.Hide();
            ListaCandidatos verLista = new ListaCandidatos();
            verLista.ShowDialog();
        }

        private void btnListaUsuarios_Click (object sender, EventArgs e) {
            this.Hide();
            UsuarioRegistrados verLista = new UsuarioRegistrados();
            verLista.ShowDialog();
        }
    }
}
