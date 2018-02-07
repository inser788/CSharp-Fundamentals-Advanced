using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _04_Treasure_Map
{
    class TreasureMap
    {
        static void Main()
        {
            string pattern =
                @"(\#[^\#\!]*?\b([A-Za-z]{4})\b[^\#\!]*(\d{3}-\d{4,6})[^\#\!]*\!)|(\![^\#\!]*?\b([A-Za-z]{4})\b[^\#\!]*(\d{3}-\d{4,6})[^\#\!]*\#)";
            string matchedPattern = @"[^\#\!]*?\b([A-Za-z]{4})\b[^\#\!]*(\d{3}-\d{4,6})[^\#\!]*";
            int numberOfLines = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfLines; i++)
            {
                string currentInput = Console.ReadLine();
                var matches = Regex.Matches(currentInput, pattern);
                int countMatches = matches.Count;

                int searchedMatch = (countMatches / 2) + 1;
                int counter = 1;
                foreach (Match match in matches)
                {
                    if (counter != searchedMatch)
                    {
                        counter++;
                        continue;
                    }
                    else
                    {
                        var matchResult = Regex.Match(match.ToString(), matchedPattern);
                        var streetName = matchResult.Groups[1].ToString();
                        var numbers = matchResult.Groups[2].ToString().Split('-').ToArray();
                        string streetNumber = numbers[0];
                        string password = numbers[1];
                        Console.Write($"Go to str. {streetName} {streetNumber}. ");
                        Console.WriteLine($"Secret pass: {password}.");
                        break;

                    }

                }
            }
        }
    }
}
