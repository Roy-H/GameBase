using farmbase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameBaseTest
{
    class Program
    {
        static void Main(string[] args)
        {
            ManagersHolder.Instance.RegisterAllManagers();
            TimeManager.Instace.Start();
            TimeManager.Instace.ShowTime += Instace_ShowTime;
            TimeManager.Instace.SpendDay += Instace_SpendDay;
            TimeManager.Instace.StartFromTime(new Time(2,3,23,5));
            Console.ReadKey();

        }

        private static void Instace_SpendDay(TimeManager holder, Time time)
        {
            Console.WriteLine("one day passed");
        }

        private static void Instace_ShowTime(TimeManager holder, Time time)
        {

            Console.WriteLine("Day:{0},time:{1:D2}:{2:D2}",time.Day, time.Hour, time.Min);
        }
    }
}
