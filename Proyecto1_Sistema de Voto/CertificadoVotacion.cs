using Proyecto1_Sistema_de_Voto.Clases;
using Proyecto1_Sistema_de_Voto.Models;
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
    public partial class CertificadoVotacion : Form {
        public CertificadoVotacion () {
            InitializeComponent();
        }

        private void CertificadoVotacion_Load (object sender, EventArgs e) {
            lbNombre.Text = ArchivosUsuarios.datosUsuarioLogin._sNOMBRES;
            lbApellido.Text = ArchivosUsuarios.datosUsuarioLogin._sAPELLIDOS;
            lbCedula.Text = ArchivosUsuarios.datosUsuarioLogin._sCEDULA;
            lbProvincia.Text = ArchivosUsuarios.datosUsuarioLogin._sPROVINCIA;
            lblSexo.Text = ArchivosUsuarios.datosUsuarioLogin._sSEXO;
        }
    }
}
