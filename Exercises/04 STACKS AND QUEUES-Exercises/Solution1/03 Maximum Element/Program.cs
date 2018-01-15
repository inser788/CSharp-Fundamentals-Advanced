using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Maximum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int timesOperation = int.Parse(Console.ReadLine());
            var stackElements = new Stack<int>();
            var maxElements = new Stack<int>();
            int maxValue = 0;
            for (int i = 0; i < timesOperation; i++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

                if (input[0] == 1)
                {
                    stackElements.Push(input.Last());
                    if (input.Last() > maxValue)
                    {
                        maxValue = input.Last();
                        maxElements.Push(maxValue);
                    }
                }
                else if (input[0] == 2)
                {
                    if (stackElements.Pop() == maxValue)
                    {
                        maxElements.Pop();
                        if (stackElements.Count != 0)
                        {
                            maxValue = maxElements.Peek();
                        }
                        else
                        {
                            maxValue = 0;
                        }
                    }
                }
                else if (input[0] == 3)
                {
                    Console.WriteLine(maxValue);
                }
            }
        }
    }
}
