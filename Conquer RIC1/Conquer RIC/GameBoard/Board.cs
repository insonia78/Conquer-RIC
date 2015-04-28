using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Community;

namespace GameBoard
{
    /*
     * The implementation of the logical side of the game board as a whole, holds a 2d array of Tile objects, and contains methods for manipulating 
     * the contents of these tiles (their characters, mostly) as well as various other required operations on the board's tiles to make the actions in the game possible 
     * (advancing turns, making the enemies act, calculating a player's move options, etc). 
     * Also holds other relavent game information such as the number of turns.
     */
    public partial class MainWindow
    {
        //instance variables
        private int numRows;
        private int numCols;
        private int numTurns;
        private int numHeroes;
        private int numEnemies;
        private Tile[,] boardspaces;
        private int[,] mapping;

        //accessors and mutators
        public int numberRows
        {
            get
            {
                return numRows;
            }
            set { }
        }
        public int numberCols
        {
            get
            {
                return numCols;
            }
            set { }
        }
        public int heroNumber
        {
            get
            {
                return numHeroes;
            }
            set { }
        }
        public int enemyNumber
        {
            get
            {
                return numEnemies;
            }
            set { }
        }
        public int turnNumber
        {
            get
            {
                return numTurns;
            }
            set { }
        }

        //constructors
        /*
         * Constructor for a blank board, makes a default board of all empty spaces
         */
        public void setupBoard()
        {
            numRows = 15;
            numCols = 15;
            numTurns = 1;
            numHeroes = 5;
            boardspaces = new Tile[numRows, numCols];
            cells = new Grid[numRows, numCols]; //a 2d array of references to the grid cells that make up the board tiles graphically
            for(int r = 0; r < numRows; r++)
            {
                for(int c = 0; c < numCols; c++)
                {
                    boardspaces[r, c] = new Tile(r,c);

                    Grid cell = new Grid(); //Make a new grid object to contain the tile/character objects/buttons, images
                    cells[r, c] = cell;

                    refreshBoardSpace(r, c); //Draws the space for the first time
                    Board.Children.Add(cell);
                }
            }

            countEnemies();
            updateCharacterCountDisplay();
        }

        /*
         * Constructor for setting up a board defined in a text file using various characters in the text file to determine the terrain type of each tile.
         * The input is read character by character, so the file should not be broken up with spaces or with multiple lines.
         * 0 = grass, 1 = mountain, 2 = water, 3 = swamp, other = defaults to grass. In the code, these are returned as their ascii code numbers, and have to be tested accordingly.
         * If the text file is not found, makes a blank, default board instead.
         * 
         * String mapfile = the name of the text file to read input from (Example: "testmap.txt")
         */
        public void setupBoard(String mapfile)
        {
            numRows = 15;
            numCols = 15;
            numTurns = 1;
            numHeroes = 5;
            boardspaces = new Tile[numRows, numCols];
            cells = new Grid[numRows, numCols]; //a 2d array of references to the grid cells that make up the board tiles graphically

            if(!File.Exists(mapfile))
            {
                setupBoard();//make a blank board instead
            }
            else
            {
                using (StreamReader sr = File.OpenText(mapfile))
                {
                    int input;
                    for (int r = 0; r < numRows; r++)
                    {
                        for (int c = 0; c < numCols; c++)
                        {
                            input = sr.Read(); //read the next character in the txt file
                            switch (input)
                            {
                                case 48: //ascii code number for 0, grass (The StreamReader is reading them in as their ascii values)
                                    boardspaces[r, c] = new Tile(r,c,0);
                                    break;
                                case 49: //ascii code  for 3, swamp
                                    boardspaces[r, c] = new Tile(r,c,3);
                                    break;
                                case 52: //Tile_Color1 character: 4
                                    boardspaces[r, c] = new Tile(r, c, 4);
                                    break;
                                case 53: //Tile_Color2 charnumber for 1, mountain
                                    boardspaces[r, c] = new Tile(r,c,1);
                                    break;
                                case 50: //ascii code number for 2, water
                                    boardspaces[r, c] = new Tile(r,c,2);
                                    break;
                                case 51: //ascii code numberacter: 5
                                    boardspaces[r, c] = new Tile(r, c, 5);
                                    break;
                                case 54: //Tile_Color3 character: 6
                                    boardspaces[r, c] = new Tile(r, c, 6);
                                    break;
                                case 55: //Tile_Textured character: 7
                                    boardspaces[r, c] = new Tile(r, c, 7);
                                    break;
                                case 56: //Tile_Texture2 character: 8
                                    boardspaces[r, c] = new Tile(r, c, 8);
                                    break;
                                case 57: //Tile_Texture3 character: 9
                                    boardspaces[r, c] = new Tile(r, c, 9);
                                    break;
                                case 65: //Wall_Horizontal character: A
                                    boardspaces[r, c] = new Tile(r, c, 10);
                                    break;
                                case 66: //Wall_Horizontal2 character: B
                                    boardspaces[r, c] = new Tile(r, c, 11);
                                    break;
                                case 67: //Wall_Horizontal_Texture character: C
                                    boardspaces[r, c] = new Tile(r, c, 12);
                                    break;
                                case 68: //Wall_Horizontal_Texture2 character: D
                                    boardspaces[r, c] = new Tile(r, c, 13);
                                    break;
                                default: //if no input or invalid input found in the file, make a blank grass space instead
                                    boardspaces[r, c] = new Tile(r,c);
                                    break;
                            }

                            Grid cell = new Grid(); //Make a new grid object to contain the tile/character objects/buttons, images
                            cells[r, c] = cell;

                            refreshBoardSpace(r, c); //Draws the space for the first time
                            Board.Children.Add(cell);
                        }
                    }
                }
            }

            countEnemies();
            updateCharacterCountDisplay();
        }

        /*
         * Creates a 2d array of primitive data referring to the location of different characters and whether
         * they're heroes (1) or enemies (2)
         */
        public void mapCharacters()
        {
            for (int r = 0; r < numRows; r++)
            {
                for (int c = 0; c < numCols; c++)
                {
                    if (boardspaces[r, c].containsCharacter())
                    {
                        if (boardspaces[r, c].tileCharacter.GetType().IsSubclassOf(typeof(Community.Hero)))
                            mapping[r, c] = 1;
                        else //is an enemy
                            mapping[r, c] = 2;
                    }
                    else
                        mapping[r, c] = 0;
                }
            }
        }

        /*
         * Moves/copies a character from an old position to a specified new one if the position is within the 2d array's bounds and the new space contains no characters.
         * "Clears" the old tile of the character by setting it to null afterwards.
         * 
         * int oldRow = the row the character is currently in.
         * int oldCol = the column the character is currently in.
         * int newRow = the new row of the desired position to move the character to.
         * int newCol = the new column of the desired position to move the character to.
         */
        public void moveCharacter(int oldRow, int oldCol, int newRow, int newCol)
        {
            if (newRow >= 0 && newRow < numRows && newCol >= 0 && newCol < numCols && boardspaces[newRow, newCol].tileCharacter == null && boardspaces[newRow, newCol].isUnpassable == false)
            {
                boardspaces[newRow, newCol].tileCharacter = boardspaces[oldRow, oldCol].tileCharacter;
                //Update the character's row/column information
                boardspaces[newRow, newCol].tileCharacter.Row = newRow;
                boardspaces[newRow, newCol].tileCharacter.Col = newCol;

                boardspaces[oldRow, oldCol].tileCharacter.Click -= new RoutedEventHandler(Character_Click);
                boardspaces[oldRow, oldCol].tileCharacter.Click -= new RoutedEventHandler(AttackOption_Click);
                boardspaces[oldRow, oldCol].tileCharacter.Click -= new RoutedEventHandler(MoveOption_Click);

                boardspaces[oldRow, oldCol].tileCharacter = null;
                //redraw the two spaces (otherwise the character won't be visible in the new space, and the image will remain in the old space).
                refreshBoardSpace(oldRow, oldCol);
                boardspaces[oldRow, oldCol].Click -= new RoutedEventHandler(Tile_Click); //Tiles were picking up an extra Tile_Click event listener when characters
                //moved onto them 
                refreshBoardSpace(newRow, newCol);
            }
        }

        /*
         * Recursive algorithm. Takes the position and speed of a character, and checks all adjacent (horizontal / vertical, not diagonal) tiles to see
         * if they can be moved to. If more speed remains, checks those tiles to see what adjacent tiles to that tile can be moved to from there, until speed = 0.
         * Tile can only be moved to if it is within the 2d array's bounds, it isn't "solid/unpassable" terrain, and it contains no character.
         * If a tile can be moved to, the tile's isMoveOption is set to true for use when displaying/adding buttons on the map interface.
         * Allows for types of terrain that "slows down" a character (takes multiple "speed" to travel through).
         * 
         * int speed = the value of the character's speed.
         * int row  = the row the character is located in.
         * int col = the column the character is located in.
         */
        public void moveOptions(int speed, int row, int col)
        {
            boardspaces[row, col].isMoveOption = true; //base case
            if(speed > 0)
            {
                //up movement
                if (row - 1 >= 0 && boardspaces[row - 1, col].isUnpassable == false && !boardspaces[row - 1, col].containsCharacter())
                {
                    moveOptions(speed - boardspaces[row - 1, col].requiredMoveSpeed, row - 1, col); //Subtract the required movement speed to move through of the next tile from the remaining speed points
                }
                //down movement
                if (row + 1 < numRows && boardspaces[row + 1, col].isUnpassable == false && !boardspaces[row + 1, col].containsCharacter())
                {
                    moveOptions(speed - boardspaces[row + 1, col].requiredMoveSpeed, row + 1, col);
                }
                //left movement
                if (col - 1 >= 0 && boardspaces[row, col - 1].isUnpassable == false && !boardspaces[row, col - 1].containsCharacter())
                {
                    moveOptions(speed - boardspaces[row, col - 1].requiredMoveSpeed, row, col - 1);
                }
                //right movement
                if (col + 1 < numCols && boardspaces[row, col + 1].isUnpassable == false && !boardspaces[row, col + 1].containsCharacter())
                {
                    moveOptions(speed - boardspaces[row, col + 1].requiredMoveSpeed, row, col + 1);
                }
            }
        }

        /*
         * Loops through the 2d array of board spaces and sets every tile's isMoveOption to false. For use after determining and displaying all move options for a 
         * selected player, clearing all those options afterwards so the variables are ready to display the next player's options.
         */
        public void clearMoveOptions()
        {
            for(int r = 0; r < numRows; r++)
            {
                for(int c = 0; c < numCols; c++)
                {
                    if (boardspaces[r, c].isMoveOption)
                    {
                        boardspaces[r, c].isMoveOption = false;
                        boardspaces[r, c].Click -= new RoutedEventHandler(MoveOption_Click);
                        //refreshBoardSpace(r, c);
                        boardspaces[r, c].BorderThickness = new Thickness(0);
                        //boardspaces[r, c].Click += new RoutedEventHandler(Tile_Click);   //Removed 4/21, delete if it's awhile later and caused no bugs

                        if(boardspaces[r,c].containsCharacter())
                        {
                            boardspaces[r, c].tileCharacter.Click += new RoutedEventHandler(Character_Click);
                        }
                    }
                }
            }
        }

        /*
         * After the user performs all moves/actions, calls the enemyTurn() method, which handles enemy movement/actions/calls to AI, and
         * resets certain attributes for players/enemies that are only for that specific turn (hasMoved, for example), and decreases the amount of turns any effects on them will last.
         * Also increments the turn counter.
         */
        public void nextTurn()
        {
            
            for (int r = 0; r < numRows; r++)
            {
                for (int c = 0; c < numCols; c++)
                {
                    if (boardspaces[r, c].containsCharacter() == true)
                    {
                        boardspaces[r, c].tileCharacter.decrementEffectDurations();
                        boardspaces[r, c].tileCharacter.isActive = true;
                        boardspaces[r, c].tileCharacter.Opacity = 1;
                    }
                }
            }

            numTurns++;
            TurnCounter.Content = ("Turn " + turnNumber);

            //Make sure there's no leftover move/attack events on the board (caused bugs occassionally without this).
            clearMoveOptions();
            clearAttackOptions();
        }

        /*
         * Called on by nextTurn(), loops through the 2d board array, finds every remaining enemy, sets hasMoved = true for that enemy (so that if they move down and/or
         * to the right, the for loops won't encounter those enemies again and move them again) and then calls the enemyMoveAI method for that enemy to determine 
         * where to move them.
         */
        public void enemyTurn()
        {
            for(int r = 0; r < numRows; r++)
            {
                for(int c = 0; c < numCols; c++)
                {
                    if (boardspaces[r, c].containsCharacter() == true && boardspaces[r, c].tileCharacter.GetType().IsSubclassOf(typeof(Community.Enemy)) && boardspaces[r, c].tileCharacter.hasMoved == false)
                    {
                        //enemyMoveAI();
                        boardspaces[r, c].tileCharacter.hasMoved = true;
                    }
                }
            }
        }

        /*
         * Temporary, really sucky enemy movement AI and calls the moveCharacter method to move the enemy once a random direction (vertical, horizontal, or diagonal)
         * has been generated.
         * 
         * int row = the row that the enemy to be moved is currently in
         * int col = the column that the enemy to be moved is currently in
         */
        public void enemyMoveAI(int row, int col)
        {
            //moveOptions(boardspaces[row, col].tileCharacter.CurrentSpeed, row, col);
        }

        /*
         * For tutorial level scripting of animated character movement (when you want to move them to a specific tile)
         */
        private void forceMoveCharacter(int oldRow, int oldCol, int newRow, int newCol)
        {
            selectedCharacterRow = oldRow;
            selectedCharacterCol = oldCol;
            boardspaces[oldRow, oldCol].tileCharacter.hasMoved = false;
            MoveOption_Click(boardspaces[newRow, newCol], null);
            boardspaces[newRow, newCol].tileCharacter.hasMoved = false;
        }

        /*
         * Loops through the 2d array of board spaces and counts the number of enemy objects (or subclasses of enemy) for use in displaying as well as confirming a win condition
         */
        public void countEnemies()
        {
            numEnemies = 0;
            for (int r = 0; r < numRows; r++)
            {
                for (int c = 0; c < numCols; c++)
                {
                    if (boardspaces[r, c].containsCharacter() == true && (boardspaces[r, c].tileCharacter.GetType() == typeof(Community.Enemy) || boardspaces[r, c].tileCharacter.GetType().IsSubclassOf(typeof(Community.Enemy))))
                    {
                        numEnemies++;
                    }
                }
            }
        }

        private void updateCharacterCountDisplay()
        {
            HeroesCounter.Content = ("Heroes Remaining: " + numHeroes);
            EnemyCounter.Content = ("Enemies Remaining: " + numHeroes);
        }

        /*
         * Loops through the 2d array of board spaces and checks if all player objects (or subclass objects of player) have isActive = false, in order to see if 
         * every player character has taken their turn and the turn can automatically end.
         * 
         * returns false if any players are active, true if they all have.
         */
        public bool checkAllPlayersInactive()
        {
            for (int r = 0; r < numRows; r++)
            {
                for (int c = 0; c < numCols; c++)
                {
                    if (boardspaces[r, c].containsCharacter() == true && (boardspaces[r, c].tileCharacter.GetType() == typeof(Community.Hero) || boardspaces[r, c].tileCharacter.GetType().IsSubclassOf(typeof(Community.Hero))) && boardspaces[r, c].tileCharacter.isActive == true)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

    }
}
