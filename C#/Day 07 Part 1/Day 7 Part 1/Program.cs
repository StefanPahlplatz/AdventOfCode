using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day_7_Part_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] alllines = File.ReadAllLines("input.txt");

            int possible = 0;
            bool isInsideBrackets = false;

            for (int i = 0; i < alllines.Length; i++)
            {
                bool valid = true;
                bool hasValidMirror = false;

                int indexIn = -1;
                int indexOut = 0;
                List<string> inside = new List<string>();
                List<string> outside = new List<string>();
                outside.Add("");

                // Loop through current string
                for (int j = 0; j < alllines[i].Length; j++)
                {
                    // Start of bracket
                    if (alllines[i][j] == '[')
                    {
                        isInsideBrackets = true;
                        inside.Add("");
                        indexIn++;
                    }
                    // End of bracket
                    else if (alllines[i][j] == ']')
                    {
                        isInsideBrackets = false;
                        outside.Add("");
                        indexOut++;
                    }

                    // If we are outside brackets
                    if (!isInsideBrackets && alllines[i][j] != '[' && alllines[i][j] != ']')
                    {
                        outside[indexOut] += alllines[i][j];
                    }
                    // If we are inside brackets
                    else if (isInsideBrackets && alllines[i][j] != '[' && alllines[i][j] != ']')
                    {
                        inside[indexIn] += alllines[i][j];
                    }
                }
                
                // Outside parts
                foreach (string item in outside)
                {
                    if (item.Distinct().Count() != 1) 
                    {
                        if (hasMirror(item))
                        {
                            hasValidMirror = true;
                        }
                    }                  
                }

                // Inside part
                foreach (string item in inside)
                {
                    if (item.Distinct().Count() != 1)
                    {
                        if(hasMirror(item))
                        {
                            valid = false;
                        }
                    } 
                }

                if (valid && hasValidMirror)
                {
                    possible++;
                }
            }
            Console.WriteLine("Amount of possibilities: " + possible);
            Console.Read();
        }

        public static bool hasMirror(string input)
        {
            for (int i = 0; i < input.Length - 3; i++)
            {
                if (input[i] == input[i + 3] && input[i + 1] == input[i + 2] && input[i] != input[i + 1])
                    return true;
            }

            return false;
        }

        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
