using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Krucible
{
    using Vocabulary = Dictionary<string, string>;
    static public class Sogang_1A_Vocabulary
    {
        private static Dictionary<string, string> Lesson1;
        private static Dictionary<string, string> Lesson2;
        private static Dictionary<string, string> Lesson3;
        private static Dictionary<string, string> Lesson4;
        public static Vocabulary Test = new Vocabulary
        {
            { "1", "2" },
            { "3", "4" }
        };

        public static Vocabulary[] Lessons = new Vocabulary[]
        {
            Test,
            Lesson1,
            Lesson2,
            Lesson3,
            Lesson4
        };
    }
}
