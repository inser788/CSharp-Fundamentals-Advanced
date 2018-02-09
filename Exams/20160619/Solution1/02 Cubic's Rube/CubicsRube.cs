using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _02_Cubic_s_Rube
{
    class CubicsRube
    {
        static void Main()
        {
            int sizeOfCube = int.Parse(Console.ReadLine());

            int allElementsInCube = (int)Math.Pow(sizeOfCube, 3);
            BigInteger sumAllStrikes = 0;
            while (true)
            {
                string input = Console.ReadLine();
                if(input=="Analyze")
                    break;

                int[] tokens = input.Split()
                    .Select(int.Parse)
                    .ToArray();

                int[] currentTargetPoint = tokens.Take(3).ToArray();

                int currentDamage = tokens.Last();

                if (!isInCube(currentTargetPoint,sizeOfCube)||currentDamage==0)
                {
                    continue;
                }

                sumAllStrikes += currentDamage;
                allElementsInCube--;
            }

            Console.WriteLine(sumAllStrikes);
            Console.WriteLine(allElementsInCube);
        }

        static bool isInCube(int[] array, int size)
        {
            for (int i = 0; i < array.Length; i++)
            {
                int currentElement = array[i];
                if (currentElement>size-1||currentElement<0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
