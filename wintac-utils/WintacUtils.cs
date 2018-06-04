using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
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
            bool isConsole = true;

            try
            {
                if (Environment.UserInteractive)
                    log.Info("Starting console application...");
                else
                    isConsole = false;
            }
            catch (Exception e)
            {
                isConsole = false;
            }

            MainApp.SetConsole(isConsole);
            MainApp.initalizeService();

            if (!isConsole)
            {
                log.Info("Running in service mode.");
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[]
                      {
                        new WintacUtilsService()
                      };
                ServiceBase.Run(ServicesToRun);
                return;
            }

            log.Info("Running windows form mode.");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MainApp.initalizeForms();

            Application.Run(MainApp.getMainForm());
        }
    }
}
