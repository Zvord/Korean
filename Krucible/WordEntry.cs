using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Krucible
{
    public class WordEntry
    {
        public string Korean { get; }
        public string English { get; }
        public string Russian { get; }

        public WordEntry(string korean, string english) : this(korean, english, "") { }

        public WordEntry(string korean, string english, string russian)
        {
            Korean = korean;
            English = english;
            Russian = russian;
        }
    }
}
