﻿using MailSenderLib.Entityes.Base;

namespace MailSenderLib.Entityes
{
    public class Server : NamedEntity
    {     
        public string Address { get; set; }

        public int Port { get; set; }

        public bool UseSSL { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }
    }
}
