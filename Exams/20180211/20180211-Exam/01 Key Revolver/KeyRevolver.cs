﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Key_Revolver
{
    class KeyRevolver
    {
        static void Main()
        {
            long priceOfBullet = long.Parse(Console.ReadLine());
            int sizeOfBarrel = int.Parse(Console.ReadLine());
            var bulletsTemp = Console.ReadLine()
                .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToList();
            var locks = Console.ReadLine()
                .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToList();
            long valueIntelligence = long.Parse(Console.ReadLine());

            var bullets = new List<long>();
            for (int i = bulletsTemp.Count - 1; i >= 0; i--)
            {
                bullets.Add(bulletsTemp[i]);
            }

            int tempBarrelCount = sizeOfBarrel;
            int bulletsCount = 0;
            for (int i = 0; i <= bullets.Count; i++)
            {
                var bulletPower = bullets.First();
                var lockPower = locks.First();
                if (bulletPower > lockPower)
                {
                    Console.WriteLine("Ping!");
                }
                else
                {
                    locks.RemoveAt(0);
                    Console.WriteLine("Bang!");
                }

                tempBarrelCount--;
                bullets.RemoveAt(0);
                i = 0;
                bulletsCount++;

                if (locks.Count == 0)
                {
                    if (tempBarrelCount == 0&&bullets.Count>0)
                    {
                        Console.WriteLine("Reloading!");
                    }

                    Console.WriteLine(
                        $"{bullets.Count} bullets left. Earned ${valueIntelligence - (bulletsCount * priceOfBullet)}");
                    return;
                }

                if (bullets.Count == 0)
                {
                    Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
                    return;
                }

                if (tempBarrelCount == 0)
                {
                    Console.WriteLine("Reloading!");
                    tempBarrelCount = sizeOfBarrel;
                }
            }
        }
    }
}
