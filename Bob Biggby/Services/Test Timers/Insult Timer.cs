using System;
using System.Collections;

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
