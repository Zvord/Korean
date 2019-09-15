using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Krucible.Pages
{
    public class VocabularyTrainingModel : KruciblePageModel
    {
        [BindProperty]
        public IList<SelectListItem> LessonNumbers { get; set; }
        [BindProperty]
        public string SelectedNumber { get; set; }
        public void OnGet()
        {
            LessonNumbers = new List<SelectListItem>();
            int max = Sogang_1A_Vocabulary.Lessons.Length;
            for (int i = 1; i <= max; i++)
                LessonNumbers.Add(new SelectListItem(i.ToString(), i.ToString()));
            ViewData["xz"] = new SelectList(LessonNumbers);
            SelectedNumber = "2";
        }
        protected override string GetTask()
        {
            SelectedNumber = Request.Form["LessonNumber"][0];
            var Vocab = Sogang_1A_Vocabulary.Lessons[Convert.ToInt32(SelectedNumber) - 1];
            Random r = new Random();
            int index = r.Next(Vocab.Count);
            return Vocab.Keys.ElementAt(index);
        }

        protected override string GetSolution(string input)
        {
            return Sogang_1A_Vocabulary.Test[input];
        }
    }
}