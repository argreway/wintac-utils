using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using wintac_utils.main;

namespace wintac_utils
{
    static class WintacUtils
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MainApp.initalize();

            Application.Run(MainApp.getMainForm());
        }
    }
}
