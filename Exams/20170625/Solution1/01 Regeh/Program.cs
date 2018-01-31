using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _01_Regeh
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\[[\S]+?<(?<regeh>(\d+)REGEH(\d+))>[\S]+?\]";
            string input = Console.ReadLine();
            var list=new List<string>();
            var matches = Regex.Matches(input, pattern);
            foreach (Match match in matches)
            {
                list.Add(match.ToString());
            }

            Console.WriteLine(string.Join("\n",list));
        }
    }
}
