using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Conway_s_Game_of_Life
{
    static class Program
    {
        private const int Size = 25;
        private static readonly char[,] Table = new char[Size, Size];
        private static int Generation { get; set; }
        private async static Task Main(string[] args)
        {
            /*
             * PLAN:
             * Make a 50x50 2d string array
             *      
             * Potentially take in input to make live cells
             * Game loop
             * Condition checks
             * make the strings say 1 for alive, 0 for dead.
             * Repeat until the app is closed
             */

            Console.WriteLine("Welcome to a 0 player game, the beginning is randomized, so have fun!\n");

            //Setting up the Table
            await Task.Delay(2500);
            InitBoard();
            await Task.Delay(1000);
            await GameLoop();
            
        }
        static void InitBoard()
        {
            Generation = 0;
            for (int i = 0; i < Size; i++)
            {
                for (int z = 0; z < Size; z++)
                {
                    Table[i, z] = ' ';
                }
            }

            Random rand = new Random();
            for (int i = 0; i < 200; i++)
            {
                int x = rand.Next(0, 24);
                int y = rand.Next(0, 24);
                Table[x, y] = '█';
            }
            Table.DisplayTable();
        }

        private static void PlayGame()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int z = 0; z < Size; z++)
                {
                    OverPopulation(i, z);
                    UnderPopulation(i, z);
                    Reproduction(i, z);
                }
            }
            
        }

        private static async Task GameLoop()
        {
            /*
             * RULES
             * Live cell with < 2 live neighbour dies
             * Live cell with 2 - 3 neighbours live
             * Live cell with > 3 neighbours die
             * Dead cell with exactly 3 live neighbours becomes alive.
             */
            while(true)
            {
                while(!Table.IsEmpty())
                {
                    PlayGame();
                    Table.DisplayTable();
                    await Task.Delay(1000);
                }
                string goAgain = Console.ReadLine();
                Console.WriteLine("That's it, a 0 player game, I hope you had fun watching this do everything on it's own."); 
                Console.WriteLine("By the way, this is pure RNG, no player involvement!");
                Console.WriteLine("Most of the time it'll end up ending quickly :)");
                Console.WriteLine("Would you like to go again? Yes to continue, No to stop");
                if (goAgain.Equals("yes", StringComparison.OrdinalIgnoreCase))
                {
                    InitBoard();
                }
                else { break; }
            }

        }

        //Rules
        private static void OverPopulation(int X, int Y)
        {
            if (Table[X, Y] == '█' && GetLiveNeighbours(X, Y) > 3)
            {
                Table[X, Y] = ' ';
            }
        }

        private static void UnderPopulation(int X, int Y)
        {
            if (Table[X, Y] == '█' && GetLiveNeighbours(X, Y) < 3)
            {
                Table[X, Y] = ' ';
            }
        }

        private static void Reproduction(int X, int Y)
        {
            if (Table[X, Y] == ' ' && GetLiveNeighbours(X, Y) == 3)
            {
                Table[X, Y] = '█';
            }
        }

        //Getting neighbours
        private static int GetLiveNeighbours(int X, int Y)
        {
            int result = 0;
            if (X > 0 && X < Size - 1 && Y < Size - 1 && Y > 0)
            {
                for (int offsetX = -1; offsetX <= 1; offsetX++)
                {
                    for (int offsetY = -1; offsetY <= 1; offsetY++)
                    {
                        if (offsetX == 0 && offsetY == 0) continue;
                        if (Table[X + offsetX, Y + offsetY] == '█') 
                            result++;
                    }
                }
            }
            else if (X == 0 && Y < Size - 1 && Y > 0)
            {
                for (int offsetX = 0; offsetX <= 1; offsetX++)
                {
                    for (int offsetY = -1; offsetY <= 1; offsetY++)
                    {
                        if (offsetX == 0 && offsetY == 0) continue;
                        if (Table[X + offsetX, Y + offsetY] == '█') 
                            result++;
                    }
                }
            }
            else if (X == Size - 1 && Y < Size - 1 && Y > 0)
            {
                for (int offsetX = -1; offsetX <= 0; offsetX++)
                {
                    for (int offsetY = -1; offsetY <= 1; offsetY++)
                    {
                        if (offsetX == 0 && offsetY == 0) continue;
                        if (Table[X + offsetX, Y + offsetY] == '█') 
                            result++;
                    }
                }
            }
            else if (Y == Size - 1 && X < Size - 1 && X > 0)
            {
                for (int offsetX = -1; offsetX <= 1; offsetX++)
                {
                    for (int offsetY = -1; offsetY <= 0; offsetY++)
                    {
                        if (offsetX == 0 && offsetY == 0) continue;
                        if (Table[X + offsetX, Y + offsetY] == '█') 
                            result++;
                    }
                }
            }
            else if(Y == 0 && X < Size - 1 && X > 0)
            {
                for (int offsetX = -1; offsetX <= 1; offsetX++)
                {
                    for (int offsetY = 0; offsetY <= 1; offsetY++)
                    {
                        if (offsetX == 0 && offsetY == 0) continue; 
                        if (Table[X + offsetX, Y + offsetY] == '█') 
                            result++;
                    }
                }
            }
            return result;
        }

        //Showing the Table
        private static void DisplayTable(this char[,] Table)
        {
            Console.Clear();
            Console.WriteLine("Generation: {0}\n", Generation);
            for (int i = 0; i < Size; i++)
            {
                for (int z = 0; z < Size; z++)
                {
                    if (z == Size-1)
                        Console.WriteLine($"{Table[i, z]}");
                    else
                        Console.Write($"{Table[i, z]} ");
                }
            }
            Generation++;
        }

        //Making sure the array isn't empty (full of 0's)
        private static bool IsEmpty(this char[,] array) => array.Cast<char>().All(s => s != '█');
    }
}
