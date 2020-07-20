using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3._1._2._Text_Analysis
{
    public class TextAnalyzer
    {

        static bool UniquenessCheck(int value, int count)
        {
            double uniquenessPercent = 5;

            if ((double)value * 100 / count > uniquenessPercent)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static void Analyze(string sourceText)
        {
            bool isUnique = true;

            //Список знаков пунтуации
            List<char> punctuationMarks = new List<char>()
            {
                '.',
                ',',
                ':',
                ';',
                '!',
                '?',
                ' ',
                '\r',
                '\n'
            };


            Dictionary<string, int> wordCounter =
                new Dictionary<string, int>();

            StringBuilder stringBuilder = new StringBuilder(sourceText.ToLower());

            var words = stringBuilder
                .ToString()
                .Split(punctuationMarks.ToArray(), StringSplitOptions.RemoveEmptyEntries);

            foreach (var elem in words)
            {
                if (wordCounter.ContainsKey(elem))
                {
                    wordCounter[elem]++;
                }
                else
                {
                    wordCounter.Add(elem, 1);
                }
            }

            //Вывод
            stringBuilder = new StringBuilder(Environment.NewLine + "Words and how many times they occur in the text:");
            stringBuilder.AppendLine();

            var orderedResult = wordCounter
                .OrderByDescending(e => e.Value)
                .ToArray();



            foreach (var elem in orderedResult)
            {
                stringBuilder.AppendLine($"{elem.Key} : {elem.Value}");

                //Встречается ли слово в тексте слишком часто
                if (!UniquenessCheck(elem.Value, words.Length))
                {
                    isUnique = false;
                }
            }

            Console.WriteLine(stringBuilder.ToString());

            if (isUnique)
            {
                Console.WriteLine("Your text is varied, congrats!");
            }
            else
            {
                Console.WriteLine("Your text doesn't have much variety, you'll need to work on that!");
            }
        }

    }
}
