using System.Windows;

namespace GameBoard
{
    public partial class MainWindow : Window
    {
        int positionRow;
        int positionCol;
        public void PlotRoot(int type)
        {
            int row = selectedCharacterRow; positionRow = selectedCharacterRow;
            int col = selectedCharacterCol; positionCol = selectedCharacterCol;
            switch (type)
            {
                case 0:
                    {
                        positioCol_LessThenEqualTo_moveToCol();
                        break;
                    }
                case 1:
                    {
                        positioCol_MoreThenEqualTo_moveToCol();
                        break;
                    }
                case 2:
                    {
                        positioRow_LessThenEqualTo_moveToRow();
                        break;
                    }
                case 3:
                {
                    positioRow_MoreThenEqualTo_moveToRow();
                    break;
                }
                case 4:
                {
                    positionCol_lessEqual_moveToCol_And_positionRow_LessEqual_MovetoRow();
                    break;
                }
                case 5:
                {
                    positionCol_lessEqual_moveToCol_And_positionRow_MoreEqual_MovetoRow();
                    break;
                }
                case 6:
                {
                    positionCol_MoreEqual_moveToCol_And_positionRow_MoreEqual_MovetoRow();
                    break;
                }
                case 7:
                {
                    positionCol_MoreEqual_moveToCol_And_positionRow_LessEqual_MovetoRow();
                    break;
                }
            }

        }
        /// <summary>
        /// /case 0 with constant row and destintaion col > than character col
        /// </summary>
        public void positioCol_LessThenEqualTo_moveToCol()
        {
            int tempRow = positionRow;
            while (positionCol != moveToCol && positionRow == moveToRow)
            {
                rowPlot.Add(tempRow);
                colPlot.Add(positionCol);
                tempRow = positionRow;
                positionCol++;
                try
                {
                    if (position[positionRow, positionCol].GetType() == null)
                    {
                    }

                }
                catch
                {
                    try
                    {
                        if (position[positionRow - 1, positionCol].GetType() == null)
                        {
                        }
                        else
                        {

                            tempRow += 1;

                        }

                    }
                    catch
                    {
                        tempRow -= 1;

                    }
                }



            }
            if (positionCol == moveToCol && positionRow == moveToRow)
            {

                rowPlot.Add(positionRow);
                colPlot.Add(positionCol);
            }
            

         }
        /// <summary>
        /// case 1 with position col > than destination col witnh constant row 
        /// </summary>
        public void positioCol_MoreThenEqualTo_moveToCol()
        {
            int tempRow = positionRow;
            while (positionCol != moveToCol && positionRow == moveToRow)
            {
                rowPlot.Add(tempRow);
                colPlot.Add(positionCol);
                tempRow = positionRow;
                positionCol--;
                try
                {
                    if (position[positionRow, positionCol].GetType() == null)
                    {
                    }

                }
                catch
                {
                    try
                    {
                        if (position[positionRow - 1, positionCol].GetType() == null)
                        {
                        }
                        else
                        {

                            tempRow += 1;

                        }

                    }
                    catch
                    {
                        tempRow -= 1;

                    }
                }



            }
            if (positionCol == moveToCol && positionRow == moveToRow)
            {

                rowPlot.Add(positionRow);
                colPlot.Add(positionCol);
            }
            


        }
        /// <summary>
        /// case 2 constant col and destination row > then caracter row
        /// </summary>
        public void positioRow_LessThenEqualTo_moveToRow()
        {
            int tempCol = positionCol;
            while (positionCol == moveToCol && positionRow != moveToRow)
            {
                rowPlot.Add(positionRow);
                colPlot.Add(tempCol);
                tempCol = positionCol;
                positionRow++;
                try
                {
                    if (position[positionRow, positionCol].GetType() == null)
                    {
                    }

                }
                catch
                {
                    try
                    {
                        if (position[positionRow - 1, positionCol].GetType() == null)
                        {
                        }
                        else
                        {

                            tempCol += 1;

                        }

                    }
                    catch
                    {
                        tempCol -= 1;

                    }
                }



            }


        
        if (positionCol == moveToCol && positionRow == moveToRow)
            {

                rowPlot.Add(positionRow);
                colPlot.Add(positionCol);
            }
        

        }
        /// <summary>
        /// case 3 constant col and destination row is less that character row
        /// </summary>
        public void positioRow_MoreThenEqualTo_moveToRow()
        {
            int tempCol = positionCol;
            while (positionCol == moveToCol && positionRow != moveToRow)
            {
                rowPlot.Add(positionRow);
                colPlot.Add(tempCol);
                tempCol = positionCol;
                positionRow--;
                try
                {
                    if (position[positionRow, positionCol].GetType() == null)
                    {
                    }

                }
                catch
                {
                    try
                    {
                        if (position[positionRow, positionCol - 1].GetType() == null)
                        {
                        }
                        else
                        {

                            tempCol -= 1;
                        }

                    }
                    catch
                    {
                        tempCol += 1;

                    }
                }
                

                

            }
            if (positionCol == moveToCol && positionRow == moveToRow)
            {

                rowPlot.Add(positionRow);
                colPlot.Add(positionCol);
            }
            

        }
        
        /// <summary>
        /// case 4 destination col and row are more then character row, col
        /// </summary>
        public void positionCol_lessEqual_moveToCol_And_positionRow_LessEqual_MovetoRow()
        {
            while (positionCol != moveToCol && positionRow != moveToRow)
            {
                try
                {
                    if (position[positionRow + 1, positionCol + 1].GetType() == null)
                    {
                    }
                    else
                    {
                        rowPlot.Add(positionRow += 1);
                        colPlot.Add(positionCol += 1);
                    }

                }
                catch
                {
                    try
                    {
                        if (position[positionRow, positionCol + 1].GetType() == null)
                        {
                        }
                        else
                        {

                            colPlot.Add(positionCol += 1);
                            rowPlot.Add(positionRow);
                        }

                    }
                    catch
                    {
                        try
                        {
                            if (position[positionRow + 1, positionCol].GetType() == null)
                            {
                            }
                            else
                            {
                                rowPlot.Add(positionRow += 1);
                                colPlot.Add(positionCol);
                            }

                        }
                        catch { }


                    }
                }
            }
            int tempRow = positionRow;
            while (positionCol != moveToCol && positionRow == moveToRow)
            {
                rowPlot.Add(tempRow);
                colPlot.Add(positionCol);
                tempRow = positionRow;
                positionCol++;
                try
                {
                    if (position[positionRow, positionCol].GetType() == null)
                    {
                    }

                }
                catch
                {
                    try
                    {
                        if (position[positionRow - 1, positionCol].GetType() == null)
                        {
                        }
                        else
                        {

                            tempRow += 1;

                        }

                    }
                    catch
                    {
                        tempRow -= 1;

                    }
                }
                


            }
            int tempCol = positionCol;
            while (positionCol == moveToCol && positionRow != moveToRow)
            {
                rowPlot.Add(positionRow);
                colPlot.Add(tempCol);
                tempCol = positionCol;
                positionRow++;
                try
                {
                    if (position[positionRow, positionCol].GetType() == null)
                    {
                    }

                }
                catch
                {
                    try
                    {
                        if (position[positionRow, positionCol - 1].GetType() == null)
                        {
                        }
                        else
                        {

                            tempCol += 1;
                        }

                    }
                    catch
                    {
                        tempCol -= 1;

                    }
                }
                

                

            }
            if(positionCol == moveToCol && positionRow == moveToRow)
            {
            
                    rowPlot.Add(positionRow);
                    colPlot.Add(positionCol);
            }
        }
        /// <summary>
        /// ////////case 5
        /// </summary>
        public void positionCol_lessEqual_moveToCol_And_positionRow_MoreEqual_MovetoRow()
        {
            while (positionCol != moveToCol && positionRow != moveToRow)
            {
                try
                {
                    if (position[positionRow - 1, positionCol + 1].GetType() == null)
                    {
                    }
                    else
                    {
                        rowPlot.Add(positionRow -= 1);
                        colPlot.Add(positionCol += 1);
                    }

                }
                catch
                {
                    try
                    {
                        if (position[positionRow, positionCol + 1].GetType() == null)
                        {
                        }
                        else
                        {

                            colPlot.Add(positionCol += 1);
                            rowPlot.Add(positionRow);
                        }

                    }
                    catch
                    {
                        try
                        {
                            if (position[positionRow - 1, positionCol].GetType() == null)
                            {
                            }
                            else
                            {
                                rowPlot.Add(positionRow -= 1);
                                colPlot.Add(positionCol);
                            }

                        }
                        catch { }


                    }
                }
            }
            int tempRow = positionRow;
            while (positionCol != moveToCol && positionRow == moveToRow)
            {
                rowPlot.Add(tempRow);
                colPlot.Add(positionCol);
                tempRow = positionRow;
                positionCol++;
                try
                {
                    if (position[positionRow, positionCol].GetType() == null)
                    {
                    }

                }
                catch
                {
                    try
                    {
                        if (position[positionRow - 1, positionCol].GetType() == null)
                        {
                        }
                        else
                        {

                            tempRow -= 1;

                        }

                    }
                    catch
                    {
                        tempRow += 1;

                    }
                }
                


            }
            int tempCol = positionCol;
            while (positionCol == moveToCol && positionRow != moveToRow)
            {
                rowPlot.Add(positionRow);
                colPlot.Add(tempCol);
                tempCol = positionCol;
                positionRow--;
                try
                {
                    if (position[positionRow, positionCol].GetType() == null)
                    {
                    }

                }
                catch
                {
                    try
                    {
                        if (position[positionRow, positionCol - 1].GetType() == null)
                        {
                        }
                        else
                        {

                            tempCol -= 1;
                        }

                    }
                    catch
                    {
                        tempCol += 1;

                    }
                }
                

            }
            if (positionCol == moveToCol && positionRow == moveToRow)
            {

                rowPlot.Add(positionRow);
                colPlot.Add(positionCol);
            }
            refreshBoardSpace(6, 5);
        }
        /// <summary>
        /// /////////case 6
        /// </summary>
        public void positionCol_MoreEqual_moveToCol_And_positionRow_MoreEqual_MovetoRow()
        {

            while (positionCol != moveToCol && positionRow != moveToRow)
            {
                try
                {
                    if (position[positionRow - 1, positionCol - 1].GetType() == null)
                    {
                    }
                    else
                    {
                        rowPlot.Add(positionRow -= 1);
                        colPlot.Add(positionCol -= 1);
                    }

                }
                catch
                {
                    try
                    {
                        if (position[positionRow, positionCol - 1].GetType() == null)
                        {
                        }
                        else
                        {

                            colPlot.Add(positionCol -= 1);
                            rowPlot.Add(positionRow);
                        }

                    }
                    catch
                    {
                        try
                        {
                            if (position[positionRow - 1, positionCol].GetType() == null)
                            {
                            }
                            else
                            {
                                rowPlot.Add(positionRow -= 1);
                                colPlot.Add(positionCol);
                            }

                        }
                        catch { }


                    }
                }
            }
            int tempRow = positionRow;
            while (positionCol != moveToCol && positionRow == moveToRow)
            {
                rowPlot.Add(tempRow);
                colPlot.Add(positionCol);
                tempRow = positionRow;
                positionCol--;  


                try
                {
                    if (position[positionRow, positionCol].GetType() == null)
                    {
                    }
                    
                }
                catch
                {
                    try
                    {
                        if (position[positionRow - 1, positionCol].GetType() == null)
                        {
                        }
                        else
                        {

                            tempRow -= 1;
                            
                        }

                    }
                    catch
                    {
                        tempRow += 1;

                    }
                }
                

            }
            int tempCol = positionCol;
            while (positionCol == moveToCol && positionRow != moveToRow)
            {
                rowPlot.Add(positionRow);
                colPlot.Add(tempCol);
                tempCol = positionCol;
                positionRow--;  
                try
                {
                    if (position[positionRow , positionCol].GetType() == null)
                    {
                    }
                    
                }
                catch
                {
                    try
                    {
                        if (position[positionRow, positionCol - 1].GetType() == null)
                        {
                        }
                        else
                        {

                            tempCol -= 1;
                        }

                    }
                    catch
                    {
                        tempCol += 1;

                    }
                }
                

            }
            if (positionCol == moveToCol && positionRow == moveToRow)
            {

                rowPlot.Add(positionRow);
                colPlot.Add(positionCol);
            }



            

        }
        /// <summary>
        /// ////////case 7
        /// </summary>
       public void positionCol_MoreEqual_moveToCol_And_positionRow_LessEqual_MovetoRow()
        {
            while (positionCol != moveToCol && positionRow != moveToRow)
            {
                try
                {
                    if (position[positionRow + 1, positionCol - 1].GetType() == null)
                    {
                    }
                    else
                    {
                        rowPlot.Add(positionRow += 1);
                        colPlot.Add(positionCol -= 1);
                    }

                }
                catch
                {
                    try
                    {
                        if (position[positionRow, positionCol - 1].GetType() == null)
                        {
                        }
                        else
                        {

                            colPlot.Add(positionCol -= 1);
                            rowPlot.Add(positionRow);
                        }

                    }
                    catch
                    {
                        try
                        {
                            if (position[positionRow + 1, positionCol].GetType() == null)
                            {
                            }
                            else
                            {
                                rowPlot.Add(positionRow += 1);
                                colPlot.Add(positionCol);
                            }

                        }
                        catch { }


                    }
                }
            }
            int tempRow = positionRow;
            while (positionCol != moveToCol && positionRow == moveToRow)
            {
                rowPlot.Add(tempRow);
                colPlot.Add(positionCol);
                tempRow = positionRow;
                positionCol--;                            
                try
                {
                    if (position[positionRow, positionCol].GetType() == null)
                    {
                    }
                    
                }
                catch
                {
                    try
                    {
                        if (position[positionRow + 1, positionCol ].GetType() == null)
                        {
                        }
                        else
                        {

                            
                            tempRow +=1;
                        }

                    }
                    catch
                    {
                        tempRow -= 1;

                    }
                }
      
                

            }
            int tempCol = positionCol;
            while (positionCol == moveToCol && positionRow != moveToRow)
            {
                rowPlot.Add(positionRow);
                colPlot.Add(tempCol);
                tempCol = positionCol;
                positionRow++;
                
                try
                {
                    if (position[positionRow, positionCol].GetType() == null)
                    {
                    }
                    

                }
                catch
                {
                    try
                    {
                        if (position[positionRow, positionCol - 1].GetType() == null)
                        {
                        }
                        else
                        {

                            tempCol-=1 ;
                            
                        }

                    }
                    catch
                    {
                        tempCol += 1;


                    }
                }

                

            }
            if (positionCol == moveToCol && positionRow == moveToRow)
            {

                rowPlot.Add(positionRow);
                colPlot.Add(positionCol);
            }
            else
            {
                positionCol_MoreEqual_moveToCol_And_positionRow_LessEqual_MovetoRow();
            }



        }

        
        }

    }

