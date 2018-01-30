using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _08_Custom_Comparator
{
    class Program
    {
        static void Main(string[] args)
        {
            var listOfNumbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            var listOfEven = listOfNumbers.Where(x => x % 2 == 0).OrderBy(x=>x).ToList();
            listOfNumbers = listOfNumbers.Where(x => x % 2 != 0).OrderBy(x => x).ToList();
            listOfEven = listOfEven.Concat(listOfNumbers).ToList();
            Console.WriteLine(string.Join(" ",listOfEven));
        }
        


    }
}
