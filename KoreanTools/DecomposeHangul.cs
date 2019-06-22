using System;
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

        public static string DecomposeJamo(char ch)
        {
            if (0x3131 <= ch && ch <= 0x3163)
                return jamoMap[ch - 0x3131];
            throw new ArgumentException("ch");
        }

        static string L = "ㄱㄲㄴㄷㄸㄹㅁㅂㅃㅅㅆㅇㅈㅉㅊㅋㅌㅍㅎ";
        static string V = "ㅏㅐㅑㅒㅓㅔㅕㅖㅗㅘㅙㅚㅛㅜㅝㅞㅟㅠㅡㅢㅣ";
        static string T = " ㄱㄲㄳㄴㄵㄶㄷㄹㄺㄻㄼㄽㄾㄿㅀㅁㅂㅄㅅㅆㅇㅈㅊㅋㅌㅍㅎ";
        public static string DecomposeSyllable(char ch)
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
                    return DecomposeJamo(L[l]) + DecomposeJamo(V[v]) + DecomposeJamo(T[t]);
            }
            throw new ArgumentException("ch");
        }
    }
}
