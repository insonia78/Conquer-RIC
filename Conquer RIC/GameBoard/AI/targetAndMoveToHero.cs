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

namespace GameBoard
{
    public partial class MainWindow : Window
    {
        int aheroRow, aheroCol;
        int aindex = 0;
        int iterationNumber = 0;
         int i = 0;
        public void targetAndMoveToHero()
        {
            int row = 0;
            int col = 0;
            int done;
            iterationNumber = 0;
            ArrayList selectEnemy = new ArrayList(); 
            i = 0;
            aindex = 0;
            if(targetEnemyRow.Count > targetHeroRow.Count)
            {
                done = targetEnemyRow.Count;
            }
            else
            {
                done = targetHeroRow.Count;
            }

            if (targetEnemyRow.Count > 0 && countEnemiesForloop > 0)
            {
                try
                {
                    aheroRow = (int)targetHeroRow[i];
                    aheroCol = (int)targetHeroCol[i];

                }
                catch
                {
                }

                try
                {
                    int ai = 0;
                    while (ai < targetEnemyRow.Count)
                    {
                        row = Math.Abs((int)targetEnemyRow[ai] - aheroRow);
                        col = Math.Abs((int)targetEnemyCol[ai] - aheroCol);
                        selectEnemy.Add(col + row);
                        ai++;
                    }
                    int temp = (int)selectEnemy[0];
                    aindex = 0;
                    for (int y = 0; y < selectEnemy.Count; y++)
                    {
                        if (temp < (int)selectEnemy[y])
                        {

                        }
                        else
                        {
                            temp = (int)selectEnemy[y];
                            aindex = y;
                        }

                    }
                    selectedCharacterRow = (int)targetEnemyRow[aindex];
                    selectedCharacterCol = (int)targetEnemyCol[aindex];
                }
                catch
                {
                }
                try
                {
                    targetEnemyRow.RemoveAt(aindex);
                    targetEnemyCol.RemoveAt(aindex);
                }
                catch
                {
                    
                }
                // i++;

            }
            else
            {
                ok = false;
                Enemytimer.Stop();
                Enemytimer.Tick -= Etimer_Tick;
                

            }
                
                //EnemyAbility1();
                //displayEnemyAttackAreas();
            }
        
        
         
        }
    }

