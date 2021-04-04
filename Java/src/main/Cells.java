package main;

public class Cells {
    public static int GetLiveNeighbours(String[][] Board, int X, int Y) {
        int result = 0;
        if (X > 0 && X < main.Main.Size - 1 && Y < main.Main.Size - 1 && Y > 0)
        {
            for (int offsetX = -1; offsetX <= 1; offsetX++)
            {
                for (int offsetY = -1; offsetY <= 1; offsetY++)
                {
                    if (offsetX == 0 && offsetY == 0) continue;
                    if (Board[X + offsetX][Y + offsetY] == " █") { result++; }
                }
            }
        }
        else if (X == 0 && Y < main.Main.Size - 1 && Y > 0)
        {
            for (int offsetX = 0; offsetX <= 1; offsetX++)
            {
                for (int offsetY = -1; offsetY <= 1; offsetY++)
                {
                    if (offsetX == 0 && offsetY == 0) continue;
                    if (Board[X + offsetX][Y + offsetY] == " █")  { result++; }
                }
            }
        }
        else if (X == main.Main.Size - 1 && Y < main.Main.Size - 1 && Y > 0)
        {
            for (int offsetX = -1; offsetX <= 0; offsetX++)
            {
                for (int offsetY = -1; offsetY <= 1; offsetY++)
                {
                    if (offsetX == 0 && offsetY == 0) continue;
                    if (Board[X + offsetX][Y + offsetY] == " █") { result++; }
                }
            }
        }
        else if (Y == main.Main.Size - 1 && X < main.Main.Size - 1 && X > 0)
        {
            for (int offsetX = -1; offsetX <= 1; offsetX++)
            {
                for (int offsetY = -1; offsetY <= 0; offsetY++)
                {
                    if (offsetX == 0 && offsetY == 0) continue;
                    if (Board[X + offsetX][Y + offsetY] == " █") { result++; }
                }
            }
        }
        else if(Y == 0 && X < main.Main.Size - 1 && X > 0)
        {
            for (int offsetX = -1; offsetX <= 1; offsetX++)
            {
                for (int offsetY = 0; offsetY <= 1; offsetY++)
                {
                    if (offsetX == 0 && offsetY == 0) continue;
                    if (Board[X + offsetX][Y + offsetY] == " █") { result++; }
                }
            }
        }
        return result;
    }
    
    public static void Reproduction(String[][] Board, int x, int y) {
        if(Board[x][y] == " █" && GetLiveNeighbours(Board, x, y) > 3) {
            Board[x][y] = "  ";
        }
    }
    public static void UnderPopulation(String[][] Board, int x, int y) {
        if(Board[x][y] == " █" && GetLiveNeighbours(Board, x, y) < 3) {
            Board[x][y] = "  ";
        }
    }
    public static void OverPopulation(String[][] Board, int x, int y) {
        if(Board[x][y] == "  " && GetLiveNeighbours(Board, x, y) == 3) {
            Board[x][y] = " █";
        }
    }
}
