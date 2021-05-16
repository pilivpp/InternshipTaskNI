using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace InternshipTask.Tests
{
   public class DateRangeTests
   {
      [Fact]
      public void StartDateInput_ShouldPass()
      {
         DateRange dateRange = new DateRange();
         var input = "01.02.2020";
         bool expected = true;

         bool actual = dateRange.StartDateInput(input);

         Assert.Equal(expected, actual);
      }

      [Fact]
      public void EndDateInput_ShouldPass()
      {
         DateRange dateRange = new DateRange();
         var input = "05.12.2021";
         bool expected = true;

         bool actual = dateRange.EndDateInput(input);

         Assert.Equal(expected, actual);
      }

      [Fact()]
      public void Range_ShouldOutputCorrectDayRange()
      {
         DateRange dateRange = new DateRange();
         string expected = "01.01-02.01.2020";
         DateTime startDate = new DateTime(2020, 01, 01);
         DateTime endDate = new DateTime(2020, 01, 02);

         string actual = dateRange.Range(startDate, endDate).ToString();

         Assert.Matches(expected, actual);
      }

      [Fact()]
      public void Range_ShouldOutputCorrectMonthRange()
      {
         DateRange dateRange = new DateRange();
         string expected = "01.01 - 02.02.2020";
         DateTime startDate = new DateTime(2020, 01, 01);
         DateTime endDate = new DateTime(2020, 02, 02);

         string actual = dateRange.Range(startDate, endDate).ToString();

         Assert.Matches(expected, actual);
      }

      [Fact()]
      public void Range_ShouldOutputCorrectYearRange()
      {
         DateRange dateRange = new DateRange();
         string expected = "01.01.2020 - 02.03.2021";
         DateTime startDate = new DateTime(2020, 01, 01);
         DateTime endDate = new DateTime(2021, 03, 02);

         string actual = dateRange.Range(startDate, endDate).ToString();

         Assert.Matches(expected, actual);
      }

      [Theory]
      [InlineData("32")]
      [InlineData("0.00.0000")]
      [InlineData("00.01.2020")]
      [InlineData("1.32.2020")]
      [InlineData("32.03.2020")]
      public void StartDateInput_ShouldNotPass(string date)
      {
         DateRange dateRange = new DateRange();
         var input = date;
         bool expected = true;

         bool actual = dateRange.StartDateInput(input);

         Assert.Equal(expected, actual);
      }

      [Fact]
      public void StartDateInput_DateTimeNowShouldNotPass()
      {
         DateRange dateRange = new DateRange();
         DateTime dateTime = new DateTime();
         dateTime = DateTime.Now;
         bool expected = true;

         bool actual = dateRange.StartDateInput(dateTime.ToString());

         Assert.Equal(expected, actual);
      }

      [Theory]
      [InlineData("312")]
      [InlineData("0.00.0000")]
      [InlineData("10.00.2020")]
      [InlineData("1.32.0000")]
      [InlineData("32.03.2020")]
      public void EndDateInput_ShouldNotPass(string date)
      {
         DateRange dateRange = new DateRange();
         var input = date;
         bool expected = true;

         bool actual = dateRange.EndDateInput(input);

         Assert.Equal(expected, actual);
      }

      [Fact()]
      public void Range_ShouldNotOutputCorrectDayRange()
      {
         DateRange dateRange = new DateRange();
         string expected = "1.01-2.03.2020";
         DateTime startDate = new DateTime(2020, 01, 01);
         DateTime endDate = new DateTime(2020, 03, 02);

         string actual = dateRange.Range(startDate, endDate).ToString();

         Assert.Matches(expected, actual);
      }

      [Fact()]
      public void Range_ShouldNotOutputCorrectMontRange()
      {
         DateRange dateRange = new DateRange();
         string expected = "01.01 - 6.3.2020";
         DateTime startDate = new DateTime(2020, 01, 01);
         DateTime endDate = new DateTime(2020, 03, 06);

         string actual = dateRange.Range(startDate, endDate).ToString();

         Assert.Matches(expected, actual);
      }

      [Fact()]
      public void Range_ShouldNotOutputCorrectYearRange()
      {
         DateRange dateRange = new DateRange();
         string expected = "1.1.2020 - 2.3.2021";
         DateTime startDate = new DateTime(2020, 01, 01);
         DateTime endDate = new DateTime(2021, 03, 02);

         string actual = dateRange.Range(startDate, endDate).ToString();

         Assert.Matches(expected, actual);
      }
   }
}
