using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day_3_Part_1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Store input in 3D point
            List<Point3D> triangles = new List<Point3D>();
            
            // Temporary string to store current line
            string[] lines = File.ReadAllLines("input.txt");

            // Loop through all lines
            for (int i = 0; i < lines.Length; i++)
            {
                // Split the line on whitespaces
                string[] split = lines[i].Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => s.Trim())
                    .ToArray();

                // Store splitted string in int
                int x = int.Parse(split[0]);
                int y = int.Parse(split[1]);
                int z = int.Parse(split[2]);

                // Check if the triangle is legit
                if (((x + y) > z) &&
                    ((x + z) > y) &&
                    ((y + z) > x))
                {
                    // Add splitted line to list
                    triangles.Add(new Point3D(int.Parse(split[0]), int.Parse(split[1]), int.Parse(split[2])));
                }
            }

            // Output
            Console.WriteLine("Amount of possible triangles: {0}", triangles.Count);

            // Keep the console open
            Console.Read();
        }
    }
}
