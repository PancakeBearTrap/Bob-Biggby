using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;

namespace RecurringEvents
{
    internal class RecurringTimer
    {
        public interface IScheduledItem
        {
            void AddEventsInInterval(DateTime Begin, DateTime End, ArrayList List);
            DateTime NextRunTime(DateTime time);
        }
    }
}
