package main;

import java.util.*;
import java.lang.*;

public class Main {
    
    public static final int size = 20;
    public static final String[][] grid = new String[size][size];
    
    public static void main(String[] args) {
        /**
         * Display Grid
         * Display live Cells
         * Game Loop
         */
        Scanner input = new Scanner(System.in);
        String Choice;
        do {
            main.Board.initBoard(size * 10);
            gameLoop();
            System.out.println("Would you like to go again? ( y / n)");
            Choice = input.nextLine();
        } while (Choice.equals("y") || Choice.equals("yes"));
    }
    
    
    public static void gameLoop() {
        do {
            for(int x = 0; x < grid.length; x++) {
                for(int y = 0; y < grid.length; y++) {
                    Cells.reproduction(grid, x, y);
                    Cells.overPopulation(grid, x, y);
                    Cells.underPopulation(grid, x, y);
                }
            }
            Board.displayBoard();
            try {
                Thread.sleep(1000);
            } catch(InterruptedException e) {
            
            }
        } while(! Board.isEmpty());
    }
    
}
