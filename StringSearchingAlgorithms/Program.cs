using System;
using System.Collections.Generic;
using StringSearching.BoyerMooreHorspool;

namespace findrep
{
    class Program
    {
        static void Main(string[] args)
        {
            List<String> text = new List<string>();
            string find = null;
            string replace = string.Empty;

            foreach(string arg in args)
            {
                string[] command = arg.Trim().TrimStart('-').Split('=', 2);
                switch(command[0].ToLower())
                {
                    case "find":
                        find = command[1];
                        break;
                    case "replace":
                        replace = command[1];
                        break;
                    case "text":
                        text.Add(command[1]);
                        break;
                    default:
                        Console.Error.WriteLine($"Unknown command: {command[0]}");
                        return;
                }
            }

            foreach (string input in text)
            {
                    string output = StringReplace.Replace(new BoyerMooreHorspool(), input, find, replace);
                    Console.WriteLine(output);
            }
        }
    }
}
