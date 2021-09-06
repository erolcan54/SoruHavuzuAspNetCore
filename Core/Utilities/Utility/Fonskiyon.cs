using System;
using System.Net;
using System.Net.Mail;

namespace Core.Utilities.Utility
{
    public static class Fonskiyon
    {
        public static void MailGonder(Email model)
        {
            try
            {
                MailMessage msg = new MailMessage();
                msg.Subject = "İNTERNET İLETİŞİM FORMU : " + model.subject.ToString();

                msg.From = new MailAddress("erolcan4654@gmail.com", "www.gmail.com");

                msg.To.Add(new MailAddress(model.to, "İnfo"));


                msg.Body = "Web Ortamından gelen Mesaj:  <br>" + " Konu : " + model.subject.ToString() + "<br>" + " İçerik  : " + model.body.ToString();

                msg.IsBodyHtml = true;

                msg.Priority = MailPriority.High;

                // Host ve Port Gereklidir!
                //SmtpClient smtp = new SmtpClient("mail.garsonokulu.com", 587);
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);

                // Güvenli bağlantı gerektiğinden kullanıcı adı ve şifrenizi giriniz.
                NetworkCredential AccountInfo = new NetworkCredential("erolcan4654@gmail.com", "030510035");

                smtp.UseDefaultCredentials = false;

                smtp.Credentials = AccountInfo;

                smtp.EnableSsl = false;

                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

                smtp.Send(msg);
            }
            catch (Exception e)
            {

                string hata = e.Message.ToString();
            }

        }
    }
}
