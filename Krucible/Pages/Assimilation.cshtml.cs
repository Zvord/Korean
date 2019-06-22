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

        [BindProperty]
        public string UserGuess { get; set; }
        [BindProperty]
        public bool NotInTable { get; set; }
        public static string RandomPair { get; set; }
        public string Result { get; set; }

        public void OnPostGetRandomPair()
        {
            if (NotInTable)
                RandomPair = DrawPair();
            else
                RandomPair = DrawAssimilationPair();
        }

        public void OnPostCheckAnswer()
        {
            string correct = Assimilation.Assimilate(RandomPair);
            if (UserGuess == correct)
                Result = "Correct!";
            else
                Result = $"Correct : {correct}, looser!";

        }
    }
}