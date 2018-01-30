using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Applied_Arithmetics
{
    class Program
    {
        static void Main()
        {
            var listOfNumbers = Console.ReadLine()
                .Split()
                .Select(long.Parse)
                .ToList();
            GetModifyedList(listOfNumbers);
        }

        private static void GetModifyedList(List<long> listOfNumbers)
        {
            while (true)
            {
                string command = Console.ReadLine();
                if (command=="end")
                    break;
                switch (command)
                {
                    case "add":
                        listOfNumbers = listOfNumbers.Select(x => x +1).ToList();
                        break;
                    case "multiply":
                        listOfNumbers = listOfNumbers.Select(x => x * 2).ToList();
                        break;
                    case "subtract":
                        listOfNumbers = listOfNumbers.Select(x => x - 1).ToList();
                        break;
                    case "print":
                        Console.WriteLine(string.Join(" ",listOfNumbers));
                        break;
                }    
                
            }
        }
    }
}
