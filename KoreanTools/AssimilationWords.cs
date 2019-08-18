using System;
using System.Collections.Generic;
using System.Text;

namespace KoreanTools
{
    public static class AssimilationWords
    {
        public static string GetRandomWord()
        {
            var rand = new Random();
            return Words[rand.Next(Words.Length - 1)];
        }
        public static string[] Words =
        {
            "근로자 ",
            "삼류",
            "생산량",
            "음료수",
            "논란",
            "담력",
            "진리",
            "관련",
            "병렬",
            "궈리",
            "사망률",
            "동력",
            "관리",
            "전라남도",
            "병력",
            "곤란",
            "정신력",
            "달나리",
            "생략",
            "평론",
            "실내",
            "등록",
            "진로",
            "상류",
            "상록수",
            "반란",
            "양력",
            "전력",
            "항로",
            "북녘",
            "복무",
            "백리",
            "목례",
            "국문학",
            "속리산",
            "식민지",
            "목록",
            "목련꽃",
            "박람회",
            "국민",
            "식물",
            "맥락",
            "기억력",
            "국물",
            "속력",
            "곡류",
            "막막하다",
            "격렬",
            "국무",
            "벽면",
            "숙녀",
            "녹말",
            "낙망하다",
            "목마",
            "학년",
            "악마",
            "악몽",
            "백마",
            "혁명"
        };
    }
}
