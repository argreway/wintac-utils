using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using wintac_utils.main;
using wintac_utils.timer;

namespace wintac_utils
{
    static class WintacUtils
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            log.Info("Wintac-utils starting...");

            if (args != null && args.Length > 0)
            {
                string arg = args[0];
                if (arg == "-bg")
                {
                    log.Info("Running in back ground mode.");
                    StatsTimer st = new StatsTimer();
                    st.RunTimer();
                    Environment.Exit(0);
                }
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MainApp.initalize();

            Application.Run(MainApp.getMainForm());
        }
    }
}
