using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _04_Cubic_Assault
{

    class CubikAssault
    {
        static void Main()
        {
            var regionsAndArmy = new SortedDictionary<string, SortedDictionary<string, long>>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Count em all")
                    break;

                string[] regionData = input
                    .Split(new[] {" -> "}, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string regionName = regionData[0];
                string meteorType = regionData[1];
                long countArmy = long.Parse(regionData[2]);

                if (!regionsAndArmy.ContainsKey(regionName))
                {
                    regionsAndArmy[regionName] = new SortedDictionary<String, long>();
                    regionsAndArmy[regionName]["Black"] = 0;
                    regionsAndArmy[regionName]["Green"] = 0;
                    regionsAndArmy[regionName]["Red"] = 0;
                }

                regionsAndArmy[regionName][meteorType] += countArmy;

            }

            foreach (var region in regionsAndArmy)
            {
                if (regionsAndArmy[region.Key]["Green"] / 1000000 >= 1|| regionsAndArmy[region.Key]["Green"] / 1000000 <= -1)
                {
                    long addRedMeteors = regionsAndArmy[region.Key]["Green"] / 1000000;
                    regionsAndArmy[region.Key]["Red"] += addRedMeteors;
                    long leftGreenMeteor = regionsAndArmy[region.Key]["Green"] % 1000000;
                    regionsAndArmy[region.Key]["Green"] = leftGreenMeteor;
                }

                if (regionsAndArmy[region.Key]["Red"] / 1000000 >= 1 || regionsAndArmy[region.Key]["Red"] / 1000000 <= -1)
                {
                    long addBlackMeteors = regionsAndArmy[region.Key]["Red"] / 1000000;
                    regionsAndArmy[region.Key]["Black"] += addBlackMeteors;
                    long leftRedMeteor = regionsAndArmy[region.Key]["Red"] % 1000000;
                    regionsAndArmy[region.Key]["Red"] = leftRedMeteor;
                }
            }

            var regions = regionsAndArmy
                .Select(m => new
                {
                    RegionName = m.Key,
                    BlackMeteors = m.Value["Black"]
                })
                .OrderByDescending(r => r.BlackMeteors)
                .ThenBy(r => r.RegionName.Length);

            foreach (var r in regions)
            {
                Console.WriteLine(r.RegionName);
                regionsAndArmy[r.RegionName]
                    .OrderByDescending(x => x.Value)
                    .ThenBy(x=>x.Key)
                    .ToList()
                    .ForEach(c => Console.WriteLine($"-> {c.Key} : {c.Value}"));
            }

        }
    }
}
