﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_Predicate_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            var initialListOfGuests = Console.ReadLine()
                .Split()
                .ToList();
            var actualListOfGuest = GetActualListOfGuests(initialListOfGuests);
            if (actualListOfGuest.Count!=0)
            {
            Console.WriteLine(string.Join(", ", actualListOfGuest)+ " are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }

        private static List<string> GetActualListOfGuests(List<string> initialListOfGuests)
        {
            var actionList = initialListOfGuests.ToList();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Party!")
                    break;
                var commandActions = input.Split().ToArray();
                string action = commandActions[0];
                string criteria = commandActions[1];
                string actionOption = commandActions[2];
                if (action == "Remove")
                {
                    switch (criteria)
                    {
                        case "StartsWith":
                            actionList.RemoveAll(x => x.StartsWith(actionOption));
                            break;
                        case "EndsWith":
                            actionList.RemoveAll(x => x.EndsWith(actionOption));
                            break;
                        case "Length":
                            int lengthWord = int.Parse(actionOption);
                            actionList.RemoveAll(x => x.Length == lengthWord);
                            break;
                    }
                }
                else if (action == "Double")
                {
                    switch (criteria)
                    {
                        case "StartsWith":
                            for (int i = 0; i < actionList.Count; i++)
                            {
                                string currentName = actionList[i];
                                if (currentName.StartsWith(actionOption))
                                {
                                    actionList.Insert(i, currentName);
                                    i++;
                                }
                            }
                            break;
                        case "EndsWith":
                            for (int i = 0; i < actionList.Count; i++)
                            {
                                string currentName = actionList[i];
                                if (currentName.EndsWith(actionOption))
                                {
                                    actionList.Insert(i, currentName);
                                    i++;
                                }
                            }
                            break;
                        case "Length":
                            int lengthWord = int.Parse(actionOption);
                            for (int i = 0; i < actionList.Count; i++)
                            {
                                string currentName = actionList[i];
                                if (currentName.Length == lengthWord)
                                {
                                    actionList.Insert(i, currentName);
                                    i++;
                                }
                            }
                            break;
                    }
                }
            }
            return actionList;
        }
    }
}
