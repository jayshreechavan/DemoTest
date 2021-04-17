using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoTest.DAL
{
    static class AppConfiguration
    {
        public static string ConnectionString
        {
            get
            {
               
                return System.Configuration.ConfigurationManager.ConnectionStrings["ApplicationCon"].ConnectionString.ToString();               
            }
        }
        public static string BaseURL
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["BaseURL"].ToString();
            }
        }
    }

}
