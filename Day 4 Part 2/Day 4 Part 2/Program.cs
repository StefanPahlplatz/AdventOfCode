using System;
using System.IO;

namespace Day_4_Part_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Load file in memory
            string[] alllines = File.ReadAllLines("input.txt");

            // Loop through all lines
            foreach (string line in alllines)
            {
                // Create room
                Room room = new Room(line);

                // If the room is valid add the sector id
                if (room.IsValidRoom())
                {
                    string decr = room.Decrypted();
                    if (decr.Contains("obj"))
                    {
                        Console.WriteLine("At sector {0} is the {1}.", room.SectorId, decr);
                    }
                }
            }

            // Keep the console open
            Console.Read();
        }
    }
}
