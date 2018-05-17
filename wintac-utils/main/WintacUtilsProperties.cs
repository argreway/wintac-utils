using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wintac_utils.main
{
    class WintacUtilsProperties
    {
        protected static String confgFile = "C:\\wintac-utils.properties";
        protected Dictionary<String, String> properties;

        protected bool init = false;

        //////// Properties ///////
        protected static String DATABASE = "database";
        protected static String SERVER = "server";
        protected static String USER = "user";
        protected static String PASSWORD = "password";

        public WintacUtilsProperties()
        {
            properties = new Dictionary<string, string>();
            if (!File.Exists(confgFile))
            {
                MessageBox.Show("No configuration file found at " + confgFile + " !");
                return;
            }

            foreach (var row in File.ReadAllLines(confgFile))
                properties.Add(row.Split('=')[0], string.Join("=", row.Split('=').Skip(1).ToArray()));
            init = true;
        }

        ///////////////////////////

        public String getDatabase() { if (!init) return ""; return properties[DATABASE]; }
        public String getServer() { if (!init) return ""; return properties[SERVER]; }
        public String getUser() { if (!init) return ""; return properties[USER]; }
        public String getPassword() { if (!init) return ""; return properties[PASSWORD]; }

    }
}
