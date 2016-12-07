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
            //string[] alllines = File.ReadAllLines("input.txt");       // Input file
            //string[] alllines = { "wysextplwqpvipxdv[srzvtwbfzqtspxnethm]syqbzgtboxxzpwr[kljvjjkjyojzrstfgrw]obdhcczonzvbfby[svotajtpttohxsh]cooktbyumlpxostt" };
            string[] alllines = { "aa[xyyx]ecce[lliiiill]ee" };               

            for (int i = 0; i < alllines.Length; i++)                   // Loop through all lines
            {
                bool isValid;
                string line = alllines[i];                              // Store the current line in a string
                List<string> bracketpart = new List<string>();          // Store all strings in the brackets
                List<string> outsidebrackets = new List<string>();
                int amountOfBracketPairs = 0;                           // Integer to keep track of how many pairs of brackets we've had

                for (int j = 0; j < line.Length; j++)                   // Loop through the whole line and extract parts in []
                {

                    if (line[j] == '[')                                 // If the char is the start of a hypernet sequence
                    {
                        int start = j;
                        int end;
                        bracketpart.Add("");                            // Reserve new space in the list
                        j++;                                            // Increment j to remove the first [

                        while (line[j] != ']')                          // While we are not at the closing bracket
                        {
                            bracketpart[amountOfBracketPairs] += line[j];   // Add the character to the string
                            j++;                                        // Next character
                        }
                        end = j + 1;                                    // Position that the brackets stop
                        line = line.Remove(start, end - start);         // Remove part of the string between brackets
                        amountOfBracketPairs++;                         // Increment list index
                        j = 0;                                          // Reset the counter so we loop through the whole string again
                    }
                }

                Console.WriteLine("Parts in brackets: ");
                foreach (string item in bracketpart)
                {
                    string first = item.Substring(0, item.Length / 2);
                    if (first == Reverse(first))
                    {
                        isValid = false;
                        break;
                    }
                }

                Console.WriteLine("\nRest of the string");
                Console.WriteLine("\t" + line);
                Console.Read();
            }
        }

        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
