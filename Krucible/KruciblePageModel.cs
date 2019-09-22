using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Krucible
{
    public abstract class KruciblePageModel : PageModel
    {
        [BindProperty]
        public string UserGuess { get; set; }
        [BindProperty]
        public string Task { get; set; }
        public string Result { get; set; }

        protected abstract string GetTask();
        public void OnPostGetTask()
        {
            Task = GetTask();
            //HttpContext.Session.SetString("Task", Task);
        }

        protected abstract string GetSolution(string input);
        public void OnPostCheckAnswer()
        {
            //Task = HttpContext.Session.GetString("Task");
            string correct = GetSolution(Task);
            if (UserGuess == null)
                UserGuess = "";
            if (correct == null)
            {
                Result = "Very funny. Get a task first.";
                return;
            }
            if (Sanitize(UserGuess) == Sanitize(correct))
                Result = "Correct!";
            else
                Result = $"Correct : {correct}, looser!";
        }

        protected string Sanitize(string input) => input.Trim().Trim('.');
    }
}
