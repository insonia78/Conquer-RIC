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
        public void EnemyAttachOption()
        {
          boardspaces = boardspaces[selectedHeroRow, selectedHeroCol].tileCharacter.Attack1(boardspaces, numRows, numCols); //Determines the different spaces the character can attack

            for (int r = 0; r < numRows; r++)
            {
                for (int c = 0; c < numCols; c++)
                {
                    if (boardspaces[r, c].attackOption != 0) //display buttons fof the different spaces the user can attack
                    {
                      //  boardspaces[r, c].Click -= new RoutedEventHandler(Tile_Click); //Remove the Tile_Click event handler from the tile button
                      //  boardspaces[r, c].Click += new RoutedEventHandler(AttackOption_Click); //Add a AttackOption_Click event handler to the tile button
                      //  boardspaces[r, c].MouseEnter += new MouseEventHandler(AttackOption_MouseEnter);
                      //  boardspaces[r, c].MouseLeave += new MouseEventHandler(AttackOption_MouseLeave);
                        //Make a colored border around attackOption spaces to signify which ones they are to the user.
                        boardspaces[r, c].BorderBrush = attackOption;
                        boardspaces[r, c].BorderThickness = new Thickness(1);

                    }
                }
            }
        }
        
    }
}
