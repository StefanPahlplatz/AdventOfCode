using System.Collections.Generic;

namespace Day_3_Part_2
{
    class Line
    {
        private List<int> positions = new List<int>();

        public Line(int x1, int x2, int x3)
        {
            positions.Add(x1);
            positions.Add(x2);
            positions.Add(x3);
        }

        public int Get(int pos)
        {
            return positions[pos];
        }
    }
}
