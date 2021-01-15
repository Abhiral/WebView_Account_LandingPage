using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace App.DateConverter
{
    public partial class DateConverter
    {
        static Dictionary<int, int[]> nepaliMap = new Dictionary<int, int[]>();
        static DateTime baseEngDate;
        static int startingEngYear = 1944;
        static int startingEngMonth = 1;
        static int startingEngDay = 1;
        //static int dayOfWeek = 7;// Calendar.SATURDAY; // 1944/1/1 is Saturday

        static int startingNepYear = 2000;
        static int startingNepMonth = 9;
        static int startingNepDay = 17;

        public static void DateConverterLoad()
        {
            NepaliCalenderSet();
            baseEngDate = new DateTime(startingEngYear, startingEngMonth, startingEngDay);
        }

        /// <summary>
        /// Date convertion Nepali to English or English to Nepali
        /// </summary>
        /// <param name="DateToConvert">input date  as eng: mm/dd/yyyy or for nepali: dd/mm/yyyy</param>
        /// <param name="Type">e or n char(To get result in Nepali Date type 'n' or to get result in English Date type 'e')</param>
        /// <returns></returns>
        //[Microsoft.SqlServer.Server.SqlFunction()]
        //public static string ConvertDate(string DateToConvert, string Type)
        //{
        //    DateConverterLoad();
        //    string returnDate = null;
        //    if (Type == "e")
        //    {
        //        var res = GetEnglishDate(DateToConvert);
        //        returnDate = res.ToString();
        //    }

        //    if (Type == "n")
        //    {
        //        var res = GetNepaliDate(DateToConvert);
        //        returnDate = res.ToString();
        //    }
        //    return returnDate;
        //}


        public static string GetNepaliDate(DateTime englishDate)
        {
            DateConverterLoad();
            DateTime dt = Convert.ToDateTime(englishDate);
            int engYear = dt.Year;
            int engMonth = dt.Month;
            int engDay = dt.Day;


            DateTime currentEngDate = new DateTime(engYear, engMonth, engDay);


            double totalEngDaysCount = baseEngDate.Subtract(currentEngDate).TotalDays;

            int nepYear = startingNepYear;
            int nepMonth = startingNepMonth;
            int nepDay = startingNepDay;

            // decrement totalEngDaysCount until its value becomes 0
            while (totalEngDaysCount != 0)
            {

                // getting the total number of days in month nepMonth in year nepYear    
                int daysInIthMonth = nepaliMap[nepYear][nepMonth];  //nepaliYearsMap.get(nepYear)[nepMonth];

                nepDay++; // incrementing nepali day

                if (nepDay > daysInIthMonth)
                {
                    nepMonth++;
                    nepDay = 1;
                }
                if (nepMonth > 12)
                {
                    nepYear++;
                    nepMonth = 1;
                }

                //dayOfWeek++; // count the days in terms of 7 days
                //if (dayOfWeek > 7)
                //{
                //    dayOfWeek = 1;
                //}

                if (totalEngDaysCount < 0)
                {
                    totalEngDaysCount++;
                }
                else
                {
                    totalEngDaysCount--;
                }
            }





            return nepYear + "-" + ((nepMonth <= 9) ? "0" + nepMonth.ToString() : nepMonth.ToString()) + "-" + ((nepDay <= 9) ? "0" + nepDay.ToString() : nepDay.ToString());


        }

        public static DateTime GetEnglishDate(string nepaliDate)
        {
            DateConverterLoad();
            int nepYear = 0, nepMonth = 0, nepDay = 0;

            //extract dd/mm/YYYY formatted string date to day,month,year seperately.
            nepaliDate = nepaliDate.Replace("/", "-");
            char[] chrArray = new char[] { '-' };
            string[] strArrays = nepaliDate.Split(chrArray, 3);
            if ((int)strArrays.Length != 1)
            {
                //nepDay = Convert.ToInt32(strArrays[0]);
                //nepMonth = Convert.ToInt32(strArrays[1]);
                //nepYear = Convert.ToInt32(strArrays[2]);
                nepYear = Convert.ToInt32(strArrays[0]);
                nepMonth = Convert.ToInt32(strArrays[1]);
                nepDay = Convert.ToInt32(strArrays[2]);
            }




            long totalNepDaysCount = 0;

            // count total days in-terms of year
            for (int i = startingNepYear; i < nepYear; i++)
            {
                for (int j = 1; j <= 12; j++)
                {
                    if (i == startingNepYear && j < startingNepMonth)
                    {
                        continue;
                    }
                    else
                    {
                        totalNepDaysCount += nepaliMap[i][j];
                    }
                }
            }

            // count total days in-terms of month

            if (nepYear != startingNepYear)//if given year is not equal to base year.
            {

                for (int j = 1; j < nepMonth; j++)
                {
                    totalNepDaysCount += nepaliMap[nepYear][j];
                }

            }
            else
            {
                if (nepMonth > startingNepMonth)
                {
                    for (int j = startingNepMonth; j < nepMonth; j++)
                    {
                        totalNepDaysCount += nepaliMap[nepYear][j];
                    }
                }
            }

            // count total days in-terms of date
            totalNepDaysCount += nepDay - startingNepDay;


            var engConvertedDate = baseEngDate.AddDays(totalNepDaysCount);

            string dayResult = engConvertedDate.Day.ToString();
            string monthResult = engConvertedDate.Month.ToString("D2");
            string yearResult = engConvertedDate.Year.ToString();

            //return yearResult + "-" + monthResult + "-" + dayResult;
            return new DateTime(Convert.ToInt32(yearResult), Convert.ToInt32(monthResult), Convert.ToInt32(dayResult));

        }

        /*
         
        //alternative soln not in use so far.
        public void GetEngDate()
        {

            int nepYear = 2044;

            int nepMonth = 5;

            int nepDay = 12;


            long totalNepDaysCount = 0;

            // count total days in-terms of year
            for (int i = startingNepYear; i < nepYear; i++)
            {
                for (int j = 1; j <= 12; j++)
                {
                    totalNepDaysCount += nepaliMap[i][j];
                }
            }

            // count total days in-terms of month
            for (int j = startingNepMonth; j < nepMonth; j++)
            {
                totalNepDaysCount += nepaliMap[nepYear][j];
            }

            // count total days in-terms of date
            totalNepDaysCount += nepDay - startingNepDay;

            int[] daysInMonth = new int[] { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            int[] daysInMonthOfLeapYear = new int[] { 0, 31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

            // calculation of equivalent english date...
            int engYear = startingEngYear;
            int engMonth = startingEngMonth;
            int engDay = startingEngDay;

            int endDayOfMonth = 0;

            while (totalNepDaysCount != 0)
            {
                if (isLeapYear(engYear))
                {
                    endDayOfMonth = daysInMonthOfLeapYear[engMonth];
                }
                else
                {
                    endDayOfMonth = daysInMonth[engMonth];
                }
                engDay++;
                dayOfWeek++;
                if (engDay > endDayOfMonth)
                {
                    engMonth++;
                    engDay = 1;
                    if (engMonth > 12)
                    {
                        engYear++;
                        engMonth = 1;
                    }
                }
                if (dayOfWeek > 7)
                {
                    dayOfWeek = 1;
                }
                totalNepDaysCount--;
            }
        }

        public static bool isLeapYear(int year)
        {
            if (year % 100 == 0)
            {
                return year % 400 == 0;
            }
            else
            {
                return year % 4 == 0;
            }
        }
        */

        private static void NepaliCalenderSet()
        {
            if (nepaliMap != null && nepaliMap.Count() > 0)
            {
                return;
            }
            nepaliMap.Add(2000, new int[] { 0, 30, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31 });
            nepaliMap.Add(2001, new int[] { 0, 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 });
            nepaliMap.Add(2002, new int[] { 0, 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30 });
            nepaliMap.Add(2003, new int[] { 0, 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31 });
            nepaliMap.Add(2004, new int[] { 0, 30, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31 });
            nepaliMap.Add(2005, new int[] { 0, 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 });
            nepaliMap.Add(2006, new int[] { 0, 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30 });
            nepaliMap.Add(2007, new int[] { 0, 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31 });
            nepaliMap.Add(2008, new int[] { 0, 31, 31, 31, 32, 31, 31, 29, 30, 30, 29, 29, 31 });
            nepaliMap.Add(2009, new int[] { 0, 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 });
            nepaliMap.Add(2010, new int[] { 0, 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30 });
            nepaliMap.Add(2011, new int[] { 0, 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31 });
            nepaliMap.Add(2012, new int[] { 0, 31, 31, 31, 32, 31, 31, 29, 30, 30, 29, 30, 30 });
            nepaliMap.Add(2013, new int[] { 0, 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 });
            nepaliMap.Add(2014, new int[] { 0, 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30 });
            nepaliMap.Add(2015, new int[] { 0, 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31 });
            nepaliMap.Add(2016, new int[] { 0, 31, 31, 31, 32, 31, 31, 29, 30, 30, 29, 30, 30 });
            nepaliMap.Add(2017, new int[] { 0, 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 });
            nepaliMap.Add(2018, new int[] { 0, 31, 32, 31, 32, 31, 30, 30, 29, 30, 29, 30, 30 });
            nepaliMap.Add(2019, new int[] { 0, 31, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31 });
            nepaliMap.Add(2020, new int[] { 0, 31, 31, 31, 32, 31, 31, 30, 29, 30, 29, 30, 30 });
            nepaliMap.Add(2021, new int[] { 0, 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 });
            nepaliMap.Add(2022, new int[] { 0, 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 30 });
            nepaliMap.Add(2023, new int[] { 0, 31, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31 });
            nepaliMap.Add(2024, new int[] { 0, 31, 31, 31, 32, 31, 31, 30, 29, 30, 29, 30, 30 });
            nepaliMap.Add(2025, new int[] { 0, 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 });
            nepaliMap.Add(2026, new int[] { 0, 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31 });
            nepaliMap.Add(2027, new int[] { 0, 30, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31 });
            nepaliMap.Add(2028, new int[] { 0, 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 });
            nepaliMap.Add(2029, new int[] { 0, 31, 31, 32, 31, 32, 30, 30, 29, 30, 29, 30, 30 });
            nepaliMap.Add(2030, new int[] { 0, 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31 });
            nepaliMap.Add(2031, new int[] { 0, 30, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31 });
            nepaliMap.Add(2032, new int[] { 0, 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 });
            nepaliMap.Add(2033, new int[] { 0, 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30 });
            nepaliMap.Add(2034, new int[] { 0, 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31 });
            nepaliMap.Add(2035, new int[] { 0, 30, 32, 31, 32, 31, 31, 29, 30, 30, 29, 29, 31 });
            nepaliMap.Add(2036, new int[] { 0, 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 });
            nepaliMap.Add(2037, new int[] { 0, 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30 });
            nepaliMap.Add(2038, new int[] { 0, 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31 });
            nepaliMap.Add(2039, new int[] { 0, 31, 31, 31, 32, 31, 31, 29, 30, 30, 29, 30, 30 });
            nepaliMap.Add(2040, new int[] { 0, 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 });
            nepaliMap.Add(2041, new int[] { 0, 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30 });
            nepaliMap.Add(2042, new int[] { 0, 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31 });
            nepaliMap.Add(2043, new int[] { 0, 31, 31, 31, 32, 31, 31, 29, 30, 30, 29, 30, 30 });
            nepaliMap.Add(2044, new int[] { 0, 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 });
            nepaliMap.Add(2045, new int[] { 0, 31, 32, 31, 32, 31, 30, 30, 29, 30, 29, 30, 30 });
            nepaliMap.Add(2046, new int[] { 0, 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31 });
            nepaliMap.Add(2047, new int[] { 0, 31, 31, 31, 32, 31, 31, 30, 29, 30, 29, 30, 30 });
            nepaliMap.Add(2048, new int[] { 0, 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 });
            nepaliMap.Add(2049, new int[] { 0, 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 30 });
            nepaliMap.Add(2050, new int[] { 0, 31, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31 });
            nepaliMap.Add(2051, new int[] { 0, 31, 31, 31, 32, 31, 31, 30, 29, 30, 29, 30, 30 });
            nepaliMap.Add(2052, new int[] { 0, 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 });
            nepaliMap.Add(2053, new int[] { 0, 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 30 });
            nepaliMap.Add(2054, new int[] { 0, 31, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31 });
            nepaliMap.Add(2055, new int[] { 0, 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 });
            nepaliMap.Add(2056, new int[] { 0, 31, 31, 32, 31, 32, 30, 30, 29, 30, 29, 30, 30 });
            nepaliMap.Add(2057, new int[] { 0, 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31 });
            nepaliMap.Add(2058, new int[] { 0, 30, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31 });
            nepaliMap.Add(2059, new int[] { 0, 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 });
            nepaliMap.Add(2060, new int[] { 0, 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30 });
            nepaliMap.Add(2061, new int[] { 0, 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31 });
            nepaliMap.Add(2062, new int[] { 0, 30, 32, 31, 32, 31, 31, 29, 30, 29, 30, 29, 31 });
            nepaliMap.Add(2063, new int[] { 0, 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 });
            nepaliMap.Add(2064, new int[] { 0, 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30 });
            nepaliMap.Add(2065, new int[] { 0, 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31 });
            nepaliMap.Add(2066, new int[] { 0, 31, 31, 31, 32, 31, 31, 29, 30, 30, 29, 29, 31 });
            nepaliMap.Add(2067, new int[] { 0, 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 });
            nepaliMap.Add(2068, new int[] { 0, 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30 });
            nepaliMap.Add(2069, new int[] { 0, 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31 });
            nepaliMap.Add(2070, new int[] { 0, 31, 31, 31, 32, 31, 31, 29, 30, 30, 29, 30, 30 });
            nepaliMap.Add(2071, new int[] { 0, 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 });
            nepaliMap.Add(2072, new int[] { 0, 31, 32, 31, 32, 31, 30, 30, 29, 30, 29, 30, 30 });
            nepaliMap.Add(2073, new int[] { 0, 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31 });
            nepaliMap.Add(2074, new int[] { 0, 31, 31, 31, 32, 31, 31, 30, 29, 30, 29, 30, 30 });
            nepaliMap.Add(2075, new int[] { 0, 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 });
            nepaliMap.Add(2076, new int[] { 0, 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 30 });
            nepaliMap.Add(2077, new int[] { 0, 31, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31 });
            nepaliMap.Add(2078, new int[] { 0, 31, 31, 31, 32, 31, 31, 30, 29, 30, 29, 30, 30 });
            nepaliMap.Add(2079, new int[] { 0, 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 });
            nepaliMap.Add(2080, new int[] { 0, 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 30 });
            nepaliMap.Add(2081, new int[] { 0, 31, 31, 32, 32, 31, 30, 30, 30, 29, 30, 30, 30 });
            nepaliMap.Add(2082, new int[] { 0, 30, 32, 31, 32, 31, 30, 30, 30, 29, 30, 30, 30 });
            nepaliMap.Add(2083, new int[] { 0, 31, 31, 32, 31, 31, 30, 30, 30, 29, 30, 30, 30 });
            nepaliMap.Add(2084, new int[] { 0, 31, 31, 32, 31, 31, 30, 30, 30, 29, 30, 30, 30 });
            nepaliMap.Add(2085, new int[] { 0, 31, 32, 31, 32, 30, 31, 30, 30, 29, 30, 30, 30 });
            nepaliMap.Add(2086, new int[] { 0, 30, 32, 31, 32, 31, 30, 30, 30, 29, 30, 30, 30 });
            nepaliMap.Add(2087, new int[] { 0, 31, 31, 32, 31, 31, 31, 30, 30, 29, 30, 30, 30 });
            nepaliMap.Add(2088, new int[] { 0, 30, 31, 32, 32, 30, 31, 30, 30, 29, 30, 30, 30 });
            nepaliMap.Add(2089, new int[] { 0, 30, 32, 31, 32, 31, 30, 30, 30, 29, 30, 30, 30 });
            nepaliMap.Add(2090, new int[] { 0, 30, 32, 31, 32, 31, 30, 30, 30, 29, 30, 30, 30 });
            nepaliMap.Add(2091, new int[] { 0, 31, 31, 32, 31, 31, 31, 30, 30, 29, 30, 30, 30 });
            nepaliMap.Add(2092, new int[] { 0, 30, 31, 32, 32, 31, 30, 30, 30, 29, 30, 30, 30 });
            nepaliMap.Add(2093, new int[] { 0, 30, 32, 31, 32, 31, 30, 30, 30, 29, 30, 30, 30 });
            nepaliMap.Add(2094, new int[] { 0, 31, 31, 32, 31, 31, 30, 30, 30, 29, 30, 30, 30 });
            nepaliMap.Add(2095, new int[] { 0, 31, 31, 32, 31, 31, 31, 30, 29, 30, 30, 30, 30 });
            nepaliMap.Add(2096, new int[] { 0, 30, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30 });
            nepaliMap.Add(2097, new int[] { 0, 31, 32, 31, 32, 31, 30, 30, 30, 29, 30, 30, 30 });
            nepaliMap.Add(2098, new int[] { 0, 31, 31, 32, 31, 31, 31, 29, 30, 29, 30, 29, 31 });
            nepaliMap.Add(2099, new int[] { 0, 31, 31, 32, 31, 31, 31, 30, 29, 29, 30, 30, 31 });

        }
    }
}
