using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Krucible
{

    public class ParsingException : Exception
    {
        public ParsingException(string message) : base(message) { }
    }

    static public class Sogang_1A_Vocabulary
    {
        public static List<Vocabulary> Lessons;
        public static string[] Names = new string[]
        {
            "1A Getting Ready Unit 1",
            "1A Getting Ready Unit 2",
            "1A Getting Ready Unit 3",
            "1A Getting Ready Unit 4",
            "1A Unit 1",
            "1A Unit 2",
            "1A Unit 3",
            "1A Unit 4",
            "1A Unit 5",
            "1A Unit 6",
            "1B Unit 1"
        };

        public static void Init()
        {
            Lessons = new List<Vocabulary>();
            //string[] filepaths = System.IO.Directory.GetFiles("Vocabulary");
            string[] filepaths = new string[]
            {
                "Vocabulary/001_grUnit1.txt",
                "Vocabulary/002_grUnit2.txt",
                "Vocabulary/003_grUnit3.txt",
                "Vocabulary/004_grUnit4.txt",
                "Vocabulary/011_Unit1.txt",
                "Vocabulary/012_Unit2.txt",
                "Vocabulary/013_Unit3.txt",
                "Vocabulary/014_Unit4.txt",
                "Vocabulary/015_Unit5.txt",
                "Vocabulary/016_Unit6.txt",
                "Vocabulary/021_Unit1.txt"
            };
            var vocabs = filepaths.Select(fp => ParseFile(fp));
            foreach (var v in vocabs)
                Lessons.Add(v);
        }
        /// <summary>
        /// Input string should have format %korean% ; %english% ; %russian%
        /// Russian may be abcent. Other semicolons are not permitted
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        private static WordEntry ParseString(string input)
        {
            var splitted = input.Split(';');
            if (splitted.Length < 2)
                throw new ParsingException($"Too little semicolons in string {input}");
            if (splitted.Length > 3)
                throw new ParsingException($"Too much semicolons in string {input}");
            var korean = splitted[0];
            var english = splitted[1];
            if (korean == string.Empty)
                throw new ParsingException($"Empty Korean part in string {input}");
            if (english == string.Empty)
                throw new ParsingException($"Empty English part in string {input}");
            return new WordEntry(korean, english);
        }

        private static Vocabulary ParseFile(string filepath)
        {
            var contents = System.IO.File.ReadAllLines(filepath);
            IEnumerable<WordEntry> pairs;
            try
            {
                pairs = contents.Select(s => ParseString(s)).ToList();
            }
            catch (Exception e)
            {
                throw new ParsingException($"When processing file {filepath} got error: {e.Message}");
            }
            var vocab = new Vocabulary();
            foreach(var w in pairs)
            {
                vocab.Add(w);
            }
            return vocab;
        }

    }
}
