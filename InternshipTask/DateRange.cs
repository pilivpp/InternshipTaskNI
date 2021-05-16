using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternshipTask
{
   public class DateRange
   {
      public DateTime startDate = new DateTime();
      public DateTime endDate = new DateTime();

      public bool StartDateInput(string input)
      {
         bool inputResult = DateTime.TryParseExact(input, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal, out startDate);

         if (inputResult == true)
         {
            if (startDate < DateTime.Now)
            {
               Console.WriteLine("Valid format");
            }
            else
               Console.WriteLine("Start date must be less than today's date");
         }
         else
            Console.WriteLine("Invalid format. Example of correct format date: 01.01.2020");

         return inputResult;
      }
      public bool EndDateInput(string input)
      {
         bool inputResult = DateTime.TryParseExact(input, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal, out endDate);

         if (inputResult == true)
         {
            if (startDate < endDate)
            {
               Console.WriteLine("Valid format");
            }
            else
               Console.WriteLine("End date must be greater than start day");
         }
         else
            Console.WriteLine("Invalid format. Example of correct format date: 01.01.2020");

         return inputResult;
      }

      public string Range(DateTime startDate, DateTime endDate)
      {
         string result = "";

         if (startDate.Year == endDate.Year && startDate.Month == endDate.Month)
         {
            result = string.Format($"Range: {startDate.ToString("dd.MM")}-{endDate.ToString("dd.MM.yyyy")}");
         }
         else if (startDate.Year == endDate.Year && startDate.Month != endDate.Month)
         {
            result = string.Format($"Range: {startDate.ToString("dd.MM")} - {endDate.ToString("dd.MM.yyyy")}");
         }
         else if (startDate.Year != endDate.Year)
         {
            result = string.Format($"Range: {startDate.ToString("dd.MM.yyyy")} - {endDate.ToString("dd.MM.yyyy")}");
         }

         return result;
      }
   }
}
