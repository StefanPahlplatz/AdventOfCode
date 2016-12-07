using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_7_Part_2
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
                bool valid = false;
                List<string> allABA = new List<string>();

                foreach (var item in outside)
                {
                    allABA = allABA.Union(hasABA(item)).ToList();
                }
                // Now we got all aba's

                foreach (var item in inside)
                {
                    foreach (var item2 in allABA)
                    {
                        string test = "";
                        test += item2[1];
                        test += item2[0];
                        test += item2[1];
                        if (item.Contains(test))
                        {
                            valid = true;
                        }
                    }
                }

                if (valid)
                {
                    possible++;
                }

            }
            Console.WriteLine("Amount of possibilities: " + possible);
            Console.Read();
        }

        public static List<string> hasABA(string input)
        {
            List<string> lst = new List<string>();
            for (int i = 0; i < input.Length - 2; i++)
            {
                if (input[i] == input[i + 2] && input[i] != input[i + 1])
                    lst.Add(input[i].ToString() + input[i + 1].ToString() + input[i + 2].ToString());
            }

            return lst;
        }
    }
}
