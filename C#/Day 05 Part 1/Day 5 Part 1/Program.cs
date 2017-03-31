using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

/**
 * Hashing takes some time, be patient
 */

namespace Day_5_Part_1
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
            string output = "";

            // Create md5 object
            MD5 md5 = MD5.Create();

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < 8; i++)
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
                output += currentHash[5];

                // Log the value
                Debug.WriteLine(currentHash[5]);

                // Reset the hash so the loop doesn't get stuck
                currentHash = defaulthash;
            }

            // Log output
            Debug.WriteLine("Final answer: " + output);
            Console.Read();
        }
    }
}
