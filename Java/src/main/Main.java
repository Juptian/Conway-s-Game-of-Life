package main;

import java.util.*;
import java.lang.*;

public class Main {
    
    public static final int Size = 20;
    public static final String[][] Grid = new String[Size][Size];
    
    public static void main(String[] args) {
        /**
         * Display Grid
         * Display live Cells
         * Game Loop
         */
        Scanner input = new Scanner(System.in);
        String Choice;
        do {
            main.Board.InitBoard(Size * 10);
            GameLoop();
            System.out.println("Would you like to go again? ( y / n)");
            Choice = input.nextLine();
        } while (Choice.equals("y") || Choice.equals("yes"));
    }
    
    
    public static void GameLoop() {
        do {
            for(int x = 0; x < Grid.length; x++) {
                for(int y = 0; y < Grid.length; y++) {
                    main.Cells.Reproduction(Grid, x, y);
                    main.Cells.OverPopulation(Grid, x, y);
                    main.Cells.UnderPopulation(Grid, x, y);
                }
            }
            main.Board.DisplayBoard();
            try {
                Thread.sleep(1000);
            } catch(InterruptedException e) {
            
            }
        } while(! main.Board.IsEmpty());
    }
    
}
