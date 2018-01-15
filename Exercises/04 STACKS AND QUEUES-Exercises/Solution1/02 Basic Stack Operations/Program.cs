using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Basic_Stack_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] pushPopContainElements = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] elements = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var stackElements=new Stack<int>();
            int pushTimes = pushPopContainElements.First();
            int popTimes = pushPopContainElements.Skip(1).First();
            int containElement = pushPopContainElements.Last();
            for (int i = 0; i < pushTimes; i++)
            {
              stackElements.Push(elements[i]);
            }

            for (int i = 0; i < Math.Min(popTimes,pushTimes); i++)
            {
                stackElements.Pop();
            }

            if (stackElements.Count==0)
            {
                Console.WriteLine(0);
            }
            else if (stackElements.Contains(containElement))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(stackElements.Min());
            }
            
        }
    }
}
