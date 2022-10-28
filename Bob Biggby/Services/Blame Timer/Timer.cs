using System;
using System.Timers;


namespace GlobalServices
{
    public class Timers
    {
        //Timer
        public static Timer TheTimeKeper;
        public static int timerCount;

        public class TestTimerTemplate
        {
            public static void TestTImerTemplate()
            {
                SetTimerTemplate();

                Console.WriteLine("\nPress the Enter key to exit the application...\n");
                Console.WriteLine("The application started at {0:HH:mm:ss.fff}", DateTime.Now);
                Console.ReadLine();
                TheTimeKeper.Stop();
                TheTimeKeper.Dispose();

                Console.WriteLine("Terminating the application...");
            }

            static void SetTimerTemplate()
            {
                // Create a timer with a 5 minute interval.
                TheTimeKeper = new Timer(2000);

                // Hook up the Elapsed event for the timer. 
                TheTimeKeper.Elapsed += OnTimedEvent;

                TheTimeKeper.AutoReset = true;
                TheTimeKeper.Enabled = true;
            }

            static void OnTimedEvent(Object source, ElapsedEventArgs e)
            {
                timerCount++;
                Console.WriteLine("The Elapsed event was raised at {0:HH:mm:ss.fff}", e.SignalTime);
                Console.WriteLine($"timer count is {timerCount}\n");
            }
        }

        public class TestTimerClass
        {
            public static void TestTImer()
            {
                SetTimer();

                Console.WriteLine("\nPress the Enter key to exit the application...\n");
                Console.WriteLine("The application started at {0:HH:mm:ss.fff}", DateTime.Now);
                Console.ReadLine();
                TheTimeKeper.Stop();
                TheTimeKeper.Dispose();

                Console.WriteLine("Terminating the application...");
            }

            static void SetTimer()
            {
                // Create a timer with a 5 minute interval.
                TheTimeKeper = new Timer(2000);

                // Hook up the Elapsed event for the timer. 
                TheTimeKeper.Elapsed += OnTimedEvent;

                TheTimeKeper.AutoReset = true;
                TheTimeKeper.Enabled = true;
            }

            static void OnTimedEvent(Object source, ElapsedEventArgs e)
            {
                timerCount++;
                Console.WriteLine("The Elapsed event was raised at {0:HH:mm:ss.fff}", e.SignalTime);
                Console.WriteLine($"timer count is {timerCount}\n");
            }
        }

        public class TimerForBlaming
        {
            public static void BlameTimer()
            {
                SetTimer();

                Console.WriteLine("\nPress the Enter key to exit the application...\n");
                Console.WriteLine("The application started at {0:HH:mm:ss.fff}", DateTime.Now);
                Console.ReadLine();
                TheTimeKeper.Stop();
                TheTimeKeper.Dispose();

                Console.WriteLine("Terminating the application...");
            }

            static void SetTimer()
            {
                // Create a timer with a 5 minute interval.
                TheTimeKeper = new System.Timers.Timer(300000);

                // Hook up the Elapsed event for the timer. 
                TheTimeKeper.Elapsed += OnTimedEvent;
                TheTimeKeper.AutoReset = true;
                TheTimeKeper.Enabled = true;
            }

            static void OnTimedEvent(Object source, ElapsedEventArgs e)
            {
                timerCount++;
                Console.WriteLine("The Elapsed event was raised at {0:HH:mm:ss.fff}", e.SignalTime);
                Console.WriteLine($"timer count is {timerCount}\n");
            }
        }
    }
}
