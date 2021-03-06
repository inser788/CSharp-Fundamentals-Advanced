﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split();
            Array.Reverse(input);
            var stack=new Stack<string>();
            for (int i = 0; i < input.Length; i++)
            {
                stack.Push(input[i]);
            }

            while (stack.Count>1)
            {
                int firstNumber = int.Parse(stack.Pop());
                string operand = stack.Pop();
                int secondNumber = int.Parse(stack.Pop());

                if (operand=="+")
                {
                    stack.Push((firstNumber+secondNumber).ToString());
                }
                else
                {
                    stack.Push((firstNumber-secondNumber).ToString());
                }
            }

            Console.WriteLine(stack.Pop());


        }
    }
}
