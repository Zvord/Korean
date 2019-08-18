﻿using System;
using Xunit;
using KoreanTools;

namespace KoreanTest
{
    public class UnitTest
    {
        [Fact]
        public void SentenceTest()
        {
            var str = @"1) 모든 사람은 교육을 받을 권리를 가진다 . 교육은 최소한 초등 및 기초단계에서는 무상이어야 한다. 초등교육은 의무적이어야 한다. 기술 및 직업교육은 일반적으로 접근이 가능하여야 하며, 고등교육은 모든 사람에게 실력에 근거하여 동등하게 접근 가능하여야 한다.
2) 교육은 인격의 완전한 발전과 인권과 기본적 자유에 대한 존중의 강화를 목표로 한다. 교육은 모든 국가 , 인종 또는 종교 집단간에 이해, 관용 및 우의를 증진하며, 평화의 유지를 위한 국제연합의 활동을 촉진하여야 한다.
3) 부모는 자녀에게 제공되는 교육의 종류를 선택할 우선권을 가진다 .";
            var dec = DecomposeHangul.Decompose(str);
            var com = DecomposeHangul.ComposeHangul(dec);
            Assert.Equal(str, com);
        }

        [Fact]
        public void DiphtongTest()
        {
            var str = "권";
            var dec = DecomposeHangul.Decompose(str);
            var com = DecomposeHangul.ComposeHangul(dec);
            Assert.Equal(str, com);
        }

        [Fact]
        public void SimpleAssimilationTest()
        {
            var input = "입니다";
            var expected = "임니다";
            var actual = DecomposeHangul.ComposeHangul(Assimilation.AssimilateLong(DecomposeHangul.Decompose(input)));
            Assert.Equal(expected, actual);

        }
    }
}
