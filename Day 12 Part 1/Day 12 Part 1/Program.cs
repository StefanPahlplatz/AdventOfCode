using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day_12_Part_1
{
    class Program
    {
        private static int[] registers;

        static void Main(string[] args)
        {
            registers = new int[4];

            string[] instructions = File.ReadAllLines("input.txt");

            for (int i = 0; i < instructions.Length; i++)
            {
                string[] matches = Regex.Split(instructions[i], @"\s");

                if (matches[0] == "cpy")
                {
                    int copyvalue;
                    int registerToCopyTo;

                    // Assign the copyvalue
                    if (Regex.IsMatch(matches[1], "[a-z]"))
                        copyvalue = registers[GetIntFromString(matches[1])];
                    else
                        copyvalue = int.Parse(matches[1]);

                    // Assign the registerToCopy
                    registerToCopyTo = GetIntFromString(matches[2]);

                    registers[registerToCopyTo] = copyvalue;
                }
                else if (matches[0][2] == 'c')
                {
                    int j = GetIntFromString(matches[1]);
                    registers[j] += matches[0].StartsWith("inc") ? 1 : -1;
                }
                else if (matches[0].StartsWith("jnz"))
                {
                    int x;
                    if (Regex.IsMatch(instructions[i], @"[a-z]"))
                        x = registers[GetIntFromString(matches[1])];
                    else
                        x = int.Parse(matches[1]);

                    int y = int.Parse(matches[2]);
                    if (x != 0)
                    {
                        i += y;
                    }

                    Console.WriteLine("{0} {1} {2} int value {3}: \t{4}", matches[0], x, y, matches[2], i);
                }
                else
                {
                    throw new Exception();
                }
            }

            Console.WriteLine("Value of A: {0}", registers[0]);
            Console.Read();
        }

        static private int GetIntFromString(string s)
        {
            if (Regex.IsMatch(s, @"[0-9]+"))
            {
                return int.Parse(s);
            }
            else
            {
                switch (s)
                {
                    case "a":
                        return 0;
                    case "b":
                        return 1;
                    case "c":
                        return 2;
                    case "d":
                        return 3;
                }
            }
            throw new ArgumentOutOfRangeException();
        }
    }
}
