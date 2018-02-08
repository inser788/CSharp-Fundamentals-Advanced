using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Greedy_Times
{
    class GreedyTimes
    {
        static void Main()
        {
            long goldCapacity = 0;
            var gemsCapacity = new Dictionary<string, long>();
            var gemsNamesUpper=new List<string>();
            var cashCapacity = new Dictionary<string, long>();
            var cashNamesUpper=new List<string>();

            long maxCashValue = long.Parse(Console.ReadLine());
            long allSumInbag = 0;
            var inputList = Console.ReadLine()
                .Split(" \t\n".ToCharArray(),StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            var valuableItemsNames = inputList
                .Where((v, i) => i % 2 == 0)
                .ToList();
            var valuableItemsQuantities = inputList
                .Where((v, i) => i % 2 == 1)
                .Select(long.Parse)
                .ToList();
            int counter = 0;
            while (true)
            {
                if (allSumInbag >= maxCashValue)
                    break;
                if (counter == valuableItemsNames.Count)
                    break;

                foreach (var item in valuableItemsNames.Zip(valuableItemsQuantities, Tuple.Create))
                {
                    counter++;
                    

                    var key = item.Item1;
                    var upperName = item.Item1.ToUpperInvariant();
                    if (upperName == "GOLD" && goldCapacity >= gemsCapacity.Values.Sum())
                    {
                        if ((allSumInbag + item.Item2) <= maxCashValue)
                        {
                            goldCapacity += item.Item2;
                            allSumInbag = goldCapacity + gemsCapacity.Values.Sum() + cashCapacity.Values.Sum();
                        }
                    }


                    else if (upperName.EndsWith("GEM") && key.Length > 3 )
                    {
                        if ((allSumInbag + item.Item2) <= maxCashValue && goldCapacity >= gemsCapacity.Values.Sum()+ item.Item2)
                        {
                            if (!gemsCapacity.ContainsKey(key)&&!gemsNamesUpper.Contains(upperName))
                            {
                                gemsCapacity[key] = 0;
                                gemsNamesUpper.Add(upperName);
                            }

                            gemsCapacity[key] += item.Item2;
                            allSumInbag = goldCapacity + gemsCapacity.Values.Sum() + cashCapacity.Values.Sum();
                        }
                    }

                    else if (key.Length == 3&&key.All(a=>char.IsLetter(a)))
                    {
                        if ((allSumInbag + item.Item2) <= maxCashValue && gemsCapacity.Values.Sum() >= cashCapacity.Values.Sum()+ item.Item2)
                        {
                            if (!cashCapacity.ContainsKey(key)&&!cashNamesUpper.Contains(upperName))
                            {
                                cashCapacity[key] = 0;
                                cashNamesUpper.Add(upperName);
                            }

                            cashCapacity[key] += item.Item2;
                            allSumInbag = goldCapacity + gemsCapacity.Values.Sum() + cashCapacity.Values.Sum();
                        }
                    }
                }
            }

            if (goldCapacity!=0)
            {
                Console.WriteLine($"<Gold> ${goldCapacity}");
                Console.WriteLine($"##Gold - {goldCapacity}");
            }
           
            var orderedGems = gemsCapacity.OrderByDescending(x => x.Key)
                .ThenBy(x => x.Value).ToDictionary(k => k.Key, v => v.Value);
            if (orderedGems.Keys.Count != 0)
            {
                Console.WriteLine($"<Gem> ${orderedGems.Values.Sum()}");
                foreach (var item in orderedGems)
                {
                    Console.WriteLine($"##{item.Key} - {item.Value}");
                }
            }

            var orderedCash = cashCapacity.OrderByDescending(x => x.Key)
                .ThenBy(x => x.Value).ToDictionary(k => k.Key, v => v.Value);
            if (orderedCash.Keys.Count != 0)
            {
                Console.WriteLine($"<Cash> ${orderedCash.Values.Sum()}");
                foreach (var item in orderedCash)
                {
                    Console.WriteLine($"##{item.Key} - {item.Value}");
                }
            }
        }
    }
}
