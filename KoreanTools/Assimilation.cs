using System;
using System.Collections.Generic;
using System.Text;

namespace KoreanTools
{
    public static class Assimilation
    {
        static Dictionary<string, string> AssimilationTable = new Dictionary<string, string>()
        {
            {"ㄱㄹ", "ㅇㄴ" },
            {"ㄱㅁ", "ㅇㅁ" },
            {"ㄱㄴ", "ㅇㄴ" },

            {"ㅂㄹ", "ㅁㄴ" },
            {"ㅂㅁ", "ㅁㅁ" },
            {"ㅂㄴ", "ㅁㄴ" },

            {"ㄷㅁ", "ㄴㅁ" },
            {"ㄷㄴ", "ㄴㄴ" },
            {"ㄷㅅ", "ㅆ"   },

            {"ㄹㄴ", "ㄹㄹ" },

            {"ㅁㄹ", "ㅁㄴ" },

            {"ㄴㄹ", "ㄹㄹ" },

            {"ㅇㄹ", "ㅇㄴ" },
        };

        static Dictionary<string, string> ImplosionTable = new Dictionary<string, string>()
        {
            {"ㄱ", "ㄱ" },
            {"ㅋ", "ㄱ" },
            {"ㄲ", "ㄱ" },

            {"ㅂ", "ㅂ" },
            {"ㅍ", "ㅂ" },
            {"ㅃ", "ㅂ" },

            {"ㄷ", "ㄷ" },
            {"ㄸ", "ㄷ" },
            {"ㅌ", "ㄷ" },
            {"ㅈ", "ㄷ" },
            {"ㅊ", "ㄷ" },
            {"ㅉ", "ㄷ" },
            {"ㅅ", "ㄷ" },
            {"ㅆ", "ㄷ" },
        };

        static string Implosion(string input)
        {
            string ret;
            if (ImplosionTable.TryGetValue(input, out ret))
                return ret;
            else
                return input;
        }

        public static string Assimilate(string a, string b)
        {
            string pair = a + b;
            return Assimilate(pair);
        }

        public static string Assimilate(string pair)
        {
            string ret;
            if (AssimilationTable.TryGetValue(pair, out ret))
                return ret;
            else
                return pair;
        }

        public static bool HasAssimilation(string input) => AssimilationTable.ContainsKey(input);
    }
}
