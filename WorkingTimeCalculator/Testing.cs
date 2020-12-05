using System;
using System.Collections.Generic;
using System.Text;
using CsvHelper;
using System.Linq;
using System.IO;
using System.Globalization;

namespace WorkingTimeCalculator
{
    class Testing
    {
		public static void UnitTest()
        {
			// read holiday data
			// please change csv file path
			var reader = new StreamReader(@"~\WorkingTimeCalculator\HolidayTW.csv", Encoding.Default);
			var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

			var records = csv.GetRecords<HolidayTWModel>().ToList();

			Testing1(records);
			Testing2(records);
			Testing3(records);
			Testing4(records);
			Testing5(records);
			Testing6(records);
			Testing7(records);
			Testing8(records);
			Testing9(records);
			Testing10(records);
			Testing11(records);
			Testing12(records);
			Testing13(records);
			Testing14(records);
		}
		
		// Display all compute
		private static void display(IEnumerable<HolidayTWModel> records, DateTime startDate, DateTime endDate)
		{
			Console.WriteLine(startDate + " " + startDate.DayOfWeek);
			Console.WriteLine(endDate + " " + endDate.DayOfWeek);

			Console.WriteLine();

			Console.WriteLine("Day");
			Console.WriteLine(TotalTime.totalDays(startDate, endDate) + " Total Day");
			Console.WriteLine(TotalTime.totalWorkingDay(records, startDate, endDate) + " Working Days");
			Console.WriteLine(TotalTime.totalHoliday(records, startDate, endDate) + " Days Off");

			Console.WriteLine();

			Console.WriteLine("Hour");
			Console.WriteLine(TotalTime.totalHours(startDate, endDate) + " Total Hour");
			Console.WriteLine(TotalTime.totalWorkingHours(records, startDate, endDate) + " Working Hours");
			Console.WriteLine(TotalTime.totalHolidayHours(records, startDate, endDate) + " Holiday Hour");

			Console.WriteLine();

			Console.WriteLine("Verify : " + (endDate - startDate).TotalHours + " Hours");

			Console.WriteLine();
		}

		public static void Testing1(IEnumerable<HolidayTWModel> records)
		{
			Console.WriteLine("Testing 1 : Weekend 1");

			Console.WriteLine();

			DateTime startDate = new DateTime(2020, 11, 20, 9, 0, 0);
			DateTime endDate = new DateTime(2020, 11, 23, 10, 0, 0);

			//display(records, startDate, endDate);

			double result = TotalTime.totalWorkingHours(records, startDate, endDate);

			if (result == 9)
			{
				Console.WriteLine("True");
			}
			else
			{
				Console.WriteLine($"False, Result: {result}, Answer: 9");
			}

			Console.WriteLine();

			Console.WriteLine("-------------------------------");

			Console.WriteLine();
		}

		public static void Testing2(IEnumerable<HolidayTWModel> records)
		{
			Console.WriteLine("Testing 2 : Weekend 2");

			Console.WriteLine();

			DateTime startDate = new DateTime(2020, 11, 20, 18, 0, 0);
			DateTime endDate = new DateTime(2020, 11, 23, 10, 0, 0);

			//display(records, startDate, endDate);

			double result = TotalTime.totalWorkingHours(records, startDate, endDate);

			if (result == 1)
			{
				Console.WriteLine("True");
			}
			else
			{
				Console.WriteLine($"False, Result: {result}, Answer: 1");
			}

			Console.WriteLine();

			Console.WriteLine("-------------------------------");

			Console.WriteLine();
		}

		public static void Testing3(IEnumerable<HolidayTWModel> records)
		{
			Console.WriteLine("Testing 3 : Weekend 3");

			Console.WriteLine();

			DateTime startDate = new DateTime(2020, 11, 21, 9, 0, 0);
			DateTime endDate = new DateTime(2020, 11, 23, 10, 0, 0);

			//display(records, startDate, endDate);

			double result = TotalTime.totalWorkingHours(records, startDate, endDate);

			if (result == 1)
			{
				Console.WriteLine("True");
			}
			else
			{
				Console.WriteLine($"False, Result: {result}, Answer: 1");
			}

			Console.WriteLine();

			Console.WriteLine("-------------------------------");

			Console.WriteLine();
		}

		public static void Testing4(IEnumerable<HolidayTWModel> records)
		{
			Console.WriteLine("Testing 4 : Weekday");

			Console.WriteLine();

			DateTime startDate = new DateTime(2020, 11, 16, 9, 0, 0);
			DateTime endDate = new DateTime(2020, 11, 20, 18, 0, 0);

			//display(records, startDate, endDate);

			double result = TotalTime.totalWorkingHours(records, startDate, endDate);

			if (result == 40)
			{
				Console.WriteLine("True");
			}
			else
			{
				Console.WriteLine($"False, Result: {result}, Answer: 40");
			}

			Console.WriteLine();

			Console.WriteLine("-------------------------------");

			Console.WriteLine();
		}

		public static void Testing5(IEnumerable<HolidayTWModel> records)
		{
			Console.WriteLine("Testing 5 : Holiday");

			Console.WriteLine();

			DateTime startDate = new DateTime(2020, 10, 5, 9, 0, 0);
			DateTime endDate = new DateTime(2020, 10, 12, 18, 0, 0);

			//display(records, startDate, endDate);

			double result = TotalTime.totalWorkingHours(records, startDate, endDate);

			if (result == 40)
			{
				Console.WriteLine("True");
			}
			else
			{
				Console.WriteLine($"False, Result: {result}, Answer: 40");
			}

			Console.WriteLine();

			Console.WriteLine("-------------------------------");

			Console.WriteLine();
		}

		public static void Testing6(IEnumerable<HolidayTWModel> records)
		{
			Console.WriteLine("Testing 6 : 2 Weekend");

			Console.WriteLine();

			DateTime startDate = new DateTime(2020, 11, 13, 9, 0, 0);
			DateTime endDate = new DateTime(2020, 11, 23, 18, 0, 0);

			//display(records, startDate, endDate);

			double result = TotalTime.totalWorkingHours(records, startDate, endDate);

			if (result == 56)
			{
				Console.WriteLine("True");
			}
			else
			{
				Console.WriteLine($"False, Result: {result}, Answer: 56");
			}

			Console.WriteLine();

			Console.WriteLine("-------------------------------");

			Console.WriteLine();
		}

		public static void Testing7(IEnumerable<HolidayTWModel> records)
		{
			Console.WriteLine("Testing 7 : 2 Weekend + Holiday");

			Console.WriteLine();

			DateTime startDate = new DateTime(2020, 9, 30, 9, 0, 0);
			DateTime endDate = new DateTime(2020, 10, 12, 18, 0, 0);

			//display(records, startDate, endDate);

			double result = TotalTime.totalWorkingHours(records, startDate, endDate);

			if (result == 48)
			{
				Console.WriteLine("True");
			}
			else
			{
				Console.WriteLine($"False, Result: {result}, Answer: 48");
			}

			Console.WriteLine();

			Console.WriteLine("-------------------------------");

			Console.WriteLine();
		}

		public static void Testing8(IEnumerable<HolidayTWModel> records)
		{
			Console.WriteLine("Testing 8 : One Day 1");

			Console.WriteLine();

			DateTime startDate = new DateTime(2020, 11, 20, 9, 0, 0);
			DateTime endDate = new DateTime(2020, 11, 20, 18, 0, 0);

			//display(records, startDate, endDate);

			double result = TotalTime.totalWorkingHours(records, startDate, endDate);

			if (result == 8)
			{
				Console.WriteLine("True");
			}
			else
			{
				Console.WriteLine($"False, Result: {result}, Answer: 8");
			}

			Console.WriteLine();

			Console.WriteLine("-------------------------------");

			Console.WriteLine();
		}

		public static void Testing9(IEnumerable<HolidayTWModel> records)
		{
			Console.WriteLine("Testing 9 : One Day 2");

			Console.WriteLine();

			DateTime startDate = new DateTime(2020, 11, 20, 9, 0, 0);
			DateTime endDate = new DateTime(2020, 11, 20, 11, 0, 0);

			//display(records, startDate, endDate);

			double result = TotalTime.totalWorkingHours(records, startDate, endDate);

			if (result == 2)
			{
				Console.WriteLine("True");
			}
			else
			{
				Console.WriteLine($"False, Result: {result}, Answer: 2");
			}

			Console.WriteLine();

			Console.WriteLine("-------------------------------");

			Console.WriteLine();
		}

		public static void Testing10(IEnumerable<HolidayTWModel> records)
		{
			Console.WriteLine("Testing 10 : One Day 3");

			Console.WriteLine();

			DateTime startDate = new DateTime(2020, 11, 20, 14, 0, 0);
			DateTime endDate = new DateTime(2020, 11, 20, 18, 0, 0);

			//display(records, startDate, endDate);

			double result = TotalTime.totalWorkingHours(records, startDate, endDate);

			if (result == 4)
			{
				Console.WriteLine("True");
			}
			else
			{
				Console.WriteLine($"False, Result: {result}, Answer: 4");
			}

			Console.WriteLine();

			Console.WriteLine("-------------------------------");

			Console.WriteLine();
		}

		public static void Testing11(IEnumerable<HolidayTWModel> records)
		{
			Console.WriteLine("Testing 11 : Day Off 1");

			Console.WriteLine();

			DateTime startDate = new DateTime(2020, 11, 21, 9, 0, 0);
			DateTime endDate = new DateTime(2020, 11, 21, 18, 0, 0);

			//display(records, startDate, endDate);

			double result = TotalTime.totalWorkingHours(records, startDate, endDate);

			if (result == 0)
			{
				Console.WriteLine("True");
			}
			else
			{
				Console.WriteLine($"False, Result: {result}, Answer: 0");
			}

			Console.WriteLine();

			Console.WriteLine("-------------------------------");

			Console.WriteLine();
		}

		public static void Testing12(IEnumerable<HolidayTWModel> records)
		{
			Console.WriteLine("Testing 12 : Day Off 2");

			Console.WriteLine();

			DateTime startDate = new DateTime(2020, 11, 21, 9, 0, 0);
			DateTime endDate = new DateTime(2020, 11, 21, 11, 0, 0);

			//display(records, startDate, endDate);

			double result = TotalTime.totalWorkingHours(records, startDate, endDate);

			if (result == 0)
			{
				Console.WriteLine("True");
			}
			else
			{
				Console.WriteLine($"False, Result: {result}, Answer: 0");
			}

			Console.WriteLine();

			Console.WriteLine("-------------------------------");

			Console.WriteLine();
		}

		public static void Testing13(IEnumerable<HolidayTWModel> records)
		{
			Console.WriteLine("Testing 13 : Day Off 3");

			Console.WriteLine();

			DateTime startDate = new DateTime(2020, 11, 21, 14, 0, 0);
			DateTime endDate = new DateTime(2020, 11, 21, 18, 0, 0);

			//display(records, startDate, endDate);

			double result = TotalTime.totalWorkingHours(records, startDate, endDate);

			if (result == 0)
			{
				Console.WriteLine("True");
			}
			else
			{
				Console.WriteLine($"False, Result: {result}, Answer: 0");
			}

			Console.WriteLine();

			Console.WriteLine("-------------------------------");

			Console.WriteLine();
		}

		public static void Testing14(IEnumerable<HolidayTWModel> records)
		{
			Console.WriteLine("Testing 14 : Tomorrow");

			Console.WriteLine();

			DateTime startDate = new DateTime(2020, 11, 23, 09, 0, 0);
			DateTime endDate = new DateTime(2020, 11, 24, 18, 0, 0);

			//display(records, startDate, endDate);

			double result = TotalTime.totalWorkingHours(records, startDate, endDate);

			if (result == 16)
			{
				Console.WriteLine("True");
			}
			else
			{
				Console.WriteLine($"False, Result: {result}, Answer: 16");
			}

			Console.WriteLine();

			Console.WriteLine("-------------------------------");

			Console.WriteLine();
		}
	}
}
