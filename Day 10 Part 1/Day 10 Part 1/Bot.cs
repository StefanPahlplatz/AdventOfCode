using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_10_Part_1
{
    class Bot
    {
        public int Nr;
        public bool has2values = false;

        private int high;
        private int low;

        public Bot(int nr, int value)
        {
            Nr = nr;
            low = value;
        }

        public void ReceiveValue(int value)
        {
            if (value < high)
                low = value;
            else if (value > high)
                high = value;

            if (high != 0 && low != 0)
                has2values = true;

            if (high == 61 && low == 17)
            {
                Debug.WriteLine("ANSWER IS BOT {0}!!!", Nr);
            }
        }

        public int GetHigh()
        {
            int ret = high;
            high = 0;
            has2values = false;
            return ret;
        }

        public int GetLow()
        {
            int ret = low;
            low = 0;
            has2values = false;
            return ret;
        }
    }
}
