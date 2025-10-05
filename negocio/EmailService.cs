using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace negocio
{
    public class EmailService
    {
        private MailMessage email;
        private SmtpClient server;

        public EmailService()
        {
            server = new SmtpClient();
            server.Credentials = new NetworkCredential("noresponderprogramacion@gmail.com", "kucd duvx wbhz sboi");
            server.EnableSsl = true;
            server.Port = 587;
            server.Host = "smtp.gmail.com";
        }

        public void armarCorreo(string emailDestino, string asunto, string cuerpo)
        {
            email = new MailMessage();
            email.From = new MailAddress("noresponderprogramacion@gmail.com");
            email.To.Add(emailDestino);
            email.Subject = asunto;
            email.IsBodyHtml = true;
            //email.Body = "<h1> SE HA REGISTRADO TU PREMIO! NOS PONDREMOS EN CONTACTO A LA BREVEDAD </h1>";
            email.Body = cuerpo;
        }

        public void enviarCorreo()
        {
            try
            {
                server.Send(email);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                email.Dispose();
            }
        }
    }
}
