using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesStopWatch
{
    public class StopWatch
    {
        public DateTime? TimeStart { get; set; }
        public TimeSpan? TimeDifference { get; set; }
        public void Start()
        {
            if (TimeStart != null)
            {
                throw new InvalidOperationException("Nie można uruchamiać stopera, który jest już uruchomiony");
            }

            TimeStart = DateTime.Now;
        }
        public void Stop()
        {
            if (TimeStart == null)
            {
                throw new InvalidOperationException("Nie można zatrzymać stopera, który nie jest uruchomiony");
            }

            TimeDifference = DateTime.Now - TimeStart;
            TimeStart = null;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            StopWatch stopWatch = new();
            Console.WriteLine("This is a stopwatch.\n");
            Console.WriteLine("Commands: \n'start' - run stopwatch\n'stop' - stop stopwatch\n'end' - close program");

            if (args.Length > 0 && args[0] == "autostart")
            {
                stopWatch.Start();
            }

            while (true)
            {
                try
                {
                    var command = Console.ReadLine().ToLower().Trim();

                    switch (command)
                    {
                        case "start":
                            stopWatch.Start();
                            Console.WriteLine(stopWatch.TimeStart);
                            break;
                        case "stop":
                            stopWatch.Stop();
                            Console.WriteLine(stopWatch.TimeDifference);
                            break;
                        case "end":
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Nie obslugiwana komenda");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}