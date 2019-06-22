using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KoreanTools;

namespace Krucible.Pages
{
    public class AssimilationModel : PageModel
    {
        const string Consonants = "ㅂㅈㄷㄱㅅㅁㄴㅇㄹㅎㅋㅌㅊㅍㅃㅉㄸㄲㅆ";
        string DrawPair()
        {
            Random random = new Random();
            int i1 = random.Next(Consonants.Length - 1);
            int i2 = random.Next(Consonants.Length - 1);
            return Consonants.Substring(i1, 1) + Consonants.Substring(i2, 1);
        }

        string DrawAssimilationPair()
        {
            string pair;
            do
            {
                pair = DrawPair();
            } while (!Assimilation.HasAssimilation(pair));
            return pair;
        }
        public void OnGet()
        {

        }
    }
}