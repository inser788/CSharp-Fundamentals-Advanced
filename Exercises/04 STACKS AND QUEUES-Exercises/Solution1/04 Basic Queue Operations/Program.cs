﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Basic_Queue_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] addRemoveContainElemnt = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            var queue=new Queue<int>();
            int addElements = addRemoveContainElemnt[0];
            int removeElements = addRemoveContainElemnt[1];
            int containElement = addRemoveContainElemnt[2];
            for (int i = 0; i < addElements; i++)
            {
                queue.Enqueue(numbers[i]);
            }

            for (int i = 0; i < Math.Min(addElements,removeElements); i++)
            {
                queue.Dequeue();
            }

            if (queue.Count==0)
            {
                Console.WriteLine(0);
            }
            else
            {
                if (queue.Contains(containElement))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine(queue.Min());
                }
            }
        }
    }
}
