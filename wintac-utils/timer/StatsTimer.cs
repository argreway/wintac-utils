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

        private class StateObjClass
        {
            // Used to hold parameters for calls to TimerTask.  
            public int SomeValue;
            public System.Threading.Timer TimerReference;
            public bool TimerCanceled;
        }

        public void RunTimer()
        {
            StateObjClass StateObj = new StateObjClass();
            StateObj.TimerCanceled = false;
            StateObj.SomeValue = 1;
            System.Threading.TimerCallback TimerDelegate =
                new System.Threading.TimerCallback(TimerTask);

            System.Threading.Timer TimerItem =
                new System.Threading.Timer(TimerDelegate, StateObj, 43200000, 43200000);

            // Save a reference for Dispose.  
            StateObj.TimerReference = TimerItem;

            System.Threading.Thread.Sleep(1000000000);

            StateObj.TimerCanceled = true;
        }

        private void TimerTask(object StateObj)
        {
            StateObjClass State = (StateObjClass)StateObj;

            log.Info("Timer fired updating stats...");
            //WIPUtils.insertAllStats();

            if (State.TimerCanceled)
            {
                State.TimerReference.Dispose();
                System.Diagnostics.Debug.WriteLine("Done  " + DateTime.Now.ToString());
            }
        }

    }
}
