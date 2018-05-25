using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using wintac_utils.timer;

namespace wintac_utils
{
    partial class WintacUtilsService : ServiceBase
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected StatsTimer st = new StatsTimer();

        public WintacUtilsService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            log.Info("Starting wintac-utils service.");
            st.RunTimer();
        }

        protected override void OnStop()
        {
            log.Info("Stopping wintac-utils service.");
            st.CancelTimer();
        }
    }
}
