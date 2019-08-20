using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KoreanTools;

namespace Krucible.Pages
{
    public class AssimilationModel : KruciblePageModel
    {
        const string Consonants = "ㅂㅈㄷㄱㅅㅁㄴㅇㄹㅎㅋㅌㅊㅍㅃㅉㄸㄲㅆ";
        string DrawPair()
        {
            Random random = new Random();
            int i1 = random.Next(Consonants.Length - 1);
            int i2 = random.Next(Consonants.Length - 1);
            return Consonants.Substring(i1, 1) + Consonants.Substring(i2, 1);
        }

        string DrawAssimilationPair(bool allPairs)
        {
            string pair;
            do
            {
                pair = DrawPair();
            } while (!Assimilation.HasAssimilation(pair) && !allPairs);
            return pair;
        }

        [BindProperty]
        public bool NotInTable { get; set; }

        protected override string GetTask() => DrawAssimilationPair(NotInTable);
        protected override string GetSolution(string input) => Assimilation.Assimilate(input);
    }
}