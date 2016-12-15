using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Day_9_Part_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = File.ReadAllText("input.txt");
            Console.WriteLine("Start length: {0}\n\n", input.Length, input);
            int decompressed = 0;

            while (input.Length > 0)
            {
                Console.WriteLine(input.Substring(0, 50) + "...   " + decompressed);
                if (input[0] == '(')
                {
                    MatchCollection info = Regex.Matches(input.Substring(1, input.Length - 1), @"\d+");
                    int subsequent = int.Parse(info[0].Value.ToString());
                    int repeat = int.Parse(info[1].Value.ToString());
                    input = input.Remove(0, input.IndexOf(')') + 1);
                    input = input.Remove(0, subsequent);
                    decompressed += subsequent * repeat;
                }
                else
                {
                    decompressed++;
                    input = input.Substring(1);
                }
            }

            Console.WriteLine("\n\nDecompressed length: {0}", decompressed);
            Console.Read();
        }
    }
}