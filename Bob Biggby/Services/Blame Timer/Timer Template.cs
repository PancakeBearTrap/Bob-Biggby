﻿using System;
using System.Threading;

namespace GlobalServices
{
    class TimerTemplate
    {
        public static void ExampleTimer()
        {
            /* Create an AutoResetEvent to signal the timeout threshold in the
             * timer callback has been reached.
             */
            var autoEvent = new AutoResetEvent(false);

            var statusChecker = new StatusChecker(10);

            /* Create a timer that invokes CheckStatus after one second, 
             * and every 1/4 second thereafter.
             */
            Console.WriteLine("{0:h:mm:ss.fff} Creating timer.\n", DateTime.Now);
            var stateTimer = new Timer(statusChecker.CheckStatus, autoEvent, 1000, 250);

            // When autoEvent signals, change the period to every half second.
            autoEvent.WaitOne();
            stateTimer.Change(0, 500);
            Console.WriteLine("\nChanging period to .5 seconds.\n");

            // When autoEvent signals the second time, dispose of the timer.
            autoEvent.WaitOne();
            stateTimer.Dispose();
            Console.WriteLine("\nDestroying timer.\n");
        }
    }

    public class StatusCheckerTemplate

    {
        public static int invokeCount;
        public static int maxCount;

        public StatusCheckerTemplate(int count)
        {
            invokeCount = 0;
            maxCount = count;
        }

        // This method is called by the timer delegate.
        public void CheckStatus(Object stateInfo)
        {
            AutoResetEvent autoEvent = (AutoResetEvent)stateInfo;
            Console.WriteLine("{0} Checking status {1,2}.", DateTime.Now.ToString("h:mm:ss.fff"), (++invokeCount).ToString());

            if (invokeCount == maxCount)
            {
                // Reset the counter and signal the waiting thread.
                invokeCount = 0;
                autoEvent.Set();
            }
        }
    }
}
