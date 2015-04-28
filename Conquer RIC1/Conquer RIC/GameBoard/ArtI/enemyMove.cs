using System;
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
using System.Collections;

namespace GameBoard
{
    public partial class MainWindow : Window
    {
        public void enemyMove()
        {
            moveOptions(boardspaces[selectedHeroRow, selectedHeroCol].tileCharacter.speed, selectedHeroRow, selectedHeroCol);
            for (int r = 0; r < numRows; r++)
            {
                for (int c = 0; c < numCols; c++)
                {
                    if (boardspaces[r, c].isMoveOption) //display buttons for the user to click to chose where to move the selected player.
                    {
                        position[r, c] = boardspaces[r, c];
                        boardspaces[r, c].Click -= new RoutedEventHandler(Tile_Click); //Remove the Tile_Click event handler from the tile button
                        boardspaces[r, c].Click += new RoutedEventHandler(MoveOption_Click); //Add a MoveOption_Click event handler to the tile button
                        //Make a colored border around moveOption spaces to signify which ones they are to the user.
                        boardspaces[r, c].BorderBrush = moveOption;
                        boardspaces[r, c].BorderThickness = new Thickness(1);

                    }
                }
            }
        }
    }
}
