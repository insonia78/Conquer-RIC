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
using Community;
using GameBoard;
namespace GameBoard
{
    public partial class MainWindow : Window
    {
        private void EnemyMoveOption()
        {

            




            //Make sure the selected hero hasn't already moved this turn (mostly not necessary, but for safety against glitches?)
            if (!boardspaces[selectedCharacterRow, selectedCharacterCol].tileCharacter.hasMoved)
            {
                int type = 0;


                String display = "";
                int i = 0;

                boardspaces[selectedCharacterRow, selectedCharacterCol].tileCharacter.hasMoved = true;

                timer.Interval = TimeSpan.FromSeconds(0.2);

                //Disables the mouse from clicking on anything so the user can't click something else mid animation (bad things would happen)
                this.IsHitTestVisible = false;
                //Changes the cursor to a loading/waiting cursor for the duration of the animation to help let the user know they can't use the mouse
                Mouse.OverrideCursor = Cursors.Wait;

                dummyRow = selectedCharacterRow;
                dummyCol = selectedCharacterCol;
                moveRow = moveToRow;
                
                if (selectedCharacterRow == moveToRow)
                {
                    if (selectedCharacterCol <= moveToCol)
                    {
                        type = 0;
                        PlotRoot(type);

                        timer.Tick += Etimer0_Tick;
                        timer.Start();

                    }
                    if (selectedCharacterCol > moveToCol)
                    {
                        type = 1;
                        PlotRoot(type);
                        timer.Tick += Etimer1_Tick;
                        timer.Start();

                    }

                }
                else if (selectedCharacterCol == moveToCol)
                {
                    if (selectedCharacterRow < moveToRow)
                    {
                        type = 2;
                        PlotRoot(type);
                        timer.Tick += Etimer2_Tick;
                        timer.Start();

                    }
                    if (selectedCharacterRow > moveToRow)
                    {
                        type = 3;
                        PlotRoot(type);
                        timer.Tick += Etimer3_Tick;
                        timer.Start();

                    }

                }
                else if (selectedCharacterCol < moveToCol && selectedCharacterRow < moveToRow)
                {
                    type = 4;
                    PlotRoot(type);
                    timer.Tick += Etimer4_Tick;
                    timer.Start();

                }
                else if (selectedCharacterCol < moveToCol && selectedCharacterRow > moveToRow)
                {
                    type = 5;
                    PlotRoot(type);
                    timer.Tick += Etimer5_Tick;
                    timer.Start();


                }
                else if (selectedCharacterCol > moveToCol && selectedCharacterRow > moveToRow)
                {
                    type = 6;
                    PlotRoot(type);
                    timer.Tick += Etimer6_Tick;
                    timer.Start();


                }
                else if (selectedCharacterCol > moveToCol && selectedCharacterRow < moveToRow)
                {
                    type = 7;
                    PlotRoot(type);
                    timer.Tick += Etimer7_Tick;
                    timer.Start();

                }

            }

            //Disable the move button.
            //MessageBox.Show("hello");

        }
        public void Etimer0_Tick(object sender, EventArgs e)
        {
            //MessageBox.Show("hello");
            if (dummyCol == moveToCol)
            {
                timer.Stop();
                timer.Tick -= Etimer0_Tick;
                EClear();
            }
            else
            {
                moveRow = (int)rowPlot[index];
                moveCol = (int)colPlot[index];
                moveCharacter(dummyRow, dummyCol, moveRow, moveCol);
                dummyCol = moveCol;
                dummyRow = moveRow;
                index++;
            }

        }
        void Etimer1_Tick(object sender, EventArgs e)
        {
            //MessageBox.Show("hello");
            if (dummyCol == moveToCol)
            {
                timer.Stop();
                timer.Tick -= Etimer1_Tick;
                EClear();
            }
            else
            {
                moveRow = (int)rowPlot[index];
                moveCol = (int)colPlot[index];
                moveCharacter(dummyRow, dummyCol, moveRow, moveCol);
                dummyCol = moveCol;
                dummyRow = moveRow;
                index++;
            }

        }
        void Etimer2_Tick(object sender, EventArgs e)
        {
            //MessageBox.Show("hello");
            if (dummyRow == moveToRow)
            {
                timer.Stop();
                timer.Tick -= Etimer2_Tick;
                EClear();
            }
            else
            {
                moveRow = (int)rowPlot[index];
                moveCol = (int)colPlot[index];
                moveCharacter(dummyRow, dummyCol, moveRow, moveCol);
                dummyCol = moveCol;
                dummyRow = moveRow;
                index++;
            }

        }
        void Etimer3_Tick(object sender, EventArgs e)
        {
            //MessageBox.Show("hello");
            if (dummyRow == moveToRow)
            {
                timer.Stop();
                timer.Tick -= Etimer3_Tick;
                EClear();
            }
            else
            {
                moveRow = (int)rowPlot[index];
                moveCol = (int)colPlot[index];
                moveCharacter(dummyRow, dummyCol, moveRow, moveCol);
                dummyCol = moveCol;
                dummyRow = moveRow;
                index++;
            }

        }
        void Etimer4_Tick(object sender, EventArgs e)
        {
            //MessageBox.Show("hello");
            if (dummyCol == moveToCol && dummyRow == moveToRow)
            {
                timer.Stop();
                timer.Tick -= Etimer4_Tick;
                EClear();
            }
            else
            {
                moveRow = (int)rowPlot[index];
                moveCol = (int)colPlot[index];
                moveCharacter(dummyRow, dummyCol, moveRow, moveCol);
                dummyCol = moveCol;
                dummyRow = moveRow;
                index++;
            }

        }
        void Etimer5_Tick(object sender, EventArgs e)
        {
            //MessageBox.Show("hello");
            if (dummyCol == moveToCol && dummyRow == moveToRow)
            {
                timer.Stop();
                timer.Tick -= Etimer5_Tick;
                EClear();
            }
            else
            {
                moveRow = (int)rowPlot[index];
                moveCol = (int)colPlot[index];
                moveCharacter(dummyRow, dummyCol, moveRow, moveCol);
                dummyCol = moveCol;
                dummyRow = moveRow;
                index++;
            }

        }
        void Etimer6_Tick(object sender, EventArgs e)
        {
            //MessageBox.Show("hello");
            if (dummyCol == moveToCol && dummyRow == moveToRow)
            {
                timer.Stop();
                timer.Tick -= Etimer6_Tick;
                EClear();
            }
            else
            {
                moveRow = (int)rowPlot[index];
                moveCol = (int)colPlot[index];
                moveCharacter(dummyRow, dummyCol, moveRow, moveCol);
                dummyCol = moveCol;
                dummyRow = moveRow;
                index++;
            }

        }
        void Etimer7_Tick(object sender, EventArgs e)
        {
            //MessageBox.Show("hello");
            if (dummyCol == moveToCol && dummyRow == moveToRow)
            {
                timer.Stop();
                timer.Tick -= Etimer7_Tick;
                EClear();
            }
            else
            {
                moveRow = (int)rowPlot[index];
                moveCol = (int)colPlot[index];
                moveCharacter(dummyRow, dummyCol, moveRow, moveCol);
                dummyCol = moveCol;
                dummyRow = moveRow;
                index++;
            }

        }
        private void EClear()
        {
            selectedCharacterRow = moveRow;
            selectedCharacterCol = moveCol;

            clearMoveOptions();
            rowPlot.Clear();
            colPlot.Clear();
            index = 0;
            

            //Reenables the mouse once the animation is done and the user can't screw things up.
            this.IsHitTestVisible = true;
            //Sets the cursor back to the normal one.
            Mouse.OverrideCursor = null;
            if (countEnemiesForloop == (numEnemies - (numEnemies - countEnemiesForloop)))
            {
                Enemytimer.Tick += Etimer_Tick;
                Enemytimer.Start();
            }

            
        }
    }
}
