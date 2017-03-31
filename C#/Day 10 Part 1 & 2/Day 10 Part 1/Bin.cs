using System.Collections.Generic;

class Bin
{
    public int Number { get; set; }
    public List<int> items { get; set; }

    public Bin(int number, int value)
    {
        Number = number;
        items = new List<int>();
        items.Add(value);
    }
}
