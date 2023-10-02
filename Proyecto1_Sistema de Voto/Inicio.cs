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

namespace Proyecto1_Sistema_de_Voto 
{
    public partial class formInicio : Form 
    {
        public formInicio () 
        {
            InitializeComponent();
        }
        private void formInicio_Load (object sender, EventArgs e) 
        {
        }

        private void btnIniciarVoto_Click (object sender, EventArgs e) 
        {
            //Votos inicio = new Votos();
            Login inicio = new Login();
            //Candidatos inicio = new Candidatos();
            //RegistrarVotos inicio = new RegistrarVotos();
            //UsuarioRegistrados inicio = new UsuarioRegistrados();
            inicio.ShowDialog();
            this.Close();
        }

        private void btnSalir_Click (object sender, EventArgs e) 
        {
            this.Dispose();
        }
    }
}
