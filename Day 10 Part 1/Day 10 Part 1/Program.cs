using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day_10_Part_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("input.txt");
            List<Bot> bots = new List<Bot>();

            // Get value for each bot
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i][0] == 'v')
                {
                    MatchCollection matches = Regex.Matches(input[i], @"\d+");
                    int value = int.Parse(matches[0].ToString());
                    int botnr = int.Parse(matches[1].ToString());
                    bots.Add(new Bot(botnr, value));
                }
            }

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i][0] == 'b')
                {
                    MatchCollection info = Regex.Matches(input[i], @"\d+");
                    int giveBot = int.Parse(info[0].ToString());
                    int lowBot = int.Parse(info[1].ToString());
                    int highBot = int.Parse(info[2].ToString());

                    for (int j = 0; j < bots.Count; j++)
                    {
                        if (bots[j].Nr == giveBot)
                        {
                            int highToGive = bots[j].GetHigh();
                            int lowToGive = bots[j].GetLow();

                            bool gaveLow = false;
                            for (int b = 0; b < bots.Count; b++)
                            {
                                if (bots[b].Nr == lowBot)
                                {
                                    bots[b].ReceiveValue(lowToGive);
                                    Console.WriteLine("gave {0} to {1}", lowToGive, lowBot);
                                    gaveLow = true;
                                }
                            }
                            if (!gaveLow)
                            {
                                bots.Add(new Bot(lowBot, lowToGive));
                            }

                            bool gaveHigh = false;
                            for (int b = 0; b < bots.Count; b++)
                            {
                                if (bots[b].Nr == highBot)
                                {
                                    bots[b].ReceiveValue(highToGive);
                                    Console.WriteLine("gave {0} to {1}", highToGive, highBot);
                                    gaveHigh = true;
                                }
                            }
                            if (!gaveHigh)
                            {
                                bots.Add(new Bot(highBot, highToGive));
                            }
                        }
                    }
                }
            }

            Console.WriteLine("Done");

            Console.Read();
        }
    }
}
