using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _03_Cubic_Messages
{
    class CubicMessage
    {
        static void Main()
        {
            string pattern = @"^([\d]+)([a-zA-Z]+)([^a-zA-Z]*?)$";

            while (true)
            {
                string input = Console.ReadLine();
                if(input=="Over!")
                    break;

                int lengthOfWord = int.Parse(Console.ReadLine());

                var match = Regex.Match(input, pattern);
                if (!match.Success&&match.Groups[2].Length!=lengthOfWord)
                {
                    continue;
                }

                string digitsBeforeWord = match.Groups[1].ToString();
                var listDigitsBefore = digitsBeforeWord
                    .ToCharArray()
                    .Select(x => int.Parse(x.ToString()))
                    .ToList();
                string word = match.Groups[2].ToString();
                char[] allSymbolsAfterWord = match.Groups[3].ToString().ToCharArray();
                var listOfDigitsAfter = allSymbolsAfterWord
                    .Where(a => char.IsDigit(a))
                    .Select(x => int.Parse(x.ToString()))
                    .ToList();
               var verificatonCode = new StringBuilder();
                for (int i = 0; i < listDigitsBefore.Count; i++)
                {
                    int currentElement = listDigitsBefore[i];
                    if (currentElement>word.Length-1)
                    {
                        verificatonCode.Append(" ");
                        continue;
                    }

                    verificatonCode.Append(word[currentElement]) ;
                }

                for (int i = 0; i < listOfDigitsAfter.Count; i++)
                {
                    int currentElement = listOfDigitsAfter[i];
                    if (currentElement > word.Length - 1)
                    {
                        verificatonCode.Append(" ");
                        continue;
                    }

                    verificatonCode.Append(word[currentElement]);
                }
                Console.WriteLine($"{word} == {verificatonCode}");
            }
        }
    }
}
