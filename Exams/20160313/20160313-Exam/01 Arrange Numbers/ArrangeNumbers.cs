using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Arrange_Numbers
{
    class ArrangeNumbers
    {
        static void Main()
        {
            var listOfNumbers = Console.ReadLine()
                .Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string[] wordValues = {"zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"};

            var tempResult=new List<KeyValuePair<string,string>>();
            for (int i = 0; i < listOfNumbers.Count; i++)
            {
                var currentNumber = listOfNumbers[i].ToCharArray();
                string keyResult = string.Empty;
                string valueResult = string.Empty;

                for (int j = 0; j < currentNumber.Length; j++)
                {
                    if (currentNumber[j]=='0')
                    {
                        keyResult += 0;
                        valueResult += wordValues[0];
                    }
                    else if (currentNumber[j]=='1')
                    {
                        keyResult += 1;
                        valueResult += wordValues[1];
                    }
                    else if (currentNumber[j] == '2')
                    {
                        keyResult += 2;
                        valueResult += wordValues[2];
                    }
                    else if (currentNumber[j] == '3')
                    {
                        keyResult += 3;
                        valueResult += wordValues[3];
                    }
                    else if (currentNumber[j] == '4')
                    {
                        keyResult += 4;
                        valueResult += wordValues[4];
                    }
                    else if (currentNumber[j] == '5')
                    {
                        keyResult += 5;
                        valueResult += wordValues[5];
                    }
                    else if (currentNumber[j] == '6')
                    {
                        keyResult += 6;
                        valueResult += wordValues[6];
                    }
                    else if (currentNumber[j] == '7')
                    {
                        keyResult += 7;
                        valueResult += wordValues[7];
                    }
                    else if (currentNumber[j] == '8')
                    {
                        keyResult += 8;
                        valueResult += wordValues[8];
                    }
                    else if (currentNumber[j] == '9')
                    {
                        keyResult += 9;
                        valueResult += wordValues[9];
                    }
                }
                tempResult.Add(new KeyValuePair<string, string>(keyResult,valueResult));
            }

            var finalResult = tempResult.OrderBy(x => x.Value).Select(x => x.Key).ToArray();
            Console.WriteLine(string.Join(", ",finalResult));
        }
    }
}
