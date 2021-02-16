using System;
using System.Threading;
using System.Collections.Generic;

namespace Conway_s_Game_of_Life
{
    class Program
    {
        static int Size = 25;
        static string[,] table = new string[Size, Size];
        static void Main(string[] args)
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
            //Setting up the board
            InitBoard(ref table);
            Thread.Sleep(2500);
            GameLoop(ref table);
            
        }
        static void InitBoard(ref string[,] Board)
        {
            for (int i = 0; i < Size; i++)
            {
                for (int z = 0; z < Size; z++)
                {
                    Board[i, z] = "0";
                }
            }

            Random rand = new Random();
            for (int i = 0; i < 200; i++)
            {
                int x = rand.Next(0, 24);
                int y = rand.Next(0, 24);
                Board[x, y] = "1";
            }
            DisplayBoard(Board);
        }

        static void PlayGame(ref string[,] Board)
        {
            for (int i = 0; i < Size; i++)
            {
                for (int z = 0; z < Size; z++)
                {
                    OverPopulation(Board, i, z);
                    UnderPopulation(Board, i, z);
                    Reproduction(Board, i, z);
                }
            }
            
        }

        static void GameLoop(ref string[,] Board)
        {
            /*
             * RULES
             * Live cell with < 2 live neighbour dies
             * Live cell with 2 - 3 neighbours live
             * Live cell with > 3 neighbours die
             * Dead cell with exactly 3 live neighbours becomes alive.
             */
            while(!IsEmpty(Board))
            {
                PlayGame(ref Board);
                DisplayBoard(Board);
                Thread.Sleep(1000);
            }

            Console.WriteLine("That's it, a 0 player game, I hope you had fun watching this do everything on it's own.\nBy the way, this is pure RNG, no player involvement! \nMost of the time it'll end up ending quickly :) \nWould you like to go again? Yes to continue, No to stop");
            string goAgain = Console.ReadLine();
            if (goAgain == "yes" || goAgain == "Yes")
            {
                InitBoard(ref Board);
                GameLoop(ref Board);
            }
            else { return; }

        }

        #region rules
        //Rules
        static void OverPopulation(string[,] Board, int X, int Y)
        {
            if (Board[X, Y] == "1" && GetLiveNeighbours(Board, X, Y) > 3)
            {
                Board[X, Y] = "0";
            }
        }

        static void UnderPopulation(string[,] Board, int X, int Y)
        {
            if (Board[X, Y] == "1" && GetLiveNeighbours(Board, X, Y) < 3)
            {
                Board[X, Y] = "0";
            }
        }

        static void Reproduction(string[,] Board, int X, int Y)
        {
            if (Board[X, Y] == "0" && GetLiveNeighbours(Board, X, Y) == 3)
            {
                Board[X, Y] = "1";
            }
        }
        #endregion
        static int GetLiveNeighbours(string[,] Board, int X, int Y)
        {
            int result = 0;
            if (X > 0 && X < Size - 1 && Y < Size - 1 && Y > 0)
            {
                for (int offsetX = -1; offsetX <= 1; offsetX++)
                {
                    for (int offsetY = -1; offsetY <= 1; offsetY++)
                    {
                        if (offsetX == 0 && offsetY == 0) continue;
                        if (Board[X + offsetX, Y + offsetY] == "1") 
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
                        if (Board[X + offsetX, Y + offsetY] == "1") 
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
                        if (Board[X + offsetX, Y + offsetY] == "1") 
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
                        if (Board[X + offsetX, Y + offsetY] == "1") 
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
                        if (Board[X + offsetX, Y + offsetY] == "1") 
                            result++;
                    }
                }
            }
            return result;
        }
        //Showing the board
        static void DisplayBoard(string[,] Board)
        {
            Console.Clear();
            Console.WriteLine("Newest generation:\n");
            for (int i = 0; i < Size; i++)
            {
                for (int z = 0; z < Size; z++)
                {
                    if (z == Size-1)
                        Console.Write($" {Board[i, z]}\n");
                    else
                        Console.Write($" {Board[i, z]} ");
                }
            }
            Console.WriteLine("\n\n");
        }
        static bool IsEmpty(string[,] array)
        {
            int ZeroCounter = 0;
            foreach(string s in array)
            {
                if(s == "0") { ZeroCounter++; }
            }
            return ZeroCounter == array.Length;
        }
    }
}
