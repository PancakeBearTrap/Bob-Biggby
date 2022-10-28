using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace RecurringEvents
{
	//The SingleEvent class models a timer which fires once at a fixed time and then is inactive.
	/// <summary>Single event represents an event which only fires once.</summary>
	public class SingleEvent : IScheduledItem
	{
		public SingleEvent(DateTime eventTime)
		{
			_EventTime = eventTime;
		}
		#region IScheduledItem Members

		public void AddEventsInInterval(DateTime Begin, DateTime End, System.Collections.ArrayList List)
		{
			if (Begin <= _EventTime && End > _EventTime)
				List.Add(_EventTime);
		}

		public DateTime NextRunTime(DateTime time, bool IncludeStartTime)
		{
			if (IncludeStartTime)
				return (_EventTime >= time) ? _EventTime : DateTime.MaxValue;
			else
				return (_EventTime > time) ? _EventTime : DateTime.MaxValue;
		}
		private DateTime _EventTime;

		#endregion
	}
}
