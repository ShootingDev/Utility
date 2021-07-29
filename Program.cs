using System;
using System.Data;
using System.Diagnostics;
using System.Threading;

namespace Utility
{
    class Program
    {
        static void CheckIfProcessIsRunning(string processName, int comparer)
        {
            foreach (Process clsProcess in Process.GetProcesses())
            {
                if (clsProcess.ProcessName.Contains(processName))
                {
                    long lifeTime = clsProcess.StartTime.Ticks;

                    Console.WriteLine(DateTime.Now.Ticks - TimeSpan.FromTicks(lifeTime).TotalMinutes);

                    if (TimeSpan.FromTicks(DateTime.Now.Ticks - lifeTime).TotalMinutes >= comparer)
                    {
                        clsProcess.Kill();
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            var line = Console.ReadLine();

            var data = line.Split(' ');

            string proc_name = data[0];

            int comp = int.Parse(data[1]);

            int sleep = int.Parse(data[2]);

            TimeSpan interval = new TimeSpan(0, sleep, 0);

            while (true)
            {
                CheckIfProcessIsRunning(proc_name, comp);

                Thread.Sleep(interval);
            }
        }
    }
}
