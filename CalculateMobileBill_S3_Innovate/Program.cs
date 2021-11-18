using System;
using System.Collections.Generic;
using System.Linq;

namespace CalculateMobileBill_S3_Innovate
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> arr = null;
            //for (int i =0; i<2;i++)
            //{
            //   arr  = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToString(arrTemp)).ToList();
            //}

            string startTime = Console.ReadLine();
            string endTime = Console.ReadLine();

            CalculateBill(startTime, endTime);
            
        }

        public static double CalculateBill(string startTime, string endTime)
        {
            long pickHour1 = DateTime.Parse("09:00:00 am").Ticks;
            
            long pickHour2 = DateTime.Parse("10:59:59 pm").Ticks;

            long offPickHour1 = DateTime.Parse("12:00:00 am").Ticks;
            long offPickHour2 = DateTime.Parse("08:59:59 am").Ticks;
            long offPickHour3 = DateTime.Parse("11:00:00 pm").Ticks;
            long offPickHour4 = DateTime.Parse("11:59:59 pm").Ticks;

            DateTime starthour = DateTime.Parse(startTime);
            DateTime endhour = DateTime.Parse(endTime);
             

            double sum = 0;

            for (int i= 0; starthour.Ticks <= endhour.Ticks; i++)
            {
                if (pickHour1 < starthour.Ticks && pickHour2 > endhour.Ticks)
                {
                    sum += 30;
                    
                }
                else if ((offPickHour1< starthour.Ticks && offPickHour2< endhour.Ticks) || (offPickHour3 < starthour.Ticks && offPickHour4 > endhour.Ticks)) {
                    sum += 20;
                }

              starthour =  starthour.AddSeconds(20);


            }
            Console.WriteLine($" Output: {sum/100} Taka");
            return sum;
        }
    }
}
