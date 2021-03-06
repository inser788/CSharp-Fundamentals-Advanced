﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _04_Olympics_Are_Coming
{
    class Program
    {
        static void Main(string[] args)
        {
            var dataForCountries = new Dictionary<string, Dictionary<string, int>>();
            string pattern = @"\s*\|\s*";
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "report")
                    break;

                var dataInput = Regex.Split(input, pattern);

                var athletNameList = dataInput.First().Split(" \t".ToCharArray()).Where(s => !string.IsNullOrWhiteSpace(s));
                string athletName = string.Join(" ", athletNameList);
                var countryNameList = dataInput.Last().Split(" \t".ToCharArray()).Where(s => !string.IsNullOrWhiteSpace(s));
                string countryName = string.Join(" ", countryNameList);
                if (!dataForCountries.ContainsKey(countryName))
                {
                    dataForCountries[countryName] = new Dictionary<string, int>();
                    dataForCountries[countryName].Add(athletName, 1);
                    continue;
                }

                if (!dataForCountries[countryName].ContainsKey(athletName))
                {
                    dataForCountries[countryName][athletName] = 1;
                    continue;
                }

                dataForCountries[countryName][athletName]++;
            }

            var orderedCountries = dataForCountries.OrderByDescending(x => x.Value.Values.Sum())
                .ToDictionary(k => k.Key, v => v.Value);
            foreach (var item in orderedCountries)
            {
                Console.WriteLine(
                    $"{item.Key} ({item.Value.Keys.Count()} participants): {item.Value.Values.Sum()} wins");
            }
        }
    }
}