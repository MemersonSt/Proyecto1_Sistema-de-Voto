using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1_Sistema_de_Voto.Mail
{
    public static class Mail
    {
        private static string sSmtpServer = "smtp.outlook.com";
        private static int iPuertoSmtp = 587;
        private static string sUsuarioSmtp = "ProyectoSV_123@outlook.com";
        private static string sRemitente = "ProyectoSV_123@outlook.com";
        

        public static void SendMail(string sDestinatario, string sAsunto, string sCuerpo)
        {
            MailMessage correo = new MailMessage(sRemitente, sDestinatario, sAsunto, sCuerpo);

            //correo.IsBodyHtml = true;
            SmtpClient clienteSmtp = new SmtpClient(sSmtpServer)
            {
                Port = iPuertoSmtp,
                Credentials = new NetworkCredential(sUsuarioSmtp, sContrasenaSmtp),
                EnableSsl = true,
            };

            try
            {
                clienteSmtp.Send(correo);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al enviar el correo electrónico: " + ex.Message);
            }
            finally
            {
                correo.Dispose();
            }
        }

        private static string sContrasenaSmtp = "PSV01234";
    }
}
