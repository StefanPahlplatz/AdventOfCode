using System;

public class Bot
{
    public int Number { get; set; }
    public int GiveHighTo { get; set; }
    public int GiveLowTo { get; set; }
    public int[] Values { get; set; }
    public bool HighToBot { get; set; }
    public bool LowToBot { get; set; }

    public Bot(int number)
    {
        InitializeValues();
        Number = number;
    }

    public Bot(int number, int value)
    {
        InitializeValues();
        Number = number;
        Values[0] = value;
    }

    public Bot(int number, int giveLowTo, int giveHighTo, bool lowToBot, bool highToBot)
    {
        InitializeValues();
        Number = number;
        GiveHighTo = giveHighTo;
        GiveLowTo = giveLowTo;
        LowToBot = lowToBot;
        HighToBot = highToBot;
    }

    public void ReceiveValue(int value)
    {
        int i = ValuesHasSpace();
        if (i != -1)
            Values[i] = value;
        else
            throw new System.Exception("Bot " + this.Number + " already has 2 values!");

        if (HasSearchValues())
        {
            Console.WriteLine("Part 1: {0}", this.Number);
        }
    }

    private bool HasSearchValues()
    {
        if ((Values[0] == 17 && Values[1] == 61) ||
            (Values[0] == 61 && Values[1] == 17))
            return true;
        return false;
    }

    public override string ToString()
    {
        return string.Format("Bot {0}\t   passes low to {1} and high to {2}." +
            "\tCurrent values {3}, {4}\tLowToBot: {5}\tHighToBot: {6}", 
            Number, GiveLowTo, GiveHighTo, Values[0], Values[1], LowToBot, HighToBot);
    }

    private void InitializeValues()
    {
        Values = new int[2];
        Values[0] = -1;
        Values[1] = -1;
    }

    private int ValuesHasSpace()
    {
        for (int i = 0; i < Values.Length; i++)
        {
            if (Values[i] == -1)
            return i;
        }
        return -1;
    }
}

