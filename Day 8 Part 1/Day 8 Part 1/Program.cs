using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Day_8_Part_1
{
    class Program
    {
        static int WIDTH = 50;
        static int HEIGHT = 6;

        static char[,] display;
        static void Main(string[] args)
        {
            display = new char[WIDTH, HEIGHT];

            InitScreen('.');
            Draw();

           // string[] instructions = File.ReadAllLines("input.txt");
            string[] instructions = { "rect 3x2", "rotate column x=1 by 2" };

            for (int i = 0; i < instructions.Length; i++)
            {
                if (instructions[i].Contains("rect"))
                {
                    int x = int.Parse(Regex.Match(instructions[i], @"\d+").Value);
                    int y = int.Parse(Regex.Match(instructions[i], @"(?<=x)\d+").Value);
                    Rect(x, y);
                }
                else if (instructions[i].Contains("column"))
                {
                    int column = int.Parse(Regex.Match(instructions[i], @"\d+").Value);
                    int by = int.Parse(Regex.Match(instructions[i], @"(?<=by )\d+").Value);
                    RotateColumn(column, by);
                }
                Draw();
            }
            
            Console.Read();
        }

        static void Rect(int x, int y)
        {
            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    display[j, i] = '#';
                }
            }
        }

        static void RotateColumn(int x, int times)
        {
            for (int i = 0; i < times; i++)
            {
                Thread.Sleep(1000);
                Draw();

                char[,] temp = display;

                for (int j = 0; j < HEIGHT - 1; j++)
                {
                    if (i + 1 < HEIGHT - 1)
                    {
                        temp[x, 0] = display[x, HEIGHT - 1];
                    }
                    else
                    {
                        temp[x, i] = display[x, i + 1];
                    }
                }

                display = temp;
            }
        }

        static void Draw()
        {
            Console.Clear();

            for (int i = 0; i < HEIGHT; i++)
            {
                for (int j = 0; j < WIDTH; j++)
                {
                    Console.Write(display[j, i]);
                }
                Console.WriteLine();
            }
        }

        static void InitScreen(char c)
        {
            for (int i = 0; i < HEIGHT; i++)
            {
                for (int j = 0; j < WIDTH; j++)
                {
                    display[j, i] = c;
                }
            }
        }
    }
}
