using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Configuration
{
    public class EmailConfig
    {
        public string SmtpServer { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
