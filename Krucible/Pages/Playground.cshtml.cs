using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KoreanTools;

namespace Krucible.Pages
{
    public class PlaygroundModel : PageModel
    {
        [BindProperty]
        public string Foo { get; set; }
        [BindProperty]
        public string UserInput { get; set; }
        public bool Correct { get; set; }
        public void OnPost()
        {
            Foo = DecomposeHangul.ComposeHangul(DecomposeHangul.Decompose(UserInput));
            Correct = Foo == UserInput;
        }
    }
}