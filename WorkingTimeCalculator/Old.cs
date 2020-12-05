using System;
using System.Collections.Generic;
using System.Linq;

namespace WorkingTimeCalculator
{
	//2019 Early Version, but it is not truly be tested.
	class Old
    {
		public static double workTime(IEnumerable<HolidayTWModel> isHolidays, DateTime startTime, DateTime stopTime)
		{
			if (startTime.Hour >= 0 && startTime.Hour < 9)
			{
				startTime = new DateTime(startTime.Year, startTime.Month, startTime.Day, 9, 0, 0);
			}
			else if (startTime.Hour > 18 && startTime.Hour < 24)
			{
				startTime = startTime.AddDays(1);
				startTime = new DateTime(startTime.Year, startTime.Month, startTime.Day, 9, 0, 0);

				if (startTime >= stopTime)
				{
					startTime = stopTime;
				}
			}

			while (startTime < stopTime)
			{
				var checkHolidays = isHolidays.Where(x => Convert.ToDateTime(x.date) == new DateTime(startTime.Year, startTime.Month, startTime.Day));

				if (checkHolidays.Count() != 0)
				{
					startTime = startTime.AddDays(1);
					startTime = new DateTime(startTime.Year, startTime.Month, startTime.Day, 9, 0, 0);

					if (startTime >= stopTime)
					{
						startTime = stopTime;
						break;
					}
				}
				else
				{
					if (stopTime.Hour >= 0 && stopTime.Hour < 9)
					{
						stopTime = stopTime.AddDays(-1);
						stopTime = new DateTime(stopTime.Year, stopTime.Month, stopTime.Day, 18, 0, 0);
					}
					else if (stopTime.Hour > 18 && stopTime.Hour < 24)
					{
						stopTime = new DateTime(stopTime.Year, stopTime.Month, stopTime.Day, 18, 0, 0);

						if (stopTime <= startTime)
						{
							stopTime = startTime;
						}
					}

					break;
				}
			}

			double holidays = isHolidays.Where(x => Convert.ToDateTime(x.date) > new DateTime(startTime.Year, startTime.Month, startTime.Day) && Convert.ToDateTime(x.date) <= new DateTime(stopTime.Year, stopTime.Month, stopTime.Day)).Count();

			double total = ((stopTime - startTime).TotalHours) / 1;

			total = total - (holidays * 24);

			// Work Time 8 Hours
			int overWorkTime = Convert.ToInt32(total / 24) * 16;

			total = total - overWorkTime;

			// Rest
			if (((stopTime - startTime).TotalHours) / 1 > 8)
			{
				total--;
			}

			return total;
		}
	}
}
