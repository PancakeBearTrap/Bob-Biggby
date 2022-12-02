using System;
using System.Collections;

namespace RecurringEvents
{
    /* Each schedule needs to provide two similar operations in order to be scheduled. 
	 * First, return the next time they will fire after a particular time. 
	 * This is used by the timer to figure out how long to wait before the next event. 
	 * Second, find all the events that are fired in a particular time interval. 
	 * This is used to call all the proper events when the timer goes off. 
	 * This is represented in the IScheduledItem interface.
	 */

    public interface IScheduledItem
    {
        /// <summary>
        /// Returns the times of the events that occur in the given time interval.  The interval is closed
        /// at the start and open at the end so that intervals can be stacked without overlapping.
        /// </summary>
        /// <param name="Begin">The beginning of the interval</param>
        /// <param name="End">The end of the interval</param>
        /// <returns>All events >= Begin and &lt; End </returns> 

        void AddEventsInInterval(DateTime Begin, DateTime End, ArrayList List);

        /// <summary>
        /// Returns the next run time of the scheduled item.  Optionally excludes the starting time.
        /// </summary>
        /// <param name="time">The starting time of the interval</param>
        /// <param name="IncludeStartTime">if true then the starting time is included in the query false, it is excluded.</param>
        /// <returns>The next execution time either on or after the starting time.</returns>

        DateTime NextRunTime(DateTime time, bool IncludeStartTime);
    }
}
