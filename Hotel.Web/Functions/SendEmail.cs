using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace Hotel.Web.Functions
{
    public class SendEmail
    {
        public void SendMail(string email, string subject, string body)
        {
            try
            {
                MailMessage mailMessage = new MailMessage();
                mailMessage.To.Add(email);
                mailMessage.From = new MailAddress("deep.apsingekar@gmail.com");
                mailMessage.Subject = subject;
                mailMessage.Body = body;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
                NetworkCred.UserName = "deep.apsingekar@gmail.com"; //godaddy domain
                NetworkCred.Password = "Sandeep505@";
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                mailMessage.IsBodyHtml = true;
                smtp.Send(mailMessage);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}