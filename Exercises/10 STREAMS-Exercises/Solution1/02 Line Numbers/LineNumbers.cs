using System;
using System.IO;

namespace _02_Line_Numbers
{
    class LineNumbers
    {
        private const string path = "../../Files/";

        static void Main()
        {
            Console.WriteLine($"Read file '{path}text.txt'");
            Console.WriteLine($"Insert line numbers & write text to '{path}output.txt'");

            using (var reader = new StreamReader($"{path}text.txt"))
            {
                using (var writer = new StreamWriter($"{path}output.txt"))
                {
                    int lineNumbers = 0;
                    while (true)
                    {
                        string line = reader.ReadLine();
                        if (line == null) break;

                        writer.WriteLine($"Line {++lineNumbers}: {line}");
                    }
                }
            }
        }
    }
}
