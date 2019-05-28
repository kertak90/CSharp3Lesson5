using MailSenderLib.Entityes;
using MailSenderLib.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MailMessage = MailSenderLib.Entityes.MailMessage;

namespace MailSenderLib.Services
{
    public class SmtpMailSenderService : IMailSenderService
    {
        public IMailSender CreateSender(Server server) => new SmtpMailSender(server.Address, server.Port, server.UseSSL, server.Login, server.Password);

    }

    internal class SmtpMailSender : IMailSender
    {
        private readonly string address;
        private readonly int port;
        private readonly bool useSSL;
        private readonly string login;
        private readonly string password;

        public SmtpMailSender(string Address, int Port, bool UseSSL, string Login, string Password)
        {
            address = Address;
            port = Port;
            useSSL = UseSSL;
            login = Login;
            password = Password;
        }
        public void Send(Entityes.MailMessage Message, Sender From, Recipient To)
        {
            using (var client = new SmtpClient(address, port){Credentials = new NetworkCredential(login, password)})
            using (var message = new System.Net.Mail.MailMessage())
            {
                message.From = new MailAddress(From.Email, From.Name);
                message.To.Add(new MailAddress(To.Email, To.Name));
                message.Subject = Message.Subject;
                message.Body = Message.Body;
            }            
        }

        public void Send(MailMessage Message, Sender From, IEnumerable<Recipient> To)
        {
            foreach (var item in To)
            {
                Send(Message, From, item);
            }
        }

        public void SendParallel(MailMessage Message, Sender From, IEnumerable<Recipient> To)
        {
            foreach (var item in To)
            {
                ThreadPool.QueueUserWorkItem(_ =>Send(Message, From, item));
            }
        }

       
    }
}
