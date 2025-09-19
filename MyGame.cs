using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject
{
    internal class MyGame
    {
        static void Main(string[] args)
        {
            string[] map = File.ReadAllLines("Map.txt");
            int x = 0, y = 2;
            bool isGame = true;
            ConsoleColor color = ConsoleColor.White;
            Console.CursorVisible = false;
            Draw(x, y, color);
            while (isGame)
            {
                //DrawMap(map); next update
                Update(ref x, ref y, ref color, ref isGame);
            }
        }
        static void Input(ref int x, ref int y, ref ConsoleColor color, ref bool isGame)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            switch (keyInfo.Key)
            {
                // Movable
                case (ConsoleKey.RightArrow):
                    if (x < Console.WindowWidth - 1) x += 1;
                    break;
                case (ConsoleKey.LeftArrow):
                    if (x > 0) x -= 1;
                    break;
                case (ConsoleKey.UpArrow):
                    if (y > 2) y -= 1;
                    break;
                case (ConsoleKey.DownArrow):
                    if (y < Console.WindowHeight - 2)y += 1;
                    break;
                // Setting colors
                case (ConsoleKey.D1):
                    color = ConsoleColor.White;
                    break;
                case (ConsoleKey.D2):
                    color = ConsoleColor.Red;
                    break;
                case (ConsoleKey.D3):
                    color = ConsoleColor.Green;
                    break;
                case (ConsoleKey.D4):
                    color = ConsoleColor.Blue;
                    break;
                // Tools
                case (ConsoleKey.Escape):
                    Environment.Exit(0);
                    break;
            }
            Console.SetCursorPosition(x, y);
        }

        static void Draw(int x, int y, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(x, y);
            Console.Write("■");
            //Console.ResetColor();
        }
        static void Update(ref int x, ref int y, ref ConsoleColor color, ref bool isGame)
        {
            Input(ref x, ref y, ref color, ref isGame);
            // Console.Clear(); Очищать или не очищать?
            Draw(x, y, color);
            ShowInfo(x, y);
            System.Threading.Thread.Sleep(10);
        }
        static void ShowInfo(int x, int y)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(0, 0);
            Console.WriteLine($"Position: {x} {y}    Colors: 1 - White, 2 - Red, 3 - Green, 4 - Blue");
            Console.WriteLine(new string('_', Console.WindowWidth - 1));
        }
        static void DrawMap(string[] map)
        {
            for (int i = 0; i < map.Length; i++) 
            { 
                for(int j = 0; j < map[i].Length; j++)
                {
                    Console.Write(map[i][j]);
                }
            }
        }

    }
}
