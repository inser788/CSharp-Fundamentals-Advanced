using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Sequence_With_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            long firstElement = long.Parse(Console.ReadLine());
            var sequance = new Queue<long>();
            var sequanceElements = new Queue<long>();
            sequance.Enqueue(firstElement);
            while (sequance.Count < 50)
            {
                sequance.Enqueue(firstElement+1);
                sequanceElements.Enqueue(firstElement + 1);
                if (sequance.Count<50)
                {
                    sequance.Enqueue(2*firstElement+1);
                    sequanceElements.Enqueue(2 * firstElement + 1);
                }

                if (sequance.Count<50)
                {
                    sequance.Enqueue(firstElement+2);
                    sequanceElements.Enqueue(firstElement + 2);
                    firstElement = sequanceElements.Dequeue();
                }
            }
            Console.WriteLine(string.Join(" ",sequance));
        }
    }
}
