using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace App.Services.HelperServices
{
    public class EmailSenderService : IEmailSenderService
    {
        AuthMessageSender EmailAuth;
        private readonly IHostingEnvironment _hostingEnvironment;
        public EmailSenderService(IHostingEnvironment hostingEnvironment)
        {
            EmailAuth = new AuthMessageSender();
            _hostingEnvironment = hostingEnvironment;
        }

        public bool SendEmail(string mEmail, string mName, string mCode, string mUserid)
        {
            System.Net.Mail.MailMessage m = new System.Net.Mail.MailMessage(
                              new System.Net.Mail.MailAddress(EmailAuth.SendUser, "FindTheGarage"),
                              new System.Net.Mail.MailAddress(mEmail));
            m.Subject = "Reset Password Request";
            var edata = PopulateBodySendEmail(mName, mCode, mUserid);
            m.Body = edata;
            m.IsBodyHtml = true;
            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.gmail.com");
            smtp.Credentials = new System.Net.NetworkCredential(EmailAuth.SendUser, EmailAuth.SendKey);
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.Send(m);
            return true;
        }


        public string PopulateBodySendEmail(string mName, string mCode, string mUserid)
        {
            string body = string.Empty;
            try
            {
                string webRootPath = _hostingEnvironment.WebRootPath;
                string Pathstring = webRootPath + "/EmailTemplates/abc.html";
                using (StreamReader reader = new StreamReader(Pathstring))
                {
                    body = reader.ReadToEnd();
                }
                body = body.Replace("*|MC_PREVIEW_TEXT|*", "Forget Email");
                body = body.Replace("*|MC:SUBJECT|*", "Confirmation");
                body = body.Replace("{name}", mName);
                body = body.Replace("{Code}", mCode);
                body = body.Replace("{user}", mUserid);
            }
            catch (Exception e)
            {
            }
            return body;
        }
    }
}
