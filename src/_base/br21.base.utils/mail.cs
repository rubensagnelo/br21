using System;
using System.Net.Mail;

namespace br21.baseutils
{
    public class mail
    {

        public static bool send( string destinatario, string corpo)
        {
            bool result = true;
            try
            { 
                string remetente = "rubensagnelo.br21@gmail.com"; //O e-mail do remetente
                MailMessage mail = new MailMessage();
                mail.To.Add(destinatario);
                mail.From = new MailAddress(remetente, "Nelson Borges", System.Text.Encoding.UTF8);
                mail.Subject = "Assunto:Este e-mail é um teste do Asp.Net";
                mail.SubjectEncoding = System.Text.Encoding.UTF8;
                mail.Body = corpo;
                mail.BodyEncoding = System.Text.Encoding.UTF8;
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High; //Prioridade do E-Mail
                SmtpClient client = new SmtpClient();  //Adicionando as credenciais do seu e-mail e senha:
                client.Credentials = new System.Net.NetworkCredential(remetente, "br#21@ah#86");
            } catch(Exception ex)
            {
                result = false;

            }
            return result;
        }


    }
}
