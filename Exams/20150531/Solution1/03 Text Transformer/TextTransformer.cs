﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _03_Text_Transformer
{
    class TextTransformer
    {
        static void Main()
        {
            StringBuilder builder = new StringBuilder();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "burp")
                    break;

                builder.Append(input);
            }

            string encryptedText = builder.ToString();
            var list = encryptedText.Split(' ').Where(s => !string.IsNullOrWhiteSpace(s));
            encryptedText = string.Join(" ", list);

            string pattern =
                @"(?<str>\$[^\$\%\'\&]+?\$)|(?<str>\&[^\$\%\'\&]+?\&)|(?<str>\%[^\$\%\'\&]+?\%)|(?<str>\'[^\$\%\'\&]+?\')";

            var matches = Regex.Matches(encryptedText, pattern);
            var sb = new StringBuilder();
            foreach (Match match in matches)
            {
                string text = match.ToString();
                string newText = string.Empty;
                if (text.Contains("$"))
                {
                    text = text.Substring(1, text.Length - 2);
                    for (int i = 0; i < text.Length; i++)
                    {
                        if (i % 2 == 0)
                        {
                            newText += (char) (text[i] + 1);
                        }
                        else
                        {
                            newText += (char) (text[i] - 1);
                        }
                    }
                }
                else if (text.Contains("%"))
                {
                    text = text.Substring(1, text.Length - 2);
                    for (int i = 0; i < text.Length; i++)
                    {
                        if (i % 2 == 0)
                        {
                            newText += (char) (text[i] + 2);
                        }
                        else
                        {
                            newText += (char) (text[i] - 2);
                        }
                    }
                }
                else if (text.Contains("&"))
                {
                    text = text.Substring(1, text.Length - 2);
                    for (int i = 0; i < text.Length; i++)
                    {
                        if (i % 2 == 0)
                        {
                            newText += (char)(text[i] + 3);
                        }
                        else
                        {
                            newText += (char)(text[i] - 3);
                        }
                    }
                }
                else if (text.Contains("'"))
                {
                    text = text.Substring(1, text.Length - 2);
                    for (int i = 0; i < text.Length; i++)
                    {
                        if (i % 2 == 0)
                        {
                            newText += (char)(text[i] + 4);
                        }
                        else
                        {
                            newText += (char)(text[i] - 4);
                        }
                    }
                }

                sb.Append(newText + " ");
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
