using System;

namespace InternshipTask
{
   class Program
   {
      static void Main(string[] args)
      {
         DateRange dateRange = new DateRange();

         bool correctInput = true;

         Console.WriteLine("This program prints data range of given dates\n");
         Console.WriteLine("Start date: ");

         while (correctInput)
         {
            bool success = dateRange.StartDateInput(Console.ReadLine());

            if (success == true)
            {
               break;
            }
         }

         Console.WriteLine("\nEnd date: ");

         while (correctInput)
         {
            bool success = dateRange.EndDateInput(Console.ReadLine());

            if (success == true && dateRange.startDate < dateRange.endDate)
            {
               break;
            }
         }

         string result = dateRange.Range(dateRange.startDate, dateRange.endDate);

         Console.WriteLine("\n" + result);
      }
   }
}
