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
        static char INIT_CHAR = ' ';
        static char PIXEL = '#';

        static char[,] display;
        static void Main(string[] args)
        {
            display = new char[WIDTH, HEIGHT];

            InitScreen();
            Draw();

            string[] instructions = File.ReadAllLines("input.txt");

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
                    int x = int.Parse(Regex.Match(instructions[i], @"\d+").Value);
                    int times = int.Parse(Regex.Match(instructions[i], @"(?<=by )\d+").Value);
                    RotateColumn(x, times);
                }
                else if (instructions[i].Contains("row"))
                {
                    int y = int.Parse(Regex.Match(instructions[i], @"\d+").Value);
                    int times = int.Parse(Regex.Match(instructions[i], @"(?<=by )\d+").Value);
                    RotateRow(y, times);
                }
                Draw();
                Thread.Sleep(10);
            }

            int pixels = GetPixels();

            Console.WriteLine("\n\nAmount of pixels lit: {0}", pixels);
            
            Console.Read();
        }

        static void Rect(int x, int y)
        {
            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    display[j, i] = PIXEL;
                }
            }
        }

        static int GetPixels()
        {
            int pixels = 0;

            for (int y = 0; y < HEIGHT; y++)
            {
                for (int x = 0; x < WIDTH; x++)
                {
                    if (display[x, y] != INIT_CHAR)
                    {
                        pixels++;
                    }
                }
            }

            return pixels;
        }

        static void RotateRow(int y, int times)
        {
            for (int i = 0; i < times; i++)
            {
                char initialLast = display[WIDTH - 1, y];

                for (int x = WIDTH - 1; x >= 0; x--)
                {
                    if (x == 0)
                    {
                        display[x, y] = initialLast;
                    }
                    else
                    {
                        display[x, y] = display[x - 1, y];
                    }
                }
            }
        }

        static void RotateColumn(int x, int times)
        {
            for (int i = 0; i < times; i++)
            {
                char initialLast = display[x, HEIGHT - 1];

                for (int y = HEIGHT - 1; y >= 0; y--)
                {
                    if (y == 0)
                    {
                        display[x, y] = initialLast;
                    }
                    else
                    {
                        display[x, y] = display[x, y - 1];
                    }
                }
                Draw();
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

        static void InitScreen()
        {
            for (int i = 0; i < HEIGHT; i++)
            {
                for (int j = 0; j < WIDTH; j++)
                {
                    display[j, i] = INIT_CHAR;
                }
            }
        }
    }
}
