using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Drawing;

namespace Day1
{
    class Program
    {
        // Keep track of user position
        private static Point location = new Point(0, 0);
        
        // Store all positions the user has been to
        private static List<Point> positions = new List<Point>();

        // First location to visit twice
        private static Point firstLocVisitTwice;

        // Got first position
        private static bool gotFirstPosVisitTwice = false;

        static void Main(string[] args)
        {
            // Input
            string alldirections = "R4, R1, L2, R1, L1, L1, R1, L5, R1, R5, L2, R3, L3, L4, R4, R4, R3, L5, L1, R5, R3, L4, R1, R5, L1, R3, L2, R3, R1, L4, L1, R1, L1, L5, R1, L2, R2, L3, L5, R1, R5, L1, R188, L3, R2, R52, R5, L3, R79, L1, R5, R186, R2, R1, L3, L5, L2, R2, R4, R5, R5, L5, L4, R5, R3, L4, R4, L4, L4, R5, L4, L3, L1, L4, R1, R2, L5, R3, L4, R3, L3, L5, R1, R1, L3, R2, R1, R2, R2, L4, R5, R1, R3, R2, L2, L2, L1, R2, L1, L3, R5, R1, R4, R5, R2, R2, R4, R4, R1, L3, R4, L2, R2, R1, R3, L5, R5, R2, R5, L1, R2, R4, L1, R5, L3, L3, R1, L4, R2, L2, R1, L1, R4, R3, L2, L3, R3, L2, R1, L4, R5, L1, R5, L2, L1, L5, L2, L5, L2, L4, L2, R3";

            // Split input
            string[] directions = Regex.Split(alldirections, ", ");

            // Store the direction
            int dir = 0;

            // Loop through all directions
            for (int i = 0; i < directions.Length; i++)
            {
                // Move left or right
                dir = directions[i][0] == 'R' ? turnRight(dir) : turnLeft(dir);

                // Move forward the appropiate amount of steps
                moveForward(int.Parse(directions[i].Substring(1)), dir);
            }

            // Output the result
            Console.WriteLine("Final x value: " + location.X);
            Console.WriteLine("Final y valye: " + location.Y);
            Console.WriteLine("Squares coverered: " + Math.Abs(location.X + location.Y));
            Console.WriteLine("First position visited twice: {0},{1}", firstLocVisitTwice.X, firstLocVisitTwice.Y);
            Console.Read();
        }

        // Make a right turn
        private static int turnRight(int dir)
        {
            dir++;
            if (dir > 3)
                dir = 0;
            return dir;
        }

        // Make a left turn
        private static int turnLeft(int dir)
        {
            dir--;
            if (dir < 0)
                dir = 3;
            return dir;
        }

        // Move forwards in the appropriate direction
        private static void moveForward(int steps, int dir)
        {
            // Loop through steps
            for (int i = 0; i < steps; i++)
            {
                // If we don't have the first pos yet
                if (!gotFirstPosVisitTwice)
                {
                    // Check if we have been in this position before
                    foreach (Point item in positions)
                    {
                        // If the location matches an item in the list
                        if (location == item)
                        {
                            firstLocVisitTwice = item;
                            gotFirstPosVisitTwice = true;
                            continue;
                        }
                    }
                    // Store position at each step
                    positions.Add(location);
                }

                // Move 1 step
                if (dir == 0)
                    location.Y++;
                else if (dir == 1)
                    location.X++;
                else if (dir == 2)
                    location.Y--;
                else if (dir == 3)
                    location.X--;
            }
        }
    }
}
