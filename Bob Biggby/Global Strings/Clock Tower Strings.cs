using System;

namespace GlobalStrings
{
    public class TimeKeeper
    {
        public static DateTime Today()
        {
            //Day of week, mm/dd/yyyy, hh:mm:ss
            var Today = GlobalShortcuts.TimeSwitch.TimeKeeper(GlobalEnums.Watch.today);
            return Today;
        }

        public static DateTime CurrentTime()
        {
            //long time hh:mm:ss
            var CurrentTime = GlobalShortcuts.TimeSwitch.TimeKeeper(GlobalEnums.Watch.currentTime);
            return CurrentTime;
        }

        public static DateTime Day_Time()
        {
            //dd/mm/yyyy, h:mm:ss
            var day_time = GlobalShortcuts.TimeSwitch.TimeKeeper(GlobalEnums.Watch.day_time);
            return day_time;
        }

        public static DateTime DayOfWeek()
        {
            //day of week full (ie "Monday")
            var dayofWeek = GlobalShortcuts.TimeSwitch.TimeKeeper(GlobalEnums.Watch.day_of_week);
            return dayofWeek;
        }

        public static DateTime MonthDay()
        {
            //month and date
            var monthDay = GlobalShortcuts.TimeSwitch.TimeKeeper(GlobalEnums.Watch.monthDay);
            return monthDay;
        }

        public static DateTime YearMonth()
        {
            //month and year
            var yearMonth = GlobalShortcuts.TimeSwitch.TimeKeeper(GlobalEnums.Watch.yearMonth);
            return yearMonth;
        }

        public void TimeStamp()
        {

        }
    }
}