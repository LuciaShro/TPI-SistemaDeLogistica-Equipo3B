using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Gestion
{
    public class EmailService
    {
        private MailMessage email;
        private SmtpClient server;

        public EmailService()
        {
            server = new SmtpClient();
            server.Credentials = new NetworkCredential("flashship2025@gmail.com", "nkns cxrn ipmo pxqc");
            server.EnableSsl = true;
            server.Port = 587;
            server.Host = "smtp.gmail.com";
        }

        public void armarCorreo(string emailDestino, string nombreDestinatario, string idOrden, int idEstado, string provincia)
        {
            email = new MailMessage();
            email.From = new MailAddress("flashship2025@gmail.com", "FlashShip");
            email.To.Add(emailDestino);
            if (idEstado == 1)
            {
                if (provincia.ToLower() == "buenos aires" || provincia.ToLower() == "ciudad autónoma de buenos aires")
                {
                    email.Subject = "¡Tu pedido está en camino!🏆. Numero de Orden: #" + idOrden;
                    email.IsBodyHtml = true;
                    email.Body = "<h1>Tu pedido ya fue despachado</h1> <br> ¡Hola! " + nombreDestinatario + "<br><br> Te informamos que despachamos tu pedido y " +
                        "dentro de las próximas 24hs lo vas a estar recibiendo en el domicilio de entrega. Cuando llegue se le sera notificado con otro mail. " +
                        "<br><br> El equipo de Flaship";
                }
                else
                {
                    email.Subject = "¡Tu pedido está en camino!🏆. Numero de Orden: #" + idOrden;
                    email.IsBodyHtml = true;
                    email.Body = "<h1>Tu pedido ya fue despachado</h1> <br> ¡Hola! " + nombreDestinatario + "<br><br> Te informamos que despachamos tu pedido y " +
                        "entre los proximos 5 a 10 dias lo vas a estar recibiendo en el domicilio de entrega. Cuando llegue se le sera notificado con otro mail. " +
                        "<br><br> El equipo de Flaship";
                }
                    
            }
            else if (idEstado == 2) {
                if (provincia.ToLower() == "buenos aires" || provincia.ToLower() == "ciudad autónoma de buenos aires")
                {
                    email.Subject = "⏳Lo sentimos, tu pedido se encuentra con demoras y se postergara un dia mas. Numero de Orden: #" + idOrden;
                    email.IsBodyHtml = true;
                    email.Body = "<h1>Tu pedido se encuentra con demoras por problemas tecnicos</h1> <br><br> ¡Hola! " + nombreDestinatario +
                        "<br><br> Te informamos que postergamos la fecha de la entrega de tu pedido un dia mas " +
                        ". Estamos trabajando para que lo recibas lo antes posible.<br><br>" +
                        "Te pedimos disculpas por las molestias y agradecemos tu paciencia.<br><br>" +
                        "<br><br> El equipo de Flaship";
                }
                else
                {
                    email.Subject = "⏳Lo sentimos, tu pedido se encuentra con demoras y se postergara un dia mas. Numero de Orden: #" + idOrden;
                    email.IsBodyHtml = true;
                    email.Body = "<h1>Tu pedido se encuentra con demoras por problemas tecnicos</h1> <br><br> ¡Hola! " + nombreDestinatario +
                        "<br><br> Te informamos que postergamos la fecha de la entrega de tu pedido un dia mas " +
                        ". Estamos trabajando para que lo recibas lo antes posible.<br><br>" +
                        "Te pedimos disculpas por las molestias y agradecemos tu paciencia.<br><br>" +
                        "<br><br> El equipo de Flaship";
                }  
            }
            else
            {
                email.Subject = "¡Tu pedido ya fue entregado exitosamente!📦✅. Numero de Orden: #" + idOrden;
                email.IsBodyHtml = true;
                email.Body = "<h1>Tu pedido fue entregado.</h1> <br><br> ¡Hola! " + nombreDestinatario + "<br><br> Te informamos que tu pedido ha sido entregado." +
                    "Recibiras tu factura en un correo electronico independiente. <br> Gracias por usar nuestro servicio. " +
                    "<br><br> El equipo de Flaship";
            }
                
        }

        public void enviarMail()
        {
            try
            {
                server.Send(email);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
