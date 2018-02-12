using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00_test
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfLines = int.Parse(Console.ReadLine());

            var builder = new StringBuilder();

            for (int i = 0; i < numberOfLines; i++)
            {
                builder.Append(Console.ReadLine());
            }

            Console.WriteLine();
        }
    }
}
