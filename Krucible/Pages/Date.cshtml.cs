using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KoreanTools;

namespace Krucible
{
    public class DateModel : PageModel
    {
        [BindProperty]
        public string dateTimeStr { get; set; }

        [BindProperty]
        public static DateTime dateTime { get; set; }
        [BindProperty]
        public string UserGuess { get; set; }
        [BindProperty]
        public string Result { get; set; }

        public void OnGet()
        {
            dateTime = DateTime.Now;
        }

        public void OnPostRandomDate()
        {
            Random rand = new Random();
            DateTime startDate = new DateTime(1, 1, 1);
            DateTime endDate = new DateTime(2999, 12, 31);
            int range = (endDate - startDate).Days;
            dateTime = startDate.AddDays(rand.Next(range));
            dateTimeStr = dateTime.ToString();
            //UserTranslation = "";
        }

        public void OnPostCheckAnswer()
        {
            dateTimeStr = Request.Form["xz"];
            dateTime = DateTime.Parse(dateTimeStr);
            string translation = DateTranslation.Translate(dateTime);
            if (UserGuess != null && translation == UserGuess.Trim())
                Result = "Correct!";
            else
            {
                UserGuess = $"Your try: {UserGuess}";
                Result = $"Correct : {translation}, looser!";
            }
        }
    }
}