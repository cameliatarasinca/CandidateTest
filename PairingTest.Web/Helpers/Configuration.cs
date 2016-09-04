using System;
using System.Collections.Generic;
using System.Configuration;
using System.Configuration.Internal;
using System.Linq;
using System.Web;
using PairingTest.Web.Interfaces;

namespace PairingTest.Web.Helpers
{
    public class Configuration : IConfiguration
    {
        public string Url
        {
            get { return ConfigurationManager.AppSettings["QuestionnaireServiceUri"]; }
        }
    }
}