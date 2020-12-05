using System;
using System.Collections.Generic;
using System.Linq;

namespace WorkingTimeCalculator
{
    class TotalTime
    {
        public static Double totalDays(DateTime startDate, DateTime endDate)
        {
            double total = (endDate - startDate).TotalDays;

            total = Convert.ToInt16(Math.Ceiling(total));

            return total;
        }

        public static Double totalHoliday(IEnumerable<HolidayTWModel> isHoliday, DateTime startDate, DateTime endDate)
        {
            var holiday = isHoliday.Where(x => (Convert.ToDateTime(x.date).Date >= startDate.Date) && (Convert.ToDateTime(x.date).Date <= endDate.Date));

            double total = holiday.Count();

            //Confirm Holiday
            /*foreach(var item in holiday)
            {
                Console.WriteLine(item.date);
            }*/

            return total;
        }

        public static Double totalWorkingDay(IEnumerable<HolidayTWModel> isHoliday, DateTime startDate, DateTime endDate)
        {
            double totalDay = totalDays(startDate, endDate);

            double Holiday = totalHoliday(isHoliday, startDate, endDate);

            double workingday = totalDay - Holiday;
            
            return workingday;
        }

        public static Double totalHours(DateTime startDate, DateTime endDate)
        {
            double total = (endDate - startDate).TotalHours;
            
            return total;
        }

        public static Double totalHolidayHours(IEnumerable<HolidayTWModel> isHoliday, DateTime startDate, DateTime endDate)
        {
            var holiday = isHoliday.Where(x => (Convert.ToDateTime(x.date).Date >= startDate.Date) && (Convert.ToDateTime(x.date).Date <= endDate.Date));

            double total = holiday.Count() * 24;

            return total;
        }

        public static Double totalWorkingHours(IEnumerable<HolidayTWModel> isHoliday, DateTime startDate, DateTime endDate)
        {
            //Working Time
            double[] workingHour = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0 };

            double total = 0;

            // compute first day total working hour
            if(checkHoliday(isHoliday, startDate.Date) == false)
            {
                if (startDate.Date != endDate.Date)
                {
                    for (int i = startDate.Hour; i <= 23; i++)
                    {
                        total = total + workingHour[i];
                    }
                }
                else
                {
                    for(int j = startDate.Hour; j < endDate.Hour; j++)
                    {
                        total = total + workingHour[j];
                    }
                }
            }

            int count = 1;

            // compute other day total working hour
            if (startDate.Date.AddDays(count) < endDate.Date)
            {
                while (startDate.Date.AddDays(count) < endDate.Date)
                {
                    if (checkHoliday(isHoliday, startDate.Date.AddDays(count)) == false)
                    {
                        total = total + 8;
                    }

                    count++;
                }
            }

            // compute last day total working hour
            if (checkHoliday(isHoliday, endDate.Date) == false)
            {
                if (startDate.Date != endDate.Date)
                {
                    for (int i = 0; i < endDate.Hour; i++)
                    {
                        total = total + workingHour[i];
                    }
                }
            }

            return total;
        }

        // check holiday
        private static Boolean checkHoliday(IEnumerable<HolidayTWModel> isHoliday, DateTime checkDate)
        {
            DateTime setDate = checkDate;
            
            var holiday = isHoliday.Where(x => Convert.ToDateTime(x.date).Date == setDate); 

            if(holiday.Count() != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
