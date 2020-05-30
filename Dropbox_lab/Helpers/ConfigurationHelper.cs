using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace TestDropboxApi.Helpers
{
    public class ConfigurationHelper
    {
        //ref       public static string ServiceUrl => ConfigurationManager.AppSettings["serviceUrl"];

        public static string ServiceUrl => Environment.GetEnvironmentVariable("serviceUrl");
        public static string ContentServiceUrl => Environment.GetEnvironmentVariable("contentServiceUrl");
        public static string AuthorizationToken => Environment.GetEnvironmentVariable("token");
        public static string DefaultFilePath => Environment.GetEnvironmentVariable("defaultFilePath");
        public static string app_key=> Environment.GetEnvironmentVariable("app_key");
        public static string app_sec => Environment.GetEnvironmentVariable("app_sec");
        public static string code => Environment.GetEnvironmentVariable("code");

    }
}
