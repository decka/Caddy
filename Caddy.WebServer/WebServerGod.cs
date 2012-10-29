using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Caddy.Server;
using Caddy.Domain.Abstract;
using Caddy.Domain.Concrete;
using Caddy.Domain.Entities;

namespace Caddy.WebServer
{
    class WebServerGod
    {
        private static WebServerGod WebServerGodInstance = new WebServerGod();

        public  ServerGod ServerGodInstance { get; set; }
        private WebServerGod() 
        { 
            ServerGodInstance = new ServerGod();
        }
        
        public static WebServerGod GetWebServerGod()
        {
            return WebServerGodInstance;
        }
    }
}