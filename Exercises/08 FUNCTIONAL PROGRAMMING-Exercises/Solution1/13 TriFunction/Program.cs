using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13_TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            var sum = int.Parse(Console.ReadLine());
            var names = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Func<string, int> sumChars = str => str.ToCharArray().Sum(ch => ch);
            Func<string, int, bool> isEqualOrLargerSum = (str, n) => sumChars(str) >= n;

            var name = names.FirstOrDefault(n => isEqualOrLargerSum(n, sum));
            Console.WriteLine(name);
        }
    }
}
