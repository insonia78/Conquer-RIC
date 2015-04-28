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
            bool test = false;
            int tempRowMinus = 0;
            int tempRowPlus = 0;
            int holdtempRowMinusResult = 0;
            int holdtempRowPlusResult = 0;
            int tempRow = positionRow;
            rowPlot.Add(tempRow);
            ArrayList rowMinus = new ArrayList();
            ArrayList rowPlus = new ArrayList();
            ArrayList colMinus = new ArrayList();
            ArrayList colPlus = new ArrayList();
            while (positionCol != moveToCol && positionRow == moveToRow)
            {                
                
                tempRow = positionRow;
                positionCol++;

               while (boardspaces[tempRow, positionCol].isMoveOption == false && test == false)
                {
                    if (boardspaces[--tempRow, positionCol].isMoveOption == false)
                    {
                        
                    }
                    else
                    {
                        tempRowMinus++;
                        holdtempRowMinusResult = tempRow;
                        rowMinus.Add(tempRow);
                        colMinus.Add(positionCol);
                        tempRow = positionRow;
                        if (positionCol != moveToCol && positionRow == moveToRow)
                        { 
                        }
                        else
                        {
                            test = true;
                        }
                    }

                }
                test = false;
                while (boardspaces[tempRow, positionCol].isMoveOption == false && test == false)
                {
                    if (boardspaces[++tempRow, positionCol].isMoveOption == false)
                    {
                        
                    }
                    else
                    {
                        tempRowPlus++;
                        holdtempRowPlusResult = tempRow;
                        rowPlus.Add(tempRow);
                        colPlus.Add(positionCol);
                        if (positionCol != moveToCol && positionRow == moveToRow)
                        {
                        }
                        else
                        {
                            test = true;
                        }

                    }

                }
                if (tempRowPlus >= tempRowMinus && test == true)
                {
                    tempRow = holdtempRowMinusResult;
                    rowPlot.Add(rowMinus);
                    colPlot.Add(colMinus);

                }
                else if (tempRowPlus < tempRowMinus && test == true)
                {
                    tempRow = holdtempRowPlusResult;
                    rowPlot.Add(rowPlus);
                    colPlot.Add(colPlus);
                }
                else
                {
                    rowPlot.Add(tempRow);
                    colPlot.Add(positionCol);
                }
                test = false;               
            
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
            bool test = false;
            int tempRowMinus = 0;
            int tempRowPlus = 0;
            int holdtempRowMinusResult = 0;
            int holdtempRowPlusResult = 0;
            int tempRow = positionRow;
            rowPlot.Add(tempRow);
            colPlot.Add(positionCol);
            ArrayList rowMinus = new ArrayList();
            ArrayList rowPlus = new ArrayList();
            ArrayList colMinus = new ArrayList();
            ArrayList colPlus = new ArrayList();

            while (positionCol != moveToCol && positionRow == moveToRow)
            {

                
                tempRow = positionRow;
                positionCol--;


                while (boardspaces[tempRow, positionCol].isMoveOption == false && test == false)
                {
                    if (boardspaces[--tempRow, positionCol].isMoveOption == false)
                    {
                    }
                    else
                    {
                        rowMinus.Add(tempRow);
                        colMinus.Add(positionCol);
                        holdtempRowMinusResult = tempRow;
                        tempRow = positionRow;
                        if (positionCol != moveToCol && positionRow == moveToRow)
                        {
                        }
                        else
                        {
                            test = true;
                        }
                    }

                }
                test = false;
                while (boardspaces[tempRow, positionCol].isMoveOption == false && test == false)
                {
                    if (boardspaces[++tempRow, positionCol].isMoveOption == false)
                    {
                        
                    }
                    else
                    {
                        tempRowPlus++;
                        holdtempRowPlusResult = tempRow;
                        rowPlus.Add(tempRow);
                        colPlus.Add(positionCol);
                        if (positionCol != moveToCol && positionRow == moveToRow)
                        {
                        }
                        else
                        {
                            test = true;
                        }

                    }

                }
                if (tempRowPlus >= tempRowMinus && test == true)
                {
                    tempRow = holdtempRowMinusResult;
                    rowPlot.Add(rowMinus);
                    colPlot.Add(colMinus);
                }
                else if (tempRowPlus < tempRowMinus && test == true)
                {
                    tempRow = holdtempRowPlusResult;
                    rowPlot.Add(rowPlus);
                    colPlot.Add(colPlus);
                }
                else
                {
                    rowPlot.Add(tempRow);
                    colPlot.Add(positionCol);
                }
                test = false;
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
            bool test = false;
            int tempColMinus = 0;
            int tempColPlus = 0;
            int holdtempColMinusResult = 0;
            int holdtempColPlusResult = 0;
            int tempCol = positionCol;
            colPlot.Add(tempCol);
            ArrayList colMinus = new ArrayList();
            ArrayList colPlus = new ArrayList();
            ArrayList rowMinus = new ArrayList();
            ArrayList rowPlus = new ArrayList();
            
            while (positionCol == moveToCol && positionRow != moveToRow)
            {
                
                
                tempCol = positionCol;
                positionRow++;

                while (boardspaces[positionRow, tempCol].isMoveOption == false && test == false)
                {
                    if (boardspaces[positionRow, --tempCol].isMoveOption == false)
                    {
                        
                    }
                    else
                    {
                        tempColMinus++;
                        holdtempColMinusResult = tempCol;
                        colMinus.Add(tempCol);
                        rowMinus.Add(positionRow);
                        tempCol = positionCol;
                        if (positionCol == moveToCol && positionRow != moveToRow)
                        { }
                        else
                        {
                            test = true;
                        }
                    }

                }
                test = false;
                while (boardspaces[positionRow, tempCol].isMoveOption == false && test == false)
                {
                    if (boardspaces[positionRow, ++tempCol].isMoveOption == false)
                    {
                    }
                    else
                    {

                        holdtempColPlusResult = tempCol;
                        tempColPlus++;
                        colPlus.Add(tempCol);
                        rowPlus.Add(positionRow);
                        if (positionCol == moveToCol && positionRow != moveToRow)
                        { }
                        else
                        {
                            test = true;
                        }

                    }

                }
                if (tempColPlus >= tempColMinus && test == true)
                {
                    tempCol = holdtempColMinusResult;
                    colPlot.Add(colMinus);
                    rowPlot.Add(rowMinus);
                }
                else if (tempColPlus < tempColMinus && test == true)
                {
                    tempCol = holdtempColPlusResult;
                    colPlot.Add(colPlus);
                    rowPlot.Add(rowPlus);
                }
                else
                {
                    colPlot.Add(tempCol);
                    rowPlot.Add(positionRow);
                }
                test = false;
                
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
            bool test = false;
            int tempColMinus = 0;
            int tempColPlus = 0;
            int holdtempColMinusResult = 0;
            int holdtempColPlusResult = 0;
            int tempCol = positionCol;
            colPlot.Add(tempCol);
            ArrayList colMinus = new ArrayList();
            ArrayList colPlus = new ArrayList();
            ArrayList rowMinus = new ArrayList();
            ArrayList rowPlus = new ArrayList();
            
            while (positionCol == moveToCol && positionRow != moveToRow)
            {
                
                
                tempCol = positionCol;
                positionRow--;
                
                 while (boardspaces[positionRow, tempCol].isMoveOption == false && test == false)
                {
                    if (boardspaces[positionRow, --tempCol].isMoveOption == false)
                    {
                        
                    }
                    else
                    {
                        tempColMinus++;
                        holdtempColMinusResult = tempCol;
                        colMinus.Add(tempCol);
                        rowMinus.Add(positionRow);
                        tempCol = positionCol;

                        if (positionCol == moveToCol && positionRow != moveToRow)
                        {
                        }
                        else
                        {
                            test = true;
                        }
                    }

                }
                test = false;
                while (boardspaces[positionRow, tempCol].isMoveOption == false && test == false)
                {
                    if (boardspaces[positionRow, ++tempCol].isMoveOption == false)
                    {
                        
                    }
                    else
                    {
                        tempColPlus++;
                        holdtempColPlusResult = tempCol;
                        colPlus.Add(tempCol);
                        rowPlus.Add(positionRow);
                        if (positionCol == moveToCol && positionRow != moveToRow)
                        {
                        }
                        else
                        {
                            test = true;
                        }

                    }

                }
                if (tempColPlus >= tempColMinus && test == true)
                {
                    tempCol = holdtempColMinusResult;
                    colPlot.Add(colMinus);
                    rowPlot.Add(rowMinus);

                }
                else if (tempColPlus < tempColMinus && test == true)
                {
                    tempCol = holdtempColPlusResult;
                    colPlot.Add(colPlus);
                    rowPlot.Add(rowPlus);
                }
                else
                {
                    colPlot.Add(tempCol);
                    rowPlot.Add(positionRow);
                }
                test = false;
                
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
            bool test = false;
            int tempColMinus = 0;
            int tempColPlus = 0;
            int holdtempColMinusResult = 0;
            int holdtempColPlusResult = 0;
            int tempCol = positionCol;
            int tempRow = positionRow;
            bool goingRight = false;
            ArrayList colMinus = new ArrayList();
            ArrayList colPlus = new ArrayList();
            ArrayList rowMinus = new ArrayList();
            ArrayList rowPlus = new ArrayList();
            while (positionCol != moveToCol && positionRow != moveToRow)
            {
               
                    if ((boardspaces[++tempRow, ++tempCol].isMoveOption == false) && test == false)
                    {
                        holdtempColMinusResult = tempCol;
                        while (boardspaces[tempRow, ++tempCol].isMoveOption == false)
                        {
                            tempColPlus++;
                            colPlus.Add(tempCol);
                            rowPlus.Add(tempRow - 1);
                            
                        }
                        if(boardspaces[tempRow, ++tempCol].isMoveOption == true)
                        {

                            colPlus.Add(tempCol);
                            rowPlus.Add(tempRow);
                        }
                        while (boardspaces[tempRow, ++tempCol].isMoveOption == false)
                        {
                            tempColMinus++;
                            colMinus.Add(tempCol);
                            rowMinus.Add(tempRow - 1);

                        }
                        if (boardspaces[tempRow, --tempCol].isMoveOption == true)
                        {

                            colMinus.Add(tempCol);
                            rowMinus.Add(tempRow);
                        }

                    }
                    else
                    {
                        positionRow += 1;
                        positionCol += 1;
                        tempCol = positionCol;
                        tempRow = positionRow;
                        rowPlot.Add(tempRow);
                        colPlot.Add(tempCol);
                    } 
                if((positionCol != moveToCol && positionRow != moveToRow) == false)
                {
                    test = true;
                }
            }
            if (tempColPlus > tempColMinus && test == true)
            {
                for (int i = 0; i < colMinus.Count; i++)
                {
                    colPlot.Add((int)colMinus[i]);
                    rowPlot.Add((int)rowMinus[i]);
                }

            }
            else if((tempColPlus < tempColMinus) && test == true )
            {
                for (int i = 0; i < colPlus.Count; i++)
                {
                    colPlot.Add((int)colPlus[i]);
                    rowPlot.Add((int)rowPlus[i]);
                }
                test = false;
                while (positionCol != moveToCol && positionRow != moveToRow)
                {

                    if ((boardspaces[++tempRow, --tempCol].isMoveOption == false) && test == false)
                    {
                        holdtempColMinusResult = tempCol;
                        while (boardspaces[tempRow, ++tempCol].isMoveOption == false)
                        {
                            tempColPlus++;
                            colPlus.Add(tempCol);
                            rowPlus.Add(tempRow - 1);

                        }
                        if (boardspaces[tempRow, ++tempCol].isMoveOption == true)
                        {

                            colPlus.Add(tempCol);
                            rowPlus.Add(tempRow);
                        }
                        while (boardspaces[tempRow, --tempCol].isMoveOption == false)
                        {
                            tempColMinus++;
                            colMinus.Add(tempCol);
                            rowMinus.Add(tempRow - 1);

                        }
                        if (boardspaces[tempRow, --tempCol].isMoveOption == true)
                        {

                            colMinus.Add(tempCol);
                            rowMinus.Add(tempRow);
                        }

                    }
                    else
                    {
                        positionRow += 1;
                        positionCol -= 1;
                        tempCol = positionCol;
                        tempRow = positionRow;
                        rowPlot.Add(tempRow);
                        colPlot.Add(tempCol);
                    }
                    if ((positionCol != moveToCol && positionRow != moveToRow) == false)
                    {
                        test = true;
                    }
                }
                if ((tempColPlus > tempColMinus) && test == true )
                {
                    for (int i = 0; i < colMinus.Count; i++)
                    {
                        colPlot.Add((int)colMinus[i]);
                        rowPlot.Add((int)rowMinus[i]);
                    }

                }
                else if ((tempColPlus < tempColMinus) && test == true)
                {
                    for (int i = 0; i < colPlus.Count; i++)
                    {
                        colPlot.Add((int)colPlus[i]);
                        rowPlot.Add((int)rowPlus[i]);
                    }

                }
                else
                {
                    colPlot.Add(tempCol);
                    rowPlot.Add(tempRow);

                }
            }
            else
            {
                colPlot.Add(tempCol);
                rowPlot.Add(tempRow);
            }
            colMinus.Clear();
            colPlus.Clear();
            rowMinus.Clear();
            rowPlus.Clear();
            tempColMinus = 0;
            tempColPlus = 0;
            int tempRowMinus = 0;
            int tempRowPlus = 0;
            int holdtempRowMinusResult = 0;
            int holdtempRowPlusResult = 0;
            rowPlot.Add(tempRow);
            colPlot.Add(tempCol);
            positionCol = tempCol;
            positionRow = tempRow;
            while (positionCol != moveToCol && positionRow == moveToRow)
            {
                goingRight = true;

                tempRow = positionRow;
                positionCol++;

                while (boardspaces[tempRow, positionCol].isMoveOption == false && test == false)
                {
                    if (boardspaces[--tempRow, positionCol].isMoveOption == false)
                    {

                    }
                    else
                    {
                        tempRowMinus++;
                        holdtempRowMinusResult = tempRow;
                        rowMinus.Add(tempRow);
                        colMinus.Add(positionCol);
                        tempRow = positionRow;
                        if (positionCol != moveToCol && positionRow == moveToRow)
                        {
                        }
                        else
                        {
                            test = true;
                        }
                    }

                }
                test = false;
                while (boardspaces[tempRow, positionCol].isMoveOption == false && test == false)
                {
                    if (boardspaces[++tempRow, positionCol].isMoveOption == false)
                    {

                    }
                    else
                    {
                        tempRowPlus++;
                        holdtempRowPlusResult = tempRow;
                        rowPlus.Add(tempRow);
                        colPlus.Add(positionCol);
                        if (positionCol != moveToCol && positionRow == moveToRow)
                        {
                        }
                        else
                        {
                            test = true;
                        }

                    }

                }
                if (tempRowPlus >= tempRowMinus && test == true)
                {
                    tempRow = holdtempRowMinusResult;
                    for (int i = 0; i < colMinus.Count; i++)
                    {
                        rowPlot.Add((int)rowMinus[i]);
                        colPlot.Add((int)colMinus[i]);
                    }

                }
                else if (tempRowPlus < tempRowMinus && test == true)
                {
                    tempRow = holdtempRowPlusResult;
                    for (int i = 0; i < colPlus.Count; i++)
                    {
                        rowPlot.Add((int)rowPlus[i]);
                        colPlot.Add((int)colPlus[i]);
                    }
                }
                else
                {
                    rowPlot.Add(tempRow);
                    colPlot.Add(positionCol);
                }
                test = false;

            }
            if (positionCol == moveToCol && positionRow == moveToRow)
            {

                rowPlot.Add(positionRow);
                colPlot.Add(positionCol);
            }
            if (goingRight == true)
            {
                rowPlot.Add(tempRow);
                colPlot.Add(tempCol);
                positionCol = tempCol;
                positionRow = tempRow;
            }
             while (positionCol == moveToCol && positionRow != moveToRow)
            {
                
                
                tempCol = positionCol;
                positionRow++;

                while (boardspaces[positionRow, tempCol].isMoveOption == false && test == false)
                {
                    if (boardspaces[positionRow, --tempCol].isMoveOption == false)
                    {
                        
                    }
                    else
                    {
                        tempColMinus++;
                        holdtempColMinusResult = tempCol;
                        colMinus.Add(tempCol);
                        rowMinus.Add(positionRow);
                        tempCol = positionCol;
                        if (positionCol == moveToCol && positionRow != moveToRow)
                        { }
                        else
                        {
                            test = true;
                        }
                    }

                }
                test = false;
                while (boardspaces[positionRow, tempCol].isMoveOption == false && test == false)
                {
                    if (boardspaces[positionRow, ++tempCol].isMoveOption == false)
                    {
                    }
                    else
                    {

                        holdtempColPlusResult = tempCol;
                        tempColPlus++;
                        colPlus.Add(tempCol);
                        rowPlus.Add(positionRow);
                        if (positionCol == moveToCol && positionRow != moveToRow)
                        { }
                        else
                        {
                            test = true;
                        }

                    }

                }
                if (tempColPlus >= tempColMinus && test == true)
                {
                    tempCol = holdtempColMinusResult;
                    for (int i = 0; i < colMinus.Count; i++)
                    {
                        colPlot.Add((int)colMinus[i]);
                        rowPlot.Add((int)rowMinus[i]);
                    }
                }
                else if (tempColPlus < tempColMinus && test == true)
                {
                    tempCol = holdtempColPlusResult;
                    for (int i = 0; i < colPlus.Count; i++)
                    {
                        colPlot.Add((int)colPlus[i]);
                        rowPlot.Add((int)rowPlus[i]);
                    }
                }
                else
                {
                    
                      colPlot.Add(tempCol);
                      rowPlot.Add(positionRow);
                }
                test = false;
                
            }        
           if (positionCol == moveToCol && positionRow == moveToRow)
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
            bool test = false;
            int tempColMinus = 0;
            int tempColPlus = 0;
            int holdtempColMinusResult = 0;
            int holdtempColPlusResult = 0;
            int tempCol = positionCol;
            int tempRow = positionRow;
            bool goingRight = false;
            ArrayList colMinus = new ArrayList();
            ArrayList colPlus = new ArrayList();
            ArrayList rowMinus = new ArrayList();
            ArrayList rowPlus = new ArrayList();
            while (positionCol != moveToCol && positionRow != moveToRow)
            {

                if ((boardspaces[--tempRow, ++tempCol].isMoveOption == false) && test == false)
                {
                    holdtempColMinusResult = tempCol;
                    while (boardspaces[tempRow, ++tempCol].isMoveOption == false)
                    {
                        tempColPlus++;
                        colPlus.Add(tempCol);
                        rowPlus.Add(tempRow - 1);

                    }
                    if (boardspaces[tempRow, ++tempCol].isMoveOption == true)
                    {

                        colPlus.Add(tempCol);
                        rowPlus.Add(tempRow);
                    }
                    while (boardspaces[tempRow, --tempCol].isMoveOption == false)
                    {
                        tempColMinus++;
                        colMinus.Add(tempCol);
                        rowMinus.Add(tempRow - 1);

                    }
                    if (boardspaces[tempRow, --tempCol].isMoveOption == true)
                    {

                        colMinus.Add(tempCol);
                        rowMinus.Add(tempRow);
                    }

                }
                else
                {
                    positionRow -= 1;
                    positionCol += 1;
                    tempCol = positionCol;
                    tempRow = positionRow;
                    rowPlot.Add(tempRow);
                    colPlot.Add(tempCol);
                }
                if ((positionCol != moveToCol && positionRow != moveToRow) == false)
                {
                    test = true;
                }
            }
            if (tempColPlus > tempColMinus && test == true)
            {
                for (int i = 0; i < colMinus.Count; i++)
                {
                    colPlot.Add((int)colMinus[i]);
                    rowPlot.Add((int)rowMinus[i]);
                }

            }
            else if ((tempColPlus < tempColMinus) && test == true)
            {
                for (int i = 0; i < colPlus.Count; i++)
                {
                    colPlot.Add((int)colPlus[i]);
                    rowPlot.Add((int)rowPlus[i]);
                }
                test = false;
                while (positionCol != moveToCol && positionRow != moveToRow)
                {

                    if ((boardspaces[--tempRow, --tempCol].isMoveOption == false) && test == false)
                    {
                        holdtempColMinusResult = tempCol;
                        while (boardspaces[tempRow, ++tempCol].isMoveOption == false)
                        {
                            tempColPlus++;
                            colPlus.Add(tempCol);
                            rowPlus.Add(tempRow - 1);

                        }
                        if (boardspaces[tempRow, ++tempCol].isMoveOption == true)
                        {

                            colPlus.Add(tempCol);
                            rowPlus.Add(tempRow);
                        }
                        while (boardspaces[tempRow, --tempCol].isMoveOption == false)
                        {
                            tempColMinus++;
                            colMinus.Add(tempCol);
                            rowMinus.Add(tempRow - 1);

                        }
                        if (boardspaces[tempRow, --tempCol].isMoveOption == true)
                        {

                            colMinus.Add(tempCol);
                            rowMinus.Add(tempRow);
                        }

                    }
                    else
                    {
                        positionRow -= 1;
                        positionCol -= 1;
                        tempCol = positionCol;
                        tempRow = positionRow;
                        rowPlot.Add(tempRow);
                        colPlot.Add(tempCol);
                    }
                    if ((positionCol != moveToCol && positionRow != moveToRow) == false)
                    {
                        test = true;
                    }
                }
                if ((tempColPlus > tempColMinus) && test == true)
                {
                    for (int i = 0; i < colMinus.Count; i++)
                    {
                        colPlot.Add((int)colMinus[i]);
                        rowPlot.Add((int)rowMinus[i]);
                    }

                }
                else if ((tempColPlus < tempColMinus) && test == true)
                {
                    for (int i = 0; i < colPlus.Count; i++)
                    {
                        colPlot.Add((int)colPlus[i]);
                        rowPlot.Add((int)rowPlus[i]);
                    }

                }
                else
                {
                    colPlot.Add(tempCol);
                    rowPlot.Add(tempRow);

                }
            }
            else
            {
                colPlot.Add(tempCol);
                rowPlot.Add(tempRow);
            }
            colMinus.Clear();
            colPlus.Clear();
            rowMinus.Clear();
            rowPlus.Clear();
            tempColMinus = 0;
            tempColPlus = 0;
            int tempRowMinus = 0;
            int tempRowPlus = 0;
            int holdtempRowMinusResult = 0;
            int holdtempRowPlusResult = 0;
            rowPlot.Add(tempRow);
            colPlot.Add(tempCol);
            positionCol = tempCol;
            positionRow = tempRow;
            while (positionCol != moveToCol && positionRow == moveToRow)
            {
                goingRight = true;

                tempRow = positionRow;
                positionCol++;

                while (boardspaces[tempRow, positionCol].isMoveOption == false && test == false)
                {
                    if (boardspaces[--tempRow, positionCol].isMoveOption == false)
                    {

                    }
                    else
                    {
                        tempRowMinus++;
                        holdtempRowMinusResult = tempRow;
                        rowMinus.Add(tempRow);
                        colMinus.Add(positionCol);
                        tempRow = positionRow;
                        if (positionCol != moveToCol && positionRow == moveToRow)
                        {
                        }
                        else
                        {
                            test = true;
                        }
                    }

                }
                test = false;
                while (boardspaces[tempRow, positionCol].isMoveOption == false && test == false)
                {
                    if (boardspaces[++tempRow, positionCol].isMoveOption == false)
                    {

                    }
                    else
                    {
                        tempRowPlus++;
                        holdtempRowPlusResult = tempRow;
                        rowPlus.Add(tempRow);
                        colPlus.Add(positionCol);
                        if (positionCol != moveToCol && positionRow == moveToRow)
                        {
                        }
                        else
                        {
                            test = true;
                        }

                    }

                }
                if (tempRowPlus >= tempRowMinus && test == true)
                {
                    tempRow = holdtempRowMinusResult;
                    for (int i = 0; i < colMinus.Count; i++)
                    {
                        rowPlot.Add((int)rowMinus[i]);
                        colPlot.Add((int)colMinus[i]);
                    }

                }
                else if (tempRowPlus < tempRowMinus && test == true)
                {
                    tempRow = holdtempRowPlusResult;
                    for (int i = 0; i < colPlus.Count; i++)
                    {
                        rowPlot.Add((int)rowPlus[i]);
                        colPlot.Add((int)colPlus[i]);
                    }
                }
                else
                {
                    rowPlot.Add(tempRow);
                    colPlot.Add(positionCol);
                }
                test = false;

            }
            if (positionCol == moveToCol && positionRow == moveToRow)
            {

                rowPlot.Add(positionRow);
                colPlot.Add(positionCol);
            }
            if (goingRight == true)
            {
                rowPlot.Add(tempRow);
                colPlot.Add(tempCol);
                positionCol = tempCol;
                positionRow = tempRow;
            }
            while (positionCol == moveToCol && positionRow != moveToRow)
            {


                tempCol = positionCol;
                positionRow++;

                while (boardspaces[positionRow, tempCol].isMoveOption == false && test == false)
                {
                    if (boardspaces[positionRow, --tempCol].isMoveOption == false)
                    {

                    }
                    else
                    {
                        tempColMinus++;
                        holdtempColMinusResult = tempCol;
                        colMinus.Add(tempCol);
                        rowMinus.Add(positionRow);
                        tempCol = positionCol;
                        if (positionCol == moveToCol && positionRow != moveToRow)
                        { }
                        else
                        {
                            test = true;
                        }
                    }

                }
                test = false;
                while (boardspaces[positionRow, tempCol].isMoveOption == false && test == false)
                {
                    if (boardspaces[positionRow, ++tempCol].isMoveOption == false)
                    {
                    }
                    else
                    {

                        holdtempColPlusResult = tempCol;
                        tempColPlus++;
                        colPlus.Add(tempCol);
                        rowPlus.Add(positionRow);
                        if (positionCol == moveToCol && positionRow != moveToRow)
                        { }
                        else
                        {
                            test = true;
                        }

                    }

                }
                if (tempColPlus >= tempColMinus && test == true)
                {
                    tempCol = holdtempColMinusResult;
                    for (int i = 0; i < colMinus.Count; i++)
                    {
                        colPlot.Add((int)colMinus[i]);
                        rowPlot.Add((int)rowMinus[i]);
                    }
                }
                else if (tempColPlus < tempColMinus && test == true)
                {
                    tempCol = holdtempColPlusResult;
                    for (int i = 0; i < colPlus.Count; i++)
                    {
                        colPlot.Add((int)colPlus[i]);
                        rowPlot.Add((int)rowPlus[i]);
                    }
                }
                else
                {

                    colPlot.Add(tempCol);
                    rowPlot.Add(positionRow);
                }
                test = false;

            }
            if (positionCol == moveToCol && positionRow == moveToRow)
            {

                rowPlot.Add(positionRow);
                colPlot.Add(positionCol);
            }            
           
        }
        /// <summary>
        /// /////////case 6
        /// </summary>
        public void positionCol_MoreEqual_moveToCol_And_positionRow_MoreEqual_MovetoRow()
        {
            bool notContinuePlus = false;
            bool notContinueMinus = false;
            bool test = false;
            int tempColMinus = 0;
            int tempColPlus =  0;
            int holdtempCol = 0;
            int holdtempRow = 0;
            int tempCol = positionCol;
            int tempRow = positionRow;
            bool goingRight = false;
            ArrayList colMinus = new ArrayList();
            ArrayList colPlus = new ArrayList();
            ArrayList rowMinus = new ArrayList();
            ArrayList rowPlus = new ArrayList();
            while (positionCol != moveToCol && positionRow != moveToRow)
            {
                --tempRow;
                --tempCol;
                 
                if ((boardspaces[tempRow, tempCol].isMoveOption == false) && test == false)
                {
                    holdtempCol = tempCol;
                    holdtempRow = tempRow;
                    
                    do
                    {
                        ++tempCol;
                        if (boardspaces[tempRow, tempCol].isMoveOption == true)
                        {
                            tempColPlus++;
                            colPlus.Add(tempCol);
                            rowPlus.Add(tempRow);

                            break;
                        }
                        
                        if (boardspaces[tempRow, tempCol + 1].isMoveOption == true)
                        {
                            tempColPlus++;
                            colPlus.Add(tempCol += 1);
                            rowPlus.Add(tempRow);
                            break;
                        }
                        if (boardspaces[tempRow + 1, tempCol].isMoveOption == true)
                        {
                            tempColPlus++;
                            colPlus.Add(tempCol);
                            rowPlus.Add(tempRow +=1);
                            

                        }
                        else
                        {
                            tempColPlus++;
                            if (boardspaces[tempRow + 2, tempCol].isMoveOption == true)
                            {
                                rowPlus.Add(tempRow += 2);
                                colPlus.Add(tempCol);
                                tempColPlus++;
                            }
                            else
                            {
                                tempColPlus++;
                                if (boardspaces[tempRow + 2, tempCol - 1].isMoveOption == true)
                                {
                                    rowPlus.Add(tempRow += 2);
                                    colPlus.Add(tempCol -=1);
                                    tempColPlus++;

                                }
                                else
                                {
                                    
                                    break;
                                }
                            }
                        }

                    } while (boardspaces[tempRow, ++tempCol].isMoveOption == false) ;
                    tempRow = holdtempRow;
                    tempCol = holdtempCol;
                    
                    try
                    {
                        while (boardspaces[tempRow, --tempCol].isMoveOption == false && notContinueMinus == false)
                        {
                            tempColMinus++;
                            if (boardspaces[tempRow, tempCol].isMoveOption == true)
                            {
                                if (boardspaces[tempRow + 1, tempCol + 1].isMoveOption == true)
                                {
                                    colMinus.Add(tempCol + 1);
                                    rowMinus.Add(tempRow + 1);
                                    colMinus.Add(tempCol);
                                    rowMinus.Add(tempRow);
                                    break;

                                }
                                else
                                {
                                    tempColMinus++;
                                    if (boardspaces[tempRow + 2, tempCol + 1].isMoveOption == true)
                                    {
                                        colMinus.Add(tempCol += 1);
                                        rowMinus.Add(tempRow += 2);

                                    }
                                    else
                                    {
                                        tempColMinus++;
                                        if (boardspaces[tempRow + 2, tempCol + 2].isMoveOption == true)
                                        {
                                            colMinus.Add(tempCol += 2);
                                            rowMinus.Add(tempRow += 2);
                                        }
                                        else
                                        {
                                            notContinueMinus = true;
                                            break;
                                        }
                                    }
                                }

                            }
                            else
                            {
                                tempColMinus++;
                                if (boardspaces[tempRow + 1, tempCol + 1].isMoveOption == true)
                                {
                                    colMinus.Add(tempCol += 1);
                                    rowMinus.Add(tempRow += 1);

                                }
                                else
                                {
                                    tempColMinus++;
                                    if (boardspaces[tempRow + 2, tempCol + 1].isMoveOption == true)
                                    {
                                        colMinus.Add(tempCol += 1);
                                        rowMinus.Add(tempRow += 2);

                                    }
                                    else
                                    {
                                        tempColMinus++;
                                        if (boardspaces[tempRow + 2, tempCol + 2].isMoveOption == true)
                                        {
                                            colMinus.Add(tempCol += 2);
                                            rowMinus.Add(tempRow += 2);

                                        }
                                        else
                                        {
                                            notContinueMinus = true;
                                            break;
                                        }

                                    }

                                }
                            }

                        }
                    }
                    catch
                    {
                        notContinueMinus = true;
                        
                    }
                    if (colPlus.Count > colMinus.Count)
                    {
                        if (colMinus.Count == 0)
                        {
                            holdtempRow = tempRow = (int)rowPlus[colPlus.Count - 1];
                            holdtempCol = tempCol = (int)colPlus[colPlus.Count - 1];
                            Store(rowPlus, colPlus);
                        }
                        else
                        {
                           holdtempRow = tempRow = (int)rowMinus[colMinus.Count - 1];
                           holdtempCol = tempCol = (int)colMinus[colMinus.Count - 1];
                           Store(rowMinus, colMinus);
                        }
                    }
                    else if(colPlus.Count < colMinus.Count)
                    {
                        if (colPlus.Count == 0)
                        {
                            holdtempRow = tempRow = (int)rowMinus[colMinus.Count - 1];
                            holdtempCol = tempCol = (int)colMinus[colMinus.Count - 1];
                            Store(rowMinus, colMinus);
                        }
                        else
                        {
                            holdtempRow = tempRow = (int)rowPlus[colPlus.Count - 1];
                            holdtempCol = tempCol = (int)colPlus[colPlus.Count - 1];
                            Store(rowPlus, colPlus);
                        }

                    }
                    else
                    {
                        if ((int)rowPlus[rowPlus.Count - 1] < (int)rowMinus[rowMinus.Count - 1])
                        {
                            holdtempRow = tempRow = (int)rowPlus[colPlus.Count - 1];
                            holdtempCol = tempCol = (int)colPlus[colPlus.Count - 1];
                            Store(rowPlus, colPlus);

                        }
                        else if(((int)rowPlus[rowPlus.Count - 1] > (int)rowMinus[rowMinus.Count - 1]))
                        {
                            holdtempRow = tempRow = (int)rowMinus[colMinus.Count - 1];
                            holdtempCol = tempCol = (int)colMinus[colMinus.Count - 1];
                            Store(rowMinus, colMinus);
                        }
                        else
                        {
                            holdtempRow = tempRow = (int)rowMinus[colMinus.Count - 1];
                            holdtempCol = tempCol = (int)colMinus[colMinus.Count - 1];
                            Store(rowMinus, colMinus);

                        }
                        
                        

                    }
                    

                }
                else
                {
                   
                   
                    rowPlot.Add(tempRow);
                    colPlot.Add(tempCol);
                }

                
                if ((positionCol != moveToCol && positionRow != moveToRow) == false)
                {
                    test = true;
                }
            }
            if (tempColPlus > tempColMinus && test == true )
            {
                if (tempColMinus == 0)
                {
                    for (int i = 0; i < colPlus.Count; i++)
                    {
                        colPlot.Add((int)colPlus[i]);
                        rowPlot.Add((int)rowPlus[i]);
                    }
                }
                for (int i = 0; i < colMinus.Count; i++)
                {
                    colPlot.Add((int)colMinus[i]);
                    rowPlot.Add((int)rowMinus[i]);
                }

            }
            else if ((tempColPlus < tempColMinus) && test == true)
            {
                if (tempColPlus == 0)
                {
                    for (int i = 0; i < colMinus.Count; i++)
                    {
                        colPlot.Add((int)colMinus[i]);
                        rowPlot.Add((int)rowMinus[i]);
                    }

                }
                for (int i = 0; i < colPlus.Count; i++)
                {
                    colPlot.Add((int)colPlus[i]);
                    rowPlot.Add((int)rowPlus[i]);
                }
                test = false;
                while (positionCol != moveToCol && positionRow != moveToRow)
                {

                    if ((boardspaces[--tempRow, ++tempCol].isMoveOption == false) && test == false)
                    {
                        holdtempCol = tempCol;
                        while (boardspaces[tempRow, ++tempCol].isMoveOption == false)
                        {
                            tempColPlus++;
                            colPlus.Add(tempCol);
                            rowPlus.Add(tempRow - 1);

                        }
                        if (boardspaces[tempRow, ++tempCol].isMoveOption == true)
                        {

                            colPlus.Add(tempCol);
                            rowPlus.Add(tempRow);
                        }
                        while (boardspaces[tempRow, ++tempCol].isMoveOption == false)
                        {
                            tempColMinus++;
                            colMinus.Add(tempCol);
                            rowMinus.Add(tempRow - 1);

                        }
                        if (boardspaces[tempRow, --tempCol].isMoveOption == true)
                        {

                            colMinus.Add(tempCol);
                            rowMinus.Add(tempRow);
                        }

                    }
                    else
                    {
                        positionRow -= 1;
                        positionCol += 1;
                        tempCol = positionCol;
                        tempRow = positionRow;
                        rowPlot.Add(tempRow);
                        colPlot.Add(tempCol);
                    }
                    if ((positionCol != moveToCol && positionRow != moveToRow) == false)
                    {
                        test = true;
                    }
                }
                if ((tempColPlus > tempColMinus) && test == true)
                {
                    for (int i = 0; i < colMinus.Count; i++)
                    {
                        colPlot.Add((int)colMinus[i]);
                        rowPlot.Add((int)rowMinus[i]);
                    }

                }
                else if ((tempColPlus < tempColMinus) && test == true)
                {
                    for (int i = 0; i < colPlus.Count; i++)
                    {
                        colPlot.Add((int)colPlus[i]);
                        rowPlot.Add((int)rowPlus[i]);
                    }

                }
                else
                {
                    colPlot.Add(tempCol);
                    rowPlot.Add(tempRow);

                }
            }
            else
            {
                colPlot.Add(tempCol);
                rowPlot.Add(tempRow);
            }
            colMinus.Clear();
            colPlus.Clear();
            rowMinus.Clear();
            rowPlus.Clear();
            tempColMinus = 0;
            tempColPlus = 0;
            int tempRowMinus = 0;
            int tempRowPlus = 0;
            int holdtempRowMinusResult = 0;
            int holdtempRowPlusResult = 0;
            rowPlot.Add(tempRow);
            colPlot.Add(tempCol);
            positionCol = tempCol;
            positionRow = tempRow;
            while (positionCol != moveToCol && positionRow == moveToRow)
            {
                goingRight = true;

                tempRow = positionRow;
                positionCol++;

                while (boardspaces[tempRow, positionCol].isMoveOption == false && test == false)
                {
                    if (boardspaces[--tempRow, positionCol].isMoveOption == false)
                    {

                    }
                    else
                    {
                        tempRowMinus++;
                        holdtempRowMinusResult = tempRow;
                        rowMinus.Add(tempRow);
                        colMinus.Add(positionCol);
                        tempRow = positionRow;
                        if (positionCol != moveToCol && positionRow == moveToRow)
                        {
                        }
                        else
                        {
                            test = true;
                        }
                    }

                }
                test = false;
                while (boardspaces[tempRow, positionCol].isMoveOption == false && test == false)
                {
                    if (boardspaces[++tempRow, positionCol].isMoveOption == false)
                    {

                    }
                    else
                    {
                        tempRowPlus++;
                        holdtempRowPlusResult = tempRow;
                        rowPlus.Add(tempRow);
                        colPlus.Add(positionCol);
                        if (positionCol != moveToCol && positionRow == moveToRow)
                        {
                        }
                        else
                        {
                            test = true;
                        }

                    }

                }
                if (tempRowPlus >= tempRowMinus && test == true)
                {
                    tempRow = holdtempRowMinusResult;
                    for (int i = 0; i < colMinus.Count; i++)
                    {
                        rowPlot.Add((int)rowMinus[i]);
                        colPlot.Add((int)colMinus[i]);
                    }

                }
                else if (tempRowPlus < tempRowMinus && test == true)
                {
                    tempRow = holdtempRowPlusResult;
                    for (int i = 0; i < colPlus.Count; i++)
                    {
                        rowPlot.Add((int)rowPlus[i]);
                        colPlot.Add((int)colPlus[i]);
                    }
                }
                else
                {
                    rowPlot.Add(tempRow);
                    colPlot.Add(positionCol);
                }
                test = false;

            }
            if (positionCol == moveToCol && positionRow == moveToRow)
            {

                rowPlot.Add(positionRow);
                colPlot.Add(positionCol);
            }
            if (goingRight == true)
            {
                rowPlot.Add(tempRow);
                colPlot.Add(tempCol);
                positionCol = tempCol;
                positionRow = tempRow;
            }
            while (positionCol == moveToCol && positionRow != moveToRow)
            {


                tempCol = positionCol;
                positionRow--;

                while (boardspaces[positionRow, tempCol].isMoveOption == false && test == false)
                {
                    if (boardspaces[positionRow, --tempCol].isMoveOption == false)
                    {

                    }
                    else
                    {
                        tempColMinus++;
                        holdtempCol = tempCol;
                        colMinus.Add(tempCol);
                        rowMinus.Add(positionRow);
                        tempCol = positionCol;
                        if (positionCol == moveToCol && positionRow != moveToRow)
                        { }
                        else
                        {
                            test = true;
                        }
                    }

                }
                test = false;
                while (boardspaces[positionRow, tempCol].isMoveOption == false && test == false)
                {
                    if (boardspaces[positionRow, ++tempCol].isMoveOption == false)
                    {
                    }
                    else
                    {

                        holdtempCol = tempCol;
                        tempColPlus++;
                        colPlus.Add(tempCol);
                        rowPlus.Add(positionRow);
                        if (positionCol == moveToCol && positionRow != moveToRow)
                        { }
                        else
                        {
                            test = true;
                        }

                    }

                }
                if (tempColPlus >= tempColMinus && test == true)
                {
                    tempCol = holdtempCol;
                    for (int i = 0; i < colMinus.Count; i++)
                    {
                        colPlot.Add((int)colMinus[i]);
                        rowPlot.Add((int)rowMinus[i]);
                    }
                }
                else if (tempColPlus < tempColMinus && test == true)
                {
                    tempCol = holdtempCol;
                    for (int i = 0; i < colPlus.Count; i++)
                    {
                        colPlot.Add((int)colPlus[i]);
                        rowPlot.Add((int)rowPlus[i]);
                    }
                }
                else
                {

                    colPlot.Add(tempCol);
                    rowPlot.Add(positionRow);
                }
                test = false;

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
                
                    if (boardspaces[positionRow + 1, positionCol - 1].isMoveOption == false)
                    {
                        if (boardspaces[positionRow, positionCol - 1].isMoveOption == false)
                        {
                            if (boardspaces[positionRow + 1, positionCol].isMoveOption == false)
                            {
                            }
                            else
                            {
                                rowPlot.Add(positionRow += 1);
                                colPlot.Add(positionCol);
                            }
                        }
                        else
                        {

                            colPlot.Add(positionCol -= 1);
                            rowPlot.Add(positionRow);
                        }

                    }
                    else
                    {
                        rowPlot.Add(positionRow += 1);
                        colPlot.Add(positionCol -= 1);
                    }                    
             }            
            int tempRow = positionRow;
            while (positionCol != moveToCol && positionRow == moveToRow)
            {
                rowPlot.Add(tempRow);
                colPlot.Add(positionCol);
                tempRow = positionRow;
                positionCol--;                            
                
                
                    if (boardspaces[positionRow, positionCol].isMoveOption == false)
                    {
                        if (boardspaces[positionRow + 1, positionCol ].isMoveOption == false)
                        {
                            tempRow -= 1;
                        }
                        else
                        {

                            
                            tempRow +=1;
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
                
                
                
                    if (boardspaces[positionRow, positionCol].isMoveOption == false)
                    {
                        if (boardspaces[positionRow, positionCol - 1].isMoveOption == false)
                        {
                            tempCol += 1;
                        }
                        else
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
            else
            {
                positionCol_MoreEqual_moveToCol_And_positionRow_LessEqual_MovetoRow();
            }



        }
       public void Store(ArrayList RowArray,ArrayList ColArray)
       {
           for (int i = 0; i < ColArray.Count; i++)
           {
               rowPlot.Add((int)RowArray[i]);
               colPlot.Add((int)ColArray[i]);
           }
       }

        
        }

    }

