using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_Reverse_And_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbersList = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            int number = int.Parse(Console.ReadLine());
            numbersList = numbersList.Where(x => x % number != 0).Reverse().ToList();
            Console.WriteLine(string.Join(" ",numbersList));
        }
    }
}
