using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Day_12_Part_1
{
    class Program
    {
        public static List<string> instructions = new List<string>();
        public static int[] registers = new int[4];
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines(@"input.txt");

            foreach (string line in input)
                instructions.Add(line);

            // Part 1
            calc();
            Console.WriteLine("Part1: Register a = {0}", registers[0]);

            // Part 2
            registers[2] = 1;
            calc();
            Console.WriteLine("Part2: Register a = {0}", registers[0]);
            Console.ReadLine();
        }

        static void calc()
        {
            int i = 0;

            while (true)
            {
                if (i >= instructions.Count) break;

                //Console.WriteLine(" A: {0} \n B: {1} \n C: {2} \n D: {3} \n", registers[0], registers[1], registers[2], registers[3]);

                string[] arr = instructions[i].Split();
                string cmd = arr[0];

                if (cmd == "cpy")
                {
                    int regnum = returnRegister(arr[2].ToCharArray()[0]);

                    if (isNumberic(arr[1]))
                        registers[regnum] = Convert.ToInt32(arr[1]);
                    else
                        registers[regnum] = registers[returnRegister(arr[1].ToCharArray()[0])];
                }
                else if (cmd == "inc")
                {
                    int regnum = returnRegister(arr[1].ToCharArray()[0]);
                    registers[regnum]++;
                }
                else if (cmd == "dec")
                {
                    int regnum = returnRegister(arr[1].ToCharArray()[0]);
                    registers[regnum]--;
                }
                else if (cmd == "jnz")
                {
                    int val = Convert.ToInt32(arr[2]);

                    if (isNumberic(arr[1]))
                    {
                        if (Convert.ToInt32(arr[1]) != 0)
                        {
                            i += val;
                            if (i >= instructions.Count - 1)
                                break;

                            continue;
                        }
                    }

                    int regnum = returnRegister(arr[1].ToCharArray()[0]);

                    if (regnum == -1)
                    {
                        i++;
                        continue;
                    }

                    if (registers[regnum] != 0)
                    {
                        i += val;
                        if (i >= instructions.Count - 1)
                            break;

                        continue;
                    }
                }

                i++;
            }
        }

        static int returnRegister(char ch)
        {
            int registerValue = -1;

            switch (ch)
            {
                case 'a':
                    registerValue = 0;
                    break;
                case 'b':
                    registerValue = 1;
                    break;
                case 'c':
                    registerValue = 2;
                    break;
                case 'd':
                    registerValue = 3;
                    break;
            }

            return registerValue;
        }

        static bool isNumberic(string str)
        {
            int n;
            return int.TryParse(str, out n);
        }
    }
}
