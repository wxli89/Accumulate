using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network
{
    public class ConfigRead
    {
        public static string Read(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}
