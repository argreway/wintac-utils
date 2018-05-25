using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using wintac_utils.wip;

namespace wintac_utils.timer
{
    class StatsTimer
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        StateObjClass StateObj = new StateObjClass();

        private class StateObjClass
        {
            public System.Threading.Timer TimerReference;
            public bool TimerCanceled;
        }

        long delay = 900000;
        long interval = 43200000;

        public void RunTimer()
        {
            StateObj.TimerCanceled = false;

            System.Threading.TimerCallback TimerDelegate =
                new System.Threading.TimerCallback(TimerTask);

            // Start timer run every 12 hours
            log.Info("Starting timer with delay: " + delay + ", interval: " + interval);
            System.Threading.Timer TimerItem =
                    new System.Threading.Timer(TimerDelegate, StateObj, delay, interval);

            StateObj.TimerReference = TimerItem;

            //System.Threading.Thread.Sleep(1000000000);
        }

        public void CancelTimer()
        {
            StateObjClass State = (StateObjClass)StateObj;
            State.TimerReference.Dispose();
            log.Info("Disposed of timer.");
        }

        private void TimerTask(object StateObj)
        {
            log.Info("Timer fired updating stats...");
            WIPUtils.insertAllStats();
        }

    }
}
