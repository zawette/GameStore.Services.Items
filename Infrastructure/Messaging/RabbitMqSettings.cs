using System;

namespace Infrastructure.Messaging
{
    public class RabbitMqSettings
    {
        public string username { get; set; }
        public string password { get; set; }
        public string host { get; set; } 
        public string queue { get; set; }
    }
}
