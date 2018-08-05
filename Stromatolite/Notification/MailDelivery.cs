using Stromatolite.DAL;
using Stromatolite.Errors;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Configuration;
using System.Net.Mail;
using System.Web;

namespace Stromatolite
{
    public static class MailDelivery
    {
        public static void MailSend(string email, string subject, string body, string attachment)
        {
            SmtpSection smtp = ConfigurationManager.GetSection("system.net/mailSettings/smtp") as SmtpSection;
            Message msg = new Message();
            msg.From = smtp.From;
            msg.To = email;
            msg.Subject = subject;
            msg.Body = body;
            SmtpMessageDelivery mail = new SmtpMessageDelivery(true);
            mail.Send(msg, attachment);

        }

        public static void MailSend(string email, string subject, string body)
        {
            SmtpSection smtp = ConfigurationManager.GetSection("system.net/mailSettings/smtp") as SmtpSection;
            Message msg = new Message();
            msg.From = smtp.From;
            msg.To = email;
            msg.Subject = subject;
            msg.Body = body;
            SmtpMessageDelivery mail = new SmtpMessageDelivery(true);
            mail.Send(msg);

        }
    }

    public class Message
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }

    public class SmtpMessageDelivery 
    {
        private ErrLog Err = new ErrLog();
        public bool SendAsHtml { get; set; }
        public int SmtpTimeout { get; set; }

        public SmtpMessageDelivery(bool sendAsHtml = false, int smtpTimeout = 5000)
        {
            this.SendAsHtml = sendAsHtml;
            this.SmtpTimeout = smtpTimeout;
        }

        public void Send(Message msg, string nameAttachment)
        {

            if (String.IsNullOrWhiteSpace(msg.From))
            {
                SmtpSection smtp = ConfigurationManager.GetSection("system.net/mailSettings/smtp") as SmtpSection;
                msg.From = smtp.From;
            }

            using (SmtpClient smtp = new SmtpClient())
            {
                smtp.Timeout = SmtpTimeout;
                try
                {
                    MailMessage mailMessage = new MailMessage(msg.From, msg.To, msg.Subject, msg.Body)
                    {
                        IsBodyHtml = SendAsHtml
                    };
                    
                    mailMessage.Attachments.Add(new Attachment(nameAttachment));
                    smtp.Send(mailMessage);
                }
                catch (SmtpException e)
                {
                    Err.Log("SmtpException <br />" + e.Message + "<br />" + e.InnerException + "<br />" + e.StackTrace);
                    //Tracing.Error("[SmtpMessageDelivery.Send] SmtpException: " + e.Message);
                }
                catch (Exception e)
                {
                    Err.Log(e.Message + "<br />" + e.InnerException + "<br />" + e.StackTrace);
                    //Tracing.Error("[SmtpMessageDelivery.Send] Exception: " + e.Message);
                }
            }
        }

        public void Send(Message msg)
        {

            if (String.IsNullOrWhiteSpace(msg.From))
            {
                SmtpSection smtp = ConfigurationManager.GetSection("system.net/mailSettings/smtp") as SmtpSection;
                msg.From = smtp.From;
            }

            using (SmtpClient smtp = new SmtpClient())
            {
                smtp.Timeout = SmtpTimeout;
                try
                {
                    MailMessage mailMessage = new MailMessage(msg.From, msg.To, msg.Subject, msg.Body)
                    {
                        IsBodyHtml = SendAsHtml
                    };

                    smtp.Send(mailMessage);
                }
                catch (SmtpException e)
                {
                    Err.Log("SmtpException <br />" + e.Message + "<br />" + e.InnerException + "<br />" + e.StackTrace);
                    //Tracing.Error("[SmtpMessageDelivery.Send] SmtpException: " + e.Message);
                }
                catch (Exception e)
                {
                    Err.Log(e.Message + "<br />" + e.InnerException + "<br />" + e.StackTrace);
                    //Tracing.Error("[SmtpMessageDelivery.Send] Exception: " + e.Message);
                }
            }
        }

    }


}