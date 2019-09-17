using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KoreanTools;

namespace Krucible
{
    public class TrainingModel : KruciblePageModel
    {
        [BindProperty]
        public long Min { get; set; } = 1;
        [BindProperty]
        public long Max { get; set; } = 9999999;

        protected override string GetTask()
        {
            Random random = new Random();
            var n = LongRandom(Min, Max, random);
            return n.ToString();
        }

        protected override string GetSolution(string input) => SinoKorean.Translate(input);

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