using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfStations = int.Parse(Console.ReadLine());
            var pumpsInformation = new Queue<long[]>();

            for (int i = 0; i < numberOfStations; i++)
            {
                var input = Console.ReadLine()
                    .Split()
                    .Select(long.Parse)
                    .ToArray();
                pumpsInformation.Enqueue(input);
            }

            for (int i = 0; i < numberOfStations; i++)
            {
                long totalPetrol = 0;
                long totalDistance = 0;
                bool isFound = true;
                foreach (var pump in pumpsInformation)
                {
                    totalPetrol += pump.First();
                    totalDistance += pump.Last();
                    if (totalPetrol<totalDistance)
                    {
                        isFound = false;
                        totalPetrol = 0;
                        totalDistance = 0;
                    }
                }
                if (isFound)
                {
                    Console.WriteLine(i);
                    break;
                }
                pumpsInformation.Enqueue(pumpsInformation.Dequeue());
            }
        }
    }
}
