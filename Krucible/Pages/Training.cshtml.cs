using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KoreanTools;

namespace Krucible
{
    public class TrainingModel : PageModel
    {
        [BindProperty]
        public long Min { get; set; } = 1;
        [BindProperty]
        public long Max { get; set; } = 9999999;
        static long Number;
        public string NumberStr { get; set; }
        [BindProperty]
        public string UserTranslation { get; set; }
        public static string Translation { get; set; }
        public string Result { get; set; } = "";
        public string UserGuess { get; set; } = "";

        public void OnGet()
        {
        }

        public void OnPost()
        {
            NumberStr = "1";
        }

        public void OnPostRandomNumber()
        {
            Random random = new Random();
            Number = LongRandom(Min, Max, random);
            NumberStr = Number.ToString();
            Translation = KoreanTools.SinoKorean.Translate(NumberStr);
        }

        public void OnPostCheckAnswer()
        {
            NumberStr = Number.ToString();
            if (UserTranslation != null && Translation == UserTranslation.Trim())
                Result = "Correct!";
            else
            {
                UserGuess = $"Your try: {UserTranslation}";
                Result = $"Correct : {Translation}, looser!";
            }
        }

        long LongRandom(long min, long max, Random rand)
        {
            if (max == min)
                return max;
            byte[] buf = new byte[8];
            rand.NextBytes(buf);
            long longRand = BitConverter.ToInt64(buf, 0);

            return (Math.Abs(longRand % (max - min + 1)) + min);
        }

    }
}