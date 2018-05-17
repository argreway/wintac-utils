using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wintac_utils.dbconnect;

namespace wintac_utils.main
{
    class MainApp
    {
        protected static DBConnection dbConnection;
        protected static MainForm mainForm;
        protected static SearchBox boxForm;
        protected static WintacUtilsProperties utilsProperties;

        public static void initalize()
        {
            utilsProperties = new WintacUtilsProperties();
            dbConnection = new DBConnection();
            mainForm = new MainForm();
            boxForm = new SearchBox();
        }

        public static DBConnection GetDBConnection()
        {
            return dbConnection;
        }

        public static MainForm getMainForm()
        {
            return mainForm;
        }

        public static SearchBox GetSearchBox()
        {
            return boxForm;
        }

        public static WintacUtilsProperties getProperties()
        {
            return utilsProperties;
        }
    }
}
