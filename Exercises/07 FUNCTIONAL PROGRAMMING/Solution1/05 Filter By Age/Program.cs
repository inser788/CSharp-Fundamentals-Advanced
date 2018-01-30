using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Filter_By_Age
{
    class Program
    {
        static void Main()
        {
            var listOfNamesAndAge = GetListOfNamesAndAge();

            GetConditionAndOrderNames(listOfNamesAndAge);
            PrintNames(listOfNamesAndAge);
            Console.WriteLine();
        }

        private static List<KeyValuePair<string, int>> GetConditionAndOrderNames(List<KeyValuePair<string, int>> list)
        {
            string condition = Console.ReadLine();
            int ageCondition = int.Parse(Console.ReadLine());
            string[] printValue = Console.ReadLine()
                .Split()
                .ToArray();
            if (condition == "younger")
            {
                foreach (var element in list)
                {
                    if (element.Value>ageCondition)
                    {
                        list.Remove(element);
                    }
                }
            }
            else
            {
                list = list.Where(x => x.Value >= ageCondition).ToList();
            }

            return list;
        }


        private static void PrintNames(object getConditionAndOrderNames)
        {
            return;
            
        }

        private static List<KeyValuePair<string, int>> GetListOfNamesAndAge()
        {
            var listOfNamesAndAge = new List<KeyValuePair<string, int>>();

            int numberOfInputs = int.Parse(Console.ReadLine());
            listOfNamesAndAge = new List<KeyValuePair<string, int>>();
            for (int i = 0; i < numberOfInputs; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(',')
                    .ToArray();
                string name = input[0];
                int age = int.Parse(input[1]);
                listOfNamesAndAge.Add(new KeyValuePair<string, int>(name, age));
            }

            return listOfNamesAndAge;
        }
    }
}
