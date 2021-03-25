using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Clock clock = new Clock();
            DateTime atime = new DateTime();
            atime = DateTime.Now.AddSeconds(2);
            clock.SetAlarmTime(atime);
            clock.Start();
        }
    }
}
