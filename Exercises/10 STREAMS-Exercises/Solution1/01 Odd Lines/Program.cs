using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Odd_Lines
{
    class OddLines
    {
        private const string path = "../../Files/";

        static void Main()
        {
            Console.WriteLine($"Print odd lines from file '{path}text.txt'\n");

            using (var reader = new StreamReader($"{path}/text.txt"))
            {
                int lineNumber = 0;

                while (true)
                {
                    string line = reader.ReadLine();
                    if (line == null) break;

                    if (lineNumber % 2 != 0)
                    {
                        Console.WriteLine($"Line {lineNumber}: {line}");
                    }
                    lineNumber++;
                }
            }
        }
    }
}
