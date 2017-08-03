using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace DesafioWhois.Helpers
{
    public static class MongoConfig
    {
        public static string Url => ConfigurationManager.AppSettings["MongoUrl"];
        public static string DbName => ConfigurationManager.AppSettings["MongoDb"];
        public static string Collection => ConfigurationManager.AppSettings["MongoCollection"];
    }
}