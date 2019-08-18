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

        public static string Assimilate(char a, char b)
        {
            char[] pair = { a, b };
            return Assimilate(new string(pair));
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

        public static string AssimilateLong(string input)
        {
            var sb = new StringBuilder(input);
            for (int i = 0; i < input.Length-2; i++)
            {
                var pair = input.Substring(i, 2);
                string ass;
                if (AssimilationTable.TryGetValue(pair, out ass))
                {
                    sb.Remove(i, 2);
                    sb.Insert(i, ass);
                    i++;
                }
            }
            return sb.ToString();
        }
    }
}
