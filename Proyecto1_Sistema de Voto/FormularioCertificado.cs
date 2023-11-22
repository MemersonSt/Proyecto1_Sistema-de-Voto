using ImageMagick;
using Proyecto1_Sistema_de_Voto.Clases;
using Proyecto1_Sistema_de_Voto.Mail;
using Proyecto1_Sistema_de_Voto.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto1_Sistema_de_Voto
{
    public partial class FormularioCertificado : Form
    {
        public FormularioCertificado()
        {
            InitializeComponent();
        }

        Usuario user = ArchivosUsuarios.datosUsuarioLogin;

        private void CargarFormulario(Form formulario)
        {
            if (this.plCertificado.Controls.Count > 0)
                this.plCertificado.Controls.RemoveAt(0);
            
            formulario.TopLevel = false;
            formulario.Dock = DockStyle.Fill;
            this.plCertificado.Controls.Add(formulario);
            this.plCertificado.Tag = formulario;
            formulario.Show();

            formulario.Size = this.plCertificado.Size;
        }

        private void FormularioCertificado_Load(object sender, EventArgs e)
        {
            //Muestra una vista previa del certificado de votación del usuario
            CargarFormulario(new CertificadoVotacion());
            RedondearPanel(this.plCertificado, 10);

            //Muestra el correo electrónico al que se enviará el certificado
            txtCorreoUsuario.Text = user._sMail;
        }

        private void RedondearPanel(Panel panel, int radio)
        {
            GraphicsPath formaPanel = new GraphicsPath();
            formaPanel.AddArc(0, 0, radio, radio, 180, 90);
            formaPanel.AddArc(panel.Width - radio, 0, radio, radio, 270, 90);
            formaPanel.AddArc(panel.Width - radio, panel.Height - radio, radio, radio, 0, 90);
            formaPanel.AddArc(0, panel.Height - radio, radio, radio, 90, 90);
            formaPanel.CloseAllFigures();

            panel.Region = new Region(formaPanel);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string sAsunto = "CERTIFICADO DE VOTACIÓN";
            string sCuerpo = $"Estimad@ {user._sNOMBRES} {user._sAPELLIDOS}.\nNos complace adjuntar el siguiente documento.\nDocumento pdf: Certificado de votación.\nEmitido el día {DateTime.Now.ToLongDateString()}";
            string PdfFilePath = "Certificado.pdf";

            ConvertPanelToPdf();
            //Envia un correo electrónico al usuario con su certificado de votación
            Mail.Mail.SendMailToUser(user._sMail, sAsunto, sCuerpo, PdfFilePath);
            //Elimina el pdf del almacenamiento local
            EliminarArchivo(PdfFilePath);

            this.Hide();
            formInicio inicio = new formInicio();
            inicio.ShowDialog();
            this.Close();
        }

        private void ConvertPanelToPdf()
        {
            try
            {
                // Crea una imagen del contenido del panel
                Bitmap bitmap = new Bitmap(this.plCertificado.Width, this.plCertificado.Height);
                this.plCertificado.DrawToBitmap(bitmap, new Rectangle(0, 0, this.plCertificado.Width, this.plCertificado.Height));

                // Guardar la imagen
                string ImageFilePath = "panel.png";
                bitmap.Save(ImageFilePath, System.Drawing.Imaging.ImageFormat.Png);

                // Crear documento PDF
                string PdfFilePath = "Certificado.pdf";

                using (MagickImageCollection imgCollection = new MagickImageCollection())
                {
                    //Agrega la imagen a la coleccion
                    imgCollection.Add(ImageFilePath);//Se pueden agregar más imagenes, pero cada imagen representará 1 página en el pdf

                    //Escribe la imagen en el documento pdf
                    imgCollection.Write(PdfFilePath);
                }

                //Elimina la imagen del almacenamiento local
                EliminarArchivo(ImageFilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el PDF: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EliminarArchivo(string path)
        {
            try
            {
                if (File.Exists(path))
                {
                    //Si existe elimina el archivo
                    File.Delete(path);
                }
                else
                {
                    Console.WriteLine("El archivo no existe");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al intentar eliminar el archivo: " + ex.Message);
            }
        }
    }
}
