using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _04_Hit_List
{
    class HitList
    {
        static void Main()
        {
            var nameAndData = new Dictionary<string, SortedDictionary<string, string>>();

            int targetInfoIndex = int.Parse(Console.ReadLine());

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end transmissions")
                    break;

                string[] dataReceived = input
                    .Split("=;".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string currentName = dataReceived[0];

                if (!nameAndData.ContainsKey(currentName))
                {
                    nameAndData[currentName] = new SortedDictionary<string, string>();
                }

                for (int i = 1; i < dataReceived.Length; i++)
                {
                    var currentLine = dataReceived[i].Split(':').ToArray();
                    var currentKey = currentLine[0];
                    var currentValue = currentLine[1];
                    if (!nameAndData[currentName].ContainsKey(currentKey))
                    {
                        nameAndData[currentName][currentKey] = string.Empty;
                    }

                    nameAndData[currentName][currentKey] = currentValue;
                }

            }

            string command = Console.ReadLine();
            string nameForKill = command.Substring(5);

            foreach (var name in nameAndData)
            {
                int keysLength = 0;
                int valuesLength = 0;
                int totalLength = 0;

                if (name.Key == nameForKill)
                {
                    Console.WriteLine($"Info on {nameForKill}:");
                    foreach (var kvp in name.Value)
                    {
                        Console.WriteLine($"---{kvp.Key}: {kvp.Value}");
                        keysLength += kvp.Key.Length;
                        valuesLength += kvp.Value.Length;
                    }

                    totalLength = keysLength + valuesLength;
                    Console.WriteLine($"Info index: {totalLength}");
                    if (totalLength >= targetInfoIndex)
                    {
                        Console.WriteLine($"Proceed");
                    }
                    else
                    {
                        Console.WriteLine($"Need {targetInfoIndex - totalLength} more info.");
                    }
                }
            }
        }
    }
}
