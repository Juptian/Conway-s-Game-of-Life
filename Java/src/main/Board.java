package main;

import java.util.Arrays;
import java.util.Random;

public class Board {
    public static void initBoard(int AmountOfCells) {
        for( int i = 0; i < Main.grid.length; i++) {
            Arrays.fill(Main.grid[i], "  ");
        }
    
        Random rand = new Random();
        for(int i = 0; i < AmountOfCells; i++) {
            int x = rand.nextInt(Main.size);
            int y = rand.nextInt(Main.size);
            Main.grid[x][y] = " █";
        }
    }
    
    public static boolean isEmpty() {
        for( int i = 0; i < main.Main.grid.length; i++) {
            for( int z = 0; z < main.Main.grid.length; z++) {
                if( main.Main.grid[i][z] == " █") {
                    return false;
                }
            }
        }
        return true;
    }
    
    public static void displayBoard() {
        System.out.flush();
        for(int i = 0; i < Main.grid.length; i++) {
            for(int z = 0; z < Main.grid.length; z++) {
                if(z == Main.grid.length - 1) {
                    System.out.println(Main.grid[i][z]);
                } else {
                    System.out.print(Main.grid[i][z]);
                }
            }
        }
        System.out.println("\n");
    }
}
