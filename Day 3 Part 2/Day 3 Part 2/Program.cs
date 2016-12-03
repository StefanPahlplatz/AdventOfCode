using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day_3_Part_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Amount of possible triangles
            int count = 0;

            // Temporary string to store current line
            string[] alllines = File.ReadAllLines("input.txt");

            // Store all lines in this list
            List<Line> lineslist = new List<Line>();
            
            // Loop through all lines
            for (int i = 0; i < alllines.Length; i++)
            {
                // Split the line on whitespaces
                string[] split = alllines[i].Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => s.Trim())
                    .ToArray();

                // Add the line to the list
                lineslist.Add(new Line(int.Parse(split[0]), int.Parse(split[1]), int.Parse(split[2])));
            }

            // Loop through all lines in pairs of three
            for (int i = 0; i < lineslist.Count; i += 3)
            {
                // Create list to store the vertical points
                List<Line> lines = new List<Line>();
                lines.Add(lineslist[i]);
                lines.Add(lineslist[i + 1]);
                lines.Add(lineslist[i + 2]);

                // Get vertical points
                for (int j = 0; j < 3; j++)
                {
                    int x = lines[0].Get(j);
                    int y = lines[1].Get(j);
                    int z = lines[2].Get(j);
                    
                    // Check if the triangle is legit
                    if (((x + y) > z) &&
                        ((x + z) > y) &&
                        ((y + z) > x))
                    {
                        // Increment amount of possible triangles
                        count++;
                    }
                }
            }

            // Output
            Console.WriteLine("Amount of possible triangles: {0}", count);

            // Keep the console open
            Console.Read();
        }
    }
}
