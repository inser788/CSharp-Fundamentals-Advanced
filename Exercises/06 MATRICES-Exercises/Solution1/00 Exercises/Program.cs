using System;
using System.Linq;

namespace E05_RubiksMatrix
{
    public class RubiksMatrix
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            int pointIndex = input.IndexOf(".");
            Console.WriteLine(input.Substring(pointIndex+2,1));
        }
    }
}