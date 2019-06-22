using System;
using System.Collections.Generic;
using System.Text;

namespace KoreanTools
{
    public class DateTranslation
    {
        static string YearWord = "년";
        static string MonthWord = "월";
        static string DayWord = "일";
        public static string Translate(DateTime input)
        {
            string yearStr = input.Year.ToString();
            // string monthStr = input.Month.ToString();
            string dayStr = input.Day.ToString();

            string yearTr = SinoKorean.Translate(yearStr);
            string monthTr = TranslateMonth(input.Month);
            string dayTr = SinoKorean.Translate(dayStr);

            string result = $"{yearTr}{YearWord} {monthTr}{MonthWord} {dayTr}{DayWord}";
            return result;
        }

        static string TranslateMonth(int input)
        {
            string result;
            if (input == 6)
                result = "유";
            else if (input == 10)
                result = "시";
            else
                result = SinoKorean.Translate(input.ToString());
            return result;
        }
    }
}
