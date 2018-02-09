using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Jedi_Meditation
{
    class JediMeditation
    {
        static void Main()
        {
            int numberOfInputLines = int.Parse(Console.ReadLine());

            var players=new Queue<string>();
            var masters = new Queue<string>();
            var knights = new Queue<string>();
            var padwans = new Queue<string>();

            bool haveYodaIn = false;

            for (int i = 0; i < numberOfInputLines; i++)
            {
                string[] prayers = Console.ReadLine()
                    .Split()
                    .ToArray();

                foreach (var prayer in prayers)
                {
                    if (prayer.StartsWith("m"))
                    {
                        masters.Enqueue(prayer);
                    }
                    else if (prayer.StartsWith("k"))
                    {
                        knights.Enqueue(prayer);
                    }
                    else if (prayer.StartsWith("p"))
                    {
                        padwans.Enqueue(prayer);
                    }
                    else if (prayer.StartsWith("s"))
                    {
                        players.Enqueue(prayer);
                    }
                    else if (prayer.StartsWith("t"))
                    {
                        players.Enqueue(prayer);
                    }
                    else if (prayer.StartsWith("y"))
                    {
                        haveYodaIn = true;
                    }
                }
            }

            if (haveYodaIn)
            {
                Console.Write(string.Join(" ",masters)+" ");
                Console.Write(string.Join(" ", knights) + " ");
                Console.Write(string.Join(" ", players) + " ");
                Console.Write(string.Join(" ", padwans));
            }
            else
            {
                Console.Write(string.Join(" ", players) + " ");
                Console.Write(string.Join(" ", masters) + " ");
                Console.Write(string.Join(" ", knights) + " ");
                Console.Write(string.Join(" ", padwans));
            }
        }
    }
}
