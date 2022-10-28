using System;

public static class MyScheduler
{
    public static void IntervalInSeconds(int hour, int sec, double interval, Action task)
    {
        interval /= 3600;
        SchedulerService.Instance.ScheduleTask(hour, sec, interval, task);
    }

    public static void IntervalInMinutes(int hour, int min, double interval, Action task)
    {
        interval /= 60;
        SchedulerService.Instance.ScheduleTask(hour, min, interval, task);
    }

    public static void IntervalInHours(int hour, int min, double interval, Action task)
    {
        SchedulerService.Instance.ScheduleTask(hour, min, interval, task);
    }

    public static void IntervalInDays(int hour, int min, double interval, Action task)
    {
        interval *= 24;
        SchedulerService.Instance.ScheduleTask(hour, min, interval, task);
    }

    public static void IntervalInWeeks(int hour, int min, double interval, Action task)
    {
        interval *= 168;
        SchedulerService.Instance.ScheduleTask(hour, min, interval, task);
    }

    public static void IntervalInMonths(int hour, int min, double interval, Action task)
    {
        //Sets the current time and date to var "now"
        DateTime now = DateTime.Now;
        var numDays = DateTime.DaysInMonth(now.Year, now.Month);

        //For February, non leap year
        if (numDays == 28)
        {
            interval *= 672;
            SchedulerService.Instance.ScheduleTask(hour, min, interval, task);
        }

        //For February, leap year
        else if (numDays == 29)
        {
            interval *= 696;
            SchedulerService.Instance.ScheduleTask(hour, min, interval, task);
        }

        //For months with 30 days
        else if (numDays == 30)
        {
            interval *= 720;
            SchedulerService.Instance.ScheduleTask(hour, min, interval, task);
        }

        //for months with 31 days
        else if (numDays == 31)
        {
            interval *= 744;
            SchedulerService.Instance.ScheduleTask(hour, min, interval, task);
        }
    }
}