using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _01_Regeh
{
    class Regeh
    {
        static void Main()
        {
            var input = Console.ReadLine();
            var pattern = @"\[[A-Za-z]+<([0-9]+)REGEH([0-9]+)>[A-Za-z]+\]";
            var matches = Regex.Matches(input, pattern);
            var allIndexes = new List<int>();

            foreach (Match match in matches)
            {
                allIndexes.Add(int.Parse(match.Groups[1].Value));
                allIndexes.Add(int.Parse(match.Groups[2].Value));
            }
            var currentIndex = 0;

            foreach (var index in allIndexes)
            {
                currentIndex += index;
                int charIndex = currentIndex % input.Length;
                Console.Write(input[charIndex]);
            }
        }
    }
}
