using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace KoreanTools
{
    // https://abliar.tistory.com/5
    public static class DecomposeHangul
    {
        public static string Decompose(string input)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char ch in input)
            {
                sb.Append(Decompose(ch));
            }
            return sb.ToString();
        }

        private static string Decompose(char ch)
        {
            if (0x3131 <= ch && ch <= 0x3163)
                return DecomposeJamo(ch);
            else if (0xAC00 <= ch && ch <= 0xD7B3)
                return DecomposeSyllable(ch);
            else
                return ch.ToString();
        }

        static string[] jamoMap = new string[]
            {
                "ㄱ", "ㄲ", "ㄱㅅ", "ㄴ", "ㄴㅈ", "ㄴㅎ", "ㄷ",
                "ㄸ", "ㄹ", "ㄹㄱ", "ㄹㅁ", "ㄹㅂ", "ㄹㅅ", "ㄹㅌ",
                "ㄹㅍ", "ㄹㅎ", "ㅁ", "ㅂ", "ㅃ", "ㅂㅅ", "ㅅ",
                "ㅆ", "ㅇ", "ㅈ", "ㅉ", "ㅊ", "ㅋ", "ㅌ", "ㅍ", "ㅎ",
                "ㅏ", "ㅐ", "ㅑ", "ㅒ", "ㅓ", "ㅔ",
                "ㅕ", "ㅖ", "ㅗ", "ㅗㅏ", "ㅗㅐ",
                "ㅗㅣ", "ㅛ", "ㅜ", "ㅜㅓ", "ㅜㅔ",
                "ㅜㅣ", "ㅠ", "ㅡ", "ㅡㅣ", "ㅣ",
            };

        static string[] jamoMapT = new string[]
            {
                "ㄱ", "ㄲ", "ㄱㅅ", "ㄴ", "ㄴㅈ", "ㄴㅎ", "ㄷ",
                "ㄹ", "ㄹㄱ", "ㄹㅁ", "ㄹㅂ", "ㄹㅅ", "ㄹㅌ",
                "ㄹㅍ", "ㄹㅎ", "ㅁ", "ㅂ", "ㅂㅅ", "ㅅ",
                "ㅆ", "ㅇ", "ㅈ", "ㅊ", "ㅋ", "ㅌ", "ㅍ", "ㅎ"
            };

        static string[] jamoMapV = new string[]
        {
                "ㅏ", "ㅐ", "ㅑ", "ㅒ", "ㅓ", "ㅔ",
                "ㅕ", "ㅖ", "ㅗ", "ㅗㅏ", "ㅗㅐ",
                "ㅗㅣ", "ㅛ", "ㅜ", "ㅜㅓ", "ㅜㅔ",
                "ㅜㅣ", "ㅠ", "ㅡ", "ㅡㅣ", "ㅣ",
        };

        private static string DecomposeJamo(char ch)
        {
            if (0x3131 <= ch && ch <= 0x3163)
                return jamoMap[ch - 0x3131];
            throw new ArgumentException("ch");
        }

        static string L = "ㄱㄲㄴㄷㄸㄹㅁㅂㅃㅅㅆㅇㅈㅉㅊㅋㅌㅍㅎ";
        static string V = "ㅏㅐㅑㅒㅓㅔㅕㅖㅗㅘㅙㅚㅛㅜㅝㅞㅟㅠㅡㅢㅣ";
        static string T = "ㄱㄲㄳㄴㄵㄶㄷㄹㄺㄻㄼㄽㄾㄿㅀㅁㅂㅄㅅㅆㅇㅈㅊㅋㅌㅍㅎ"; // ㄱ has an index 1

        static bool IsVowel(char character)
        {
            return V.Contains(character);
        }

        static bool IsConsonant(char character)
        {
            return L.Contains(character);
        }

        private static string DecomposeSyllable(char ch)
        {
            if (0xAC00 <= ch && ch <= 0xD7B3)
            {
                int x = ch - 0xAC00;
                int l = x / 588;
                int v = (x / 28) % 21;
                int t = x % 28;
                if (t == 0)
                    return DecomposeJamo(L[l]) + DecomposeJamo(V[v]);
                else
                    return DecomposeJamo(L[l]) + DecomposeJamo(V[v]) + DecomposeJamo(T[t-1]);
            }
            throw new ArgumentException("ch");
        }

        private static bool IsKoreanLetter(char input)
        {
            return L.Contains(input) || V.Contains(input) || T.Contains(input);
        }

        public static string ComposeHangul(string input)
        {
            StringBuilder sb = new StringBuilder();
            var ret = new List<string>();
            string currentBlock = "";
            CollectSyllables(input, sb, ref currentBlock, true);
            CollectSyllables(input, sb, ref currentBlock, false);
            return sb.ToString();
        }

        private static void CollectSyllables(string input, StringBuilder sb, ref string currentBlock, bool checkJunctions)
        {
            int lower = checkJunctions ? 0 : input.Length - 2;
            int upper = checkJunctions ? input.Length - 3 : input.Length - 1;
            for (int i = lower; i <= upper; i++)
            {
                if (!IsKoreanLetter(input[i]))
                {
                    sb.Append(ComposeSyllable(currentBlock));
                    sb.Append(input[i]);
                    currentBlock = "";
                }
                else
                {
                    if (checkJunctions && WordJunction(input, i))
                    {
                        sb.Append(ComposeSyllable(currentBlock + input[i]));
                        currentBlock = "";
                    }
                    else
                        currentBlock += input[i];
                }
            }
            if (!checkJunctions)
                sb.Append(ComposeSyllable(currentBlock));
        }

        private static string ComposeSyllable(string input)
        {
            if (input.Length < 2)
                return input;
            input = TryCollapseDiphtong(input);
            input.Any(ch => !(L.Contains(ch) || V.Contains(ch) || T.Contains(ch)));
            int Lind = L.IndexOf(input[0]);
            int Vind = V.IndexOf(input[1]);
            int c = Lind * 588 + Vind * 28;
            if (input.Length == 3)
                c += T.IndexOf(input[2]) + 1; // indexing of T should start from 1
            c += 44032;
            char[] arr = new char[]{ (char)c };
            string ret = Encoding.UTF8.GetString(Encoding.Default.GetBytes(arr));
            return ((char)c).ToString();
        }

        private static string TryCollapseDiphtong(string input)
        {
            if (input.Length < 3)
                return input;
            var first = input.Substring(0, 1);
            var second = input.Substring(1, 2);
            var third = "";
            if (input.Length > 3)
                third = input.Substring(3);
            int indexSecond = Array.IndexOf(jamoMapV, second);
            if (indexSecond < 0)
                return input;
            var secondCollapsed = V[indexSecond].ToString();
            int indexThird = Array.IndexOf(jamoMapT, third);
            if (indexThird < 0)
                return first + secondCollapsed + third;
            var thirdCollapsed = T[indexThird].ToString();
            return first + secondCollapsed + thirdCollapsed;
        }

        private static bool WordJunction(string input, int index)
        {
            string subs = input.Substring(index, 3);
            //return (T.Contains(subs[0]) && L.Contains(subs[1])) ||
            //       (V.Contains(subs[0]) && T.Contains(subs[1]) && V.Contains(subs[2]));
            return L.Contains(subs[1]) && V.Contains(subs[2]);

        }
    }
}
