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
    public partial class MainWindow: Window
    {
        ArrayList targetHeroRow = new ArrayList();
        ArrayList targetHeroCol = new ArrayList();
        ArrayList targetEnemyRow = new ArrayList();
        ArrayList targetEnemyCol = new ArrayList();
        
          
        public void targetHero()
        {
            int progressCount = 0;
            int idh = 0;
            int coldh = 0;
            int temp = 0;
           while (progressCount < countHero)
           {
                temp = (int)heroRow[0];
                while (idh < countHero)
                {
                    
                    if (temp >= (int)heroRow[idh])
                    {
                        coldh = idh;
                    }
                    else
                    {
                        temp = (int)heroRow[idh];
                        coldh = idh;
                    }
                    if (idh == (countHero - 1))
                    {
                        
                            targetHeroRow.Add( temp);
                            targetHeroCol.Add((int)heroCol[coldh]);
                            heroCol.RemoveAt(coldh);
                            heroRow.RemoveAt(coldh);
                    }
                        
                    idh++;
                }
                progressCount++;
            }
            heroRow.Clear();
            heroCol.Clear();
            idh = 0;
            coldh = 0;
            progressCount = 0;
            while (progressCount < countEnemy)
            {
                temp = (int)enemyRow[0];

                while (idh < countEnemy)
                {
                    if (temp >= (int)enemyRow[idh])
                    {
                        coldh = idh;
                    }
                    else
                    {
                        temp = (int)enemyRow[idh];
                        coldh = idh;
                    }
                    if (idh == (countEnemy - 1))
                    {
                        
                            targetEnemyRow.Add(temp);
                            targetEnemyCol.Add((int)enemyCol[coldh]);
                            enemyCol.RemoveAt(coldh);
                            enemyRow.RemoveAt(coldh);
                       
                     }
                        
                    idh++;

                }
                progressCount++;
            }
            enemyCol.Clear();
            enemyRow.Clear();
        }
        

    }
}
