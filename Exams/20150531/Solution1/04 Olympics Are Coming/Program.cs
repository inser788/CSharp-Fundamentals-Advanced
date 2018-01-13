using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Olympics_Are_Coming
{
    class Program
    {
        static void Main(string[] args)
        {
            var dataForCountries = new Dictionary<string, Dictionary<string, int>>();

            while (true)
            {
                string input = Console.ReadLine().Trim();
                if (input == "report")
                    break;
                string[] dataInput = input.Trim().Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                string athletName = dataInput.First().Trim();
                string athletNameOriginal = string.Join(" ", athletName.Split(" \t\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries));
                athletNameOriginal = athletNameOriginal.Trim();
                string countryName = dataInput.Last().Trim();
                if (!dataForCountries.ContainsKey(countryName))
                {
                    dataForCountries[countryName] = new Dictionary<string, int>();
                    dataForCountries[countryName].Add(athletNameOriginal, 1);
                }
                else
                {
                    if (!dataForCountries[countryName].ContainsKey(athletNameOriginal))
                    {
                        dataForCountries[countryName][athletNameOriginal] = 1;
                    }
                    else
                    {
                        dataForCountries[countryName][athletNameOriginal] ++;
                    }
                }
            }
            var orderedCountries = dataForCountries.OrderByDescending(x => x.Value.Values.Sum())
                .ToDictionary(k => k.Key, v => v.Value);
            foreach (var item in orderedCountries)
            {
                Console.WriteLine($"{item.Key} ({item.Value.Keys.Count()} participants): {item.Value.Values.Sum()} wins");
            }
        }
    }
}
