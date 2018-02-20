using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_Greedy_Times
{
    class GreedyTimes
    {
        static void Main()
        {
            var goldCapacity = new Dictionary<string, long>();
            var gemsCapacity = new Dictionary<string, long>();
            var cashCapacity = new Dictionary<string, long>();

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
                    var upperName = item.Item1.ToUpper();
                    if (upperName == "GOLD" && goldCapacity.Values.Sum() >= gemsCapacity.Values.Sum())
                    {
                        if ((allSumInbag + item.Item2) <= maxCashValue)
                        {
                            if (!goldCapacity.ContainsKey(key))
                            {
                                goldCapacity[key] = 0;
                            }
                            goldCapacity[key] += item.Item2;
                            allSumInbag = goldCapacity.Values.Sum() + gemsCapacity.Values.Sum() + cashCapacity.Values.Sum();
                        }
                    }

                    else if (upperName.EndsWith("GEM") && key.Length > 3 )
                    {
                        if ((allSumInbag + item.Item2) <= maxCashValue && goldCapacity.Values.Sum() >= gemsCapacity.Values.Sum()+ item.Item2)
                        {
                            if (!gemsCapacity.ContainsKey(key))
                            {
                                gemsCapacity[key] = 0;
                            }

                            gemsCapacity[key] += item.Item2;
                            allSumInbag = goldCapacity.Values.Sum() + gemsCapacity.Values.Sum() + cashCapacity.Values.Sum();
                        }
                    }

                    else if (key.Length == 3&&key.All(a=>char.IsLetter(a)))
                    {
                        if ((allSumInbag + item.Item2) <= maxCashValue && gemsCapacity.Values.Sum() >= cashCapacity.Values.Sum()+ item.Item2)
                        {
                            if (!cashCapacity.ContainsKey(key))
                            {
                                cashCapacity[key] = 0;
                            }

                            cashCapacity[key] += item.Item2;
                            allSumInbag = goldCapacity.Values.Sum() + gemsCapacity.Values.Sum() + cashCapacity.Values.Sum();
                        }
                    }
                }
            }

          var orderedGold=goldCapacity.OrderByDescending(x => x.Key)
              .ThenBy(x => x.Value).ToDictionary(k => k.Key, v => v.Value);
            if (orderedGold.Keys.Count!=0)
            {
            Console.WriteLine($"<Gold> ${orderedGold.Values.Sum()}");
                foreach (var item in orderedGold)
                {
                    Console.WriteLine($"##{item.Key} - {item.Value}");
                }
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
