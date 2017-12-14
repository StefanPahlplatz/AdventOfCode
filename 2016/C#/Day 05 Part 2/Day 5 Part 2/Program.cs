using System;
using System.Security.Cryptography;
using System.Text;

/**
 * Hashing takes some time, be patient
 */

namespace Day_5_Part_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input string
            string input = "reyedfim";

            // Increasing integer index
            int appendint = 0;

            string defaulthash = "xxxxxxxxxxxxxxxxx";
            string currentHash = defaulthash;
            string output = "________";

            // Create md5 object
            MD5 md5 = MD5.Create();

            StringBuilder sb = new StringBuilder();

            // Loop until all the characters are replaced
            while (output.Contains("_"))
            {
                // Loop until the hash starts with 5 zeroes
                while (currentHash.Substring(0, 5) != "00000")
                {
                    // Store input in bytes
                    byte[] inputBytes = Encoding.ASCII.GetBytes(input + appendint);

                    // Get the hash of the string
                    byte[] hash = md5.ComputeHash(inputBytes);

                    // Clear the last string
                    sb.Clear();

                    // Create a string out of the hash
                    for (int j = 0; j < hash.Length; j++)
                    {
                        currentHash = sb.Append(hash[j].ToString("X2")).ToString();
                    }

                    // Increate append index
                    appendint++;
                }

                // Add the value to the output string
                try
                {
                    // Get the position the character should be placed at
                    int positionInString = int.Parse(currentHash[5].ToString());

                    // If the position is within our 8 char string
                    if (positionInString >= 0 && positionInString <= 7)
                    {
                        // Copy the current output to a stringbuilder
                        StringBuilder sb1 = new StringBuilder(output);

                        // If we didn't get the char for the position yet
                        if (sb1[positionInString] == '_')
                        {
                            // Assign the right char
                            sb1[positionInString] = currentHash[6];
                            output = sb1.ToString();
                            Console.WriteLine(output);
                        }
                    }
                }
                catch (FormatException ex)
                {
                    // Tried to convert a letter to int, catch exception and do nothing with it.
                }

                // Reset the hash so the loop doesn't get stuck
                currentHash = defaulthash;
            }

            // Log output
            Console.WriteLine("Output:");
            foreach (char item in output)
            {
                Console.Write(item);
            }
            Console.Read();
        }
    }
}
