using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Krucible.Pages
{
    public class AssimilationWordModel : PageModel
    {
        [BindProperty]
        public string UserGuess { get; set; }
        public static string RandomWord { get; set; }
        public string Result { get; set; }

        public void OnPostGetRandomWord()
        {
            RandomWord = KoreanTools.AssimilationWords.GetRandomWord();
        }

        public void OnPostCheckAnswer()
        {
            var dec     = KoreanTools.DecomposeHangul.Decompose(RandomWord);
            var ass     = KoreanTools.Assimilation.AssimilateLong(dec);
            var correct = KoreanTools.DecomposeHangul.ComposeHangul(ass);
            if (UserGuess == correct)
                Result = "Correct!";
            else
                Result = $"Correct : {correct}, looser!";

        }
    }
}