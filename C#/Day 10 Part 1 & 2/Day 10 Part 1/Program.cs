using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

class Program
{
    public static bool loop = true;

    static string[] input = File.ReadAllLines("input.txt");
    static List<Bot> bots = new List<Bot>();
    static List<Bin> bins = new List<Bin>();

    static void Main(string[] args)
    {

        AssignValues();

        AssignRules();

        PrintBots();

        FindValue();

        Console.Read();
    }

    private static void FindValue()
    {
        int counter = 0;
        while (loop)
        {
            counter++;
            foreach (Bot bot in bots)
            {
                if (bot.Values[0] != -1 && bot.Values[1] != -1)
                {
                    Console.WriteLine("Bot " + bot.Number + " passing " + bot.Values[0] + " - "+ bot.Values[1] + " to " + bot.GiveLowTo + " - " + bot.GiveHighTo);
                    // Pass the minimum value
                    if (bot.LowToBot)
                    {
                        var matches = bots.Where(b => b.Number == bot.GiveLowTo);
                        matches.ToList()[0].ReceiveValue(bot.Values.Min());
                    }
                    else
                    {
                        var matches = bins.Where(b => b.Number == bot.GiveLowTo);
                        if (matches.ToList().Count == 1)
                            matches.ToList()[0].items.Add(bot.Values.Min());
                        else
                        {
                            bins.Add(new Bin(bot.GiveLowTo, bot.Values.Min()));
                        }
                    }
                    bot.Values[Array.IndexOf(bot.Values, bot.Values.Min())] = -1;

                    // Pass the maximum value
                    if (bot.HighToBot)
                    {
                        var matches = bots.Where(b => b.Number == bot.GiveHighTo);
                        matches.ToList()[0].ReceiveValue(bot.Values.Max());
                    }
                    else
                    {
                        var matches = bins.Where(b => b.Number == bot.GiveHighTo);
                        if (matches.ToList().Count == 1)
                            matches.ToList()[0].items.Add(bot.Values.Max());
                        else
                        {
                            bins.Add(new Bin(bot.GiveLowTo, bot.Values.Max()));
                        }
                    }
                    bot.Values[Array.IndexOf(bot.Values, bot.Values.Max())] = -1;
                }
            }

            try
            {
                Bin bin0 = bins.Where(b => b.Number == 0).ToList()[0];
                Bin bin1 = bins.Where(b => b.Number == 1).ToList()[0];
                Bin bin2 = bins.Where(b => b.Number == 2).ToList()[0];

                Console.WriteLine("Part 2: " + bin0.items[0] * bin1.items[0] * bin2.items[0]);
                break;
            }
            catch (Exception)
            {
                // ignored
            }
        }
        Console.WriteLine(counter);
    }

    private static void PrintBots()
    {
        foreach (var bot in bots)
        {
            if (bot.Number == 123)
                Console.WriteLine();
            Console.WriteLine(bot.ToString());
        }
    }

    private static void AssignRules()
    {
        // Assign the rules to each bot
        foreach (string line in input)
        {
            if (line.StartsWith("bot"))
            {
                // If the bot passes it's values to other bots
                if (new Regex(@"(bot.+){3}").IsMatch(line))
                {
                    MatchCollection values = Regex.Matches(line, @"\d+");
                    var matches = bots.Where(b => b.Number == MatchToInt(values[0]));
                    if (matches.ToList().Count == 1)
                    {
                        matches.ToList()[0].GiveLowTo = MatchToInt(values[1]);
                        matches.ToList()[0].GiveHighTo = MatchToInt(values[2]);
                        matches.ToList()[0].HighToBot = true;
                        matches.ToList()[0].LowToBot = true;
                    }
                    else
                    {
                        bots.Add(new Bot(MatchToInt(values[0]), MatchToInt(values[1]),
                            MatchToInt(values[2]), true, true));
                    }
                }
                // If the bot passes it's values to bots or outputs
                else
                {
                    MatchCollection values = Regex.Matches(line, @"bot (\d+)|output (\d+)");
                    int botnr = int.Parse(values[0].Groups[1].Value);

                    int lowTo = int.Parse(values[1].Groups[values[1].Groups[1].Value == "" ? 2 : 1].Value);
                    bool lowToBot = values[1].Groups[1].Value != "";

                    int highTo = int.Parse(values[2].Groups[values[2].Groups[1].Value == "" ? 2 : 1].Value);
                    bool highToBot = values[2].Groups[1].Value != "";

                    var matches = bots.Where(b => b.Number == int.Parse(values[0].Groups[1].Value));
                    if (matches.ToList().Count == 1)
                    {
                        matches.ToList()[0].GiveLowTo = lowTo;
                        matches.ToList()[0].GiveHighTo = highTo;
                        matches.ToList()[0].LowToBot = lowToBot;
                        matches.ToList()[0].HighToBot = highToBot;
                    }
                    else
                    {
                        bots.Add(new Bot(botnr, lowTo, highTo, lowToBot, highToBot));
                    }
                }
            }
        }
    }

    private static void AssignValues()
    {
        // Assign the values to the bots
        foreach (string line in input)
        {
            if (line.StartsWith("value"))
            {
                MatchCollection info = Regex.Matches(line, @"\d+");
                var matches = bots.Where(b => b.Number == MatchToInt(info[1]));
                if (matches.ToList().Count == 1)
                {
                    matches.ToList()[0].ReceiveValue(MatchToInt(info[0]));
                }
                else
                    bots.Add(new Bot(MatchToInt(info[1]), MatchToInt(info[0])));
            }
        }
    }

    private static int MatchToInt(Match match)
    {
        return int.Parse(match.Value);
    }
}

