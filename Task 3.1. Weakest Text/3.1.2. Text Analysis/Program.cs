using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3._1._2._Text_Analysis
{
    class Program
    {


        static void Main(string[] args)
        {
            Console.WriteLine("Please, enter the text you need to analyze:" + Environment.NewLine);

            string sourceText = Console.ReadLine();


            TextAnalyzer.Analyze(sourceText);
        }
    }
}
