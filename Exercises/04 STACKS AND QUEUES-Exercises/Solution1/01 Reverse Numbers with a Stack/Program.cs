using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Reverse_Numbers_with_a_Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var stackNumbers=new Stack<int>(input.Split().Where(a=>a!="").Select(int.Parse));

            while (stackNumbers.Count>0)
            {
                Console.Write(stackNumbers.Pop()+" ");
            }
        }
    }
}
