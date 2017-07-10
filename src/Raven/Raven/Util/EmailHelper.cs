using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raven.Util
{
    /// <summary>
    /// 
    /// </summary>
    public static class EmailHelper
    {
        /// <summary>
        /// 
        /// </summary>
        public class Authorizer
        {
            /// <summary>
            /// 
            /// </summary>
            public Encoding Encoding { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string UserName { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string Password { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public Authorizer()
            {
                Encoding = Encoding.UTF8;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fromName"></param>
        /// <param name="fromAddr"></param>
        /// <param name="toName"></param>
        /// <param name="toAddr"></param>
        /// <param name="subject"></param>
        /// <param name="message"></param>
        /// <param name="uri"></param>
        /// <param name="authorizer"></param>
        public static void Send(string fromName, string fromAddr, string toName, string toAddr, string subject, string message, Uri uri, Authorizer authorizer)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(fromName, fromAddr));
            emailMessage.To.Add(new MailboxAddress(toName, toAddr));

            emailMessage.Subject = subject;

            var part = new TextPart(MimeKit.Text.TextFormat.Plain);
            part.SetText(Encoding.UTF8, message);
            emailMessage.Body = part;

            using (var client = new SmtpClient())
            {
                client.Connect(uri);
                if (authorizer != null)
                {
                    client.Authenticate(authorizer.Encoding, authorizer.UserName, authorizer.Password);
                }
                client.Send(emailMessage);
                client.Disconnect(true);

            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fromName"></param>
        /// <param name="fromAddr"></param>
        /// <param name="toName"></param>
        /// <param name="toAddr"></param>
        /// <param name="subject"></param>
        /// <param name="message"></param>
        /// <param name="uri"></param>
        /// <param name="authorizer"></param>
        /// <returns></returns>
        public static async Task SendAsync(string fromName, string fromAddr, string toName, string toAddr, string subject, string message, Uri uri, Authorizer authorizer)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(fromName, fromAddr));
            emailMessage.To.Add(new MailboxAddress(toName, toAddr));

            emailMessage.Subject = subject;

            var part = new TextPart(MimeKit.Text.TextFormat.Plain);
            part.SetText(Encoding.UTF8, message);
            emailMessage.Body = part;

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(uri);
                if (authorizer != null)
                {
                    await client.AuthenticateAsync(authorizer.Encoding, authorizer.UserName, authorizer.Password).ConfigureAwait(false);
                }
                await client.SendAsync(emailMessage).ConfigureAwait(false);
                await client.DisconnectAsync(true).ConfigureAwait(false);

            }

        }

    }

}
