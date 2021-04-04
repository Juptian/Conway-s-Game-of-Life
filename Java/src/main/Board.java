package main;

import java.util.Arrays;
import java.util.Random;

public class Board {
    public static void InitBoard(int AmountOfCells) {
        for( int i = 0; i < Main.Grid.length; i++) {
            Arrays.fill(Main.Grid[i], "  ");
        }
    
        Random rand = new Random();
        for(int i = 0; i < AmountOfCells; i++) {
            int x = rand.nextInt(Main.Size);
            int y = rand.nextInt(Main.Size);
            Main.Grid[x][y] = " █";
        }
    }
    
    public static boolean IsEmpty() {
        for( int i = 0; i < Main.Grid.length; i++) {
            for( int z = 0; z < Main.Grid[1].length; z++) {
                if( Main.Grid[i][z] == " █") {
                    return false;
                }
            }
        }
        return true;
    }
    
    public static void DisplayBoard() {
        System.out.flush();
        for(int i = 0; i < Main.Grid.length; i++) {
            for(int z = 0; z < Main.Grid.length; z++) {
                if(z == Main.Grid.length - 1) {
                    System.out.println(Main.Grid[i][z]);
                } else {
                    System.out.print(Main.Grid[i][z]);
                }
            }
        }
        System.out.println("\n");
    }
}
