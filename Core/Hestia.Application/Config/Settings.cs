using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hestia.Application.Config
{
    public class Settings
    {
        public Settings AppSettings { get; set; }
        public DatabaseSettings DatabaseSettings { get; set; }
        public BrokerSettings BrokerSettings { get; set; }
    }

    public class AppSettings
    {
        public string AppSecret { get; set; }
        public List<Application> Applications { get; set; }
    }

    public class Application
    {
        public string ApplicationName { get; set; }
        public string ApplicationId { get; set; }
    }

    public class DatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public class BrokerSettings
    {
        public string Host { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
