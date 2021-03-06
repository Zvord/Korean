﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace KoreanTools
{
    public static class SinoKorean
    {
        static Dictionary<string, string> DictNumbers = new Dictionary<string, string>()
        {
            {"1", "일" },
            {"2", "이" },
            {"3", "삼" },
            {"4", "사" },
            {"5", "오" },
            {"6", "육" },
            {"7", "칠" },
            {"8", "팔" },
            {"9", "구" },
            {"10", "십" },
            {"100", "백" },
            {"1000", "천" },
            {"10000", "만" },
            {"100000", "억" },
            {"1000000", "조" }
        };

        public static string Translate(string input)
        {
            var quads = SplitToQuadruples(input);
            var transQuads = quads.Select(q => TranslateQuadruple(q)).ToList();
            transQuads.Reverse();
            for(int i = 0; i < transQuads.Count; i++)
            {
                int power = (int)(1000 * Math.Pow(10, i));
                string powerString = "";
                if (i > 0)
                    powerString = DictNumbers[power.ToString()];
                if (i > 0 && power < 100000 && transQuads[i] == "일")
                    transQuads[i] = "";
                transQuads[i] += powerString;
            }
            transQuads.Reverse();
            string result = transQuads.Aggregate((x, y) => x + y);
            return result;
        }

        static List<string> SplitToQuadruples(string input)
        {
            int n = input.Length;
            int head = n % 4;
            int quadNumber = n / 4;
            List<string> quads = new List<string>();
            if (head > 0)
                quads.Add(input.Substring(0, head));
            for (int i = 0; i < quadNumber; i++)
                quads.Add(input.Substring(head + i * 4, 4));
            return quads;
        }

        public static string TranslateQuadruple(string input)
        {
            string result = "";
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i].ToString() == "0")
                    continue;
                int power = 3 - i - (4 - input.Length);
                string powerWord;
                if (power > 0)
                    powerWord = DictNumbers[Math.Pow(10, power).ToString()];
                else
                    powerWord = "";
                string digitWord;
                if ((i < input.Length - 1) && (input[i].ToString() == "1"))
                    digitWord = "";
                else
                    digitWord = DictNumbers[input[i].ToString()];
                result += digitWord + powerWord;
            }
            return result;
        }
    }
}
