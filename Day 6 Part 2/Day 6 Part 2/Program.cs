using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day_6_Part_2
{
    class Program
    {
        static string alphabet = "abcdefghijklmnopqrstuvwxyz";
        const int LINELENGTH = 8;

        static void Main(string[] args)
        {
            // Load file in memory
            string[] alllines = File.ReadAllLines("input.txt");

            // List to store the vertical lines
            List<int[]> list = new List<int[]>();

            // Populate list with int arrays
            for (int i = 0; i < LINELENGTH; i++)
            {
                list.Add(new int[26]);
            }

            // Loop through all lines
            for (int i = 0; i < alllines.Length; i++)
            {
                // Loop through string of line
                for (int j = 0; j < alllines[i].Length; j++)
                {
                    // Increment to position of the letter
                    list[j][CharToAlphabetPos(alllines[i][j])]++;
                }
            }

            // Output
            Console.Write("Output: ");
            for (int i = 0; i < list.Count; i++)
            {
                // Print most occuring int in the array as letter
                Console.Write(alphabet[Array.IndexOf(list[i], list[i].Min())]);
            }

            // Keep the console open
            Console.Read();
        }

        // Get the position of the letter in the alphabet
        private static int CharToAlphabetPos(char letter)
        {
            for (int i = 0; i < alphabet.Length; i++)
            {
                if (letter == alphabet[i])
                    return i;
            }
            throw new ArgumentOutOfRangeException("Invalid letter.");
        }
    }
}
