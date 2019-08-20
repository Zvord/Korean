using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;

namespace Krucible.Pages
{
    public class AssimilationWordModel : KruciblePageModel
    {
        protected override string GetTask() => KoreanTools.AssimilationWords.GetRandomWord();

        protected override string GetSolution(string input)
        {
            var dec = KoreanTools.DecomposeHangul.Decompose(input);
            var ass = KoreanTools.Assimilation.AssimilateLong(dec);
            var correct = KoreanTools.DecomposeHangul.ComposeHangul(ass);
            return correct;
        }
    }
}