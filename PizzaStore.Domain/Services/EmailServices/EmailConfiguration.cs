﻿using PizzaStore.Domain.Interfaces;

namespace PizzaStore.Domain.Services.EmailServices
{
    public class EmailConfiguration : IEmailConfiguration
    {
        public string SmtpServer { get; set; }
        public int SmtpPort { get; set; }
        public string SmtpUsername { get; set; }
        public string SmtpPassword { get; set; }
    }
}