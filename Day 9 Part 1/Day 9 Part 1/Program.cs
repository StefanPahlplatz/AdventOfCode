using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

/**
 * Get the values between the brackets: (\d+x\d+)
 * Select whole bracket part: \((.*?)\)
 */

namespace Day_9_Part_1
{
    class Program
    {
        static void Main(string[] args)
        {
            //string input = File.ReadAllText("input.txt");
            string input = "X(8x2)(3x3)ABCYA(1x5)BC";

            Console.WriteLine("Start length: {0}\n\n", input.Length);

            for (int i = 0; i < input.Length; i++)
            {
                int starti;

                if (input[i] == '(')
                {
                    starti = i;
                    i++;

                    // Subsequent chars
                    Match subsequent = Regex.Match(input.Substring(i), @"\d+");
                    i += subsequent.Length + 1;
                    //Console.WriteLine("Subsequent chars: {0}", subsequent);

                    // Times to repeat
                    Match repeat = Regex.Match(input.Substring(i), @"\d+");
                    i += repeat.Length + 1;
                    

                    // Get the part of the string that we need to repeat
                    string toRepeat = input.Substring(i, int.Parse(subsequent.ToString()));

                    // Create the insert string
                    string insert = "";
                    for (int j = 0; j < int.Parse(repeat.ToString()); j++)
                    {
                        insert += toRepeat;
                    }

                    // Insert the string
                    input = input.Insert(i, insert);
                    int l = input.Length;

                    // Remove the old part
                    input = input.Remove(starti, 1 + subsequent.Length + 1 + repeat.Length + 1 + int.Parse(subsequent.ToString()));
                    //Console.WriteLine("New string: " + input);

                    // Make i correct
                    i = starti + int.Parse(subsequent.ToString());
                }

                Console.WriteLine(input);
                Thread.Sleep(1000);
            }

            Console.WriteLine("\n\nAfter processing: {0}", input.Length);

            Console.Read();
        }
    }
}
