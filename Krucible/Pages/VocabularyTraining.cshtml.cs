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
        public IList<SelectListItem> LessonsNames { get; set; }
        [BindProperty]
        public int SelectedLessonNumber { get; set; }
        [BindProperty]
        public string SelectedLesson { get; set; }
        [BindProperty]
        public string Korean { get; set; }
        [BindProperty]
        public string English { get; set; }
        [BindProperty]
        public string Russian { get; set; }
        public void OnGet()
        {
            //LessonsNames = new List<SelectListItem>();
            //int max = Sogang_1A_Vocabulary.Lessons.Count;
            //for (int i = 1; i <= max; i++)
            //    LessonsNames.Add(new SelectListItem(i.ToString(), i.ToString()));
            //ViewData["xz"] = new SelectList(LessonNumbers);
            //SelectedNumber = "2";
            LessonsNames = Sogang_1A_Vocabulary.Names.Select(n => new SelectListItem(n, n)).ToList();
        }
        protected override string GetTask()
        {
            GetSelectedLesson();
            RestoreSelectedLesson();
            var Vocab = Sogang_1A_Vocabulary.Lessons[Convert.ToInt32(SelectedLessonNumber) - 1];
            Random r = new Random();
            int index = r.Next(Vocab.Count);
            var entry = Vocab[index];
            English = entry.English;
            Korean = entry.Korean;
            Russian = entry.Russian;
            return English;
        }

        protected override string GetSolution(string input)
        {
            RestoreSelectedLesson();
            return Korean;
        }

        protected void GetSelectedLesson()
        {
            SelectedLesson = Request.Form["LessonNumber"][0];
            SelectedLessonNumber = Sogang_1A_Vocabulary.Names.ToList().IndexOf(SelectedLesson);
        }
        protected void RestoreSelectedLesson()
        {
            GetSelectedLesson();
            var selected = LessonsNames.First(name => name.Text == SelectedLesson);
            //selected.Selected = true;
        }
    }
}