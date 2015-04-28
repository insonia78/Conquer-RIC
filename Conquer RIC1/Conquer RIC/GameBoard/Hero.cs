//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Media;
//using System.Windows.Media.Imaging;
//using System.Collections;

//namespace GameBoard
//{
//    class Hero : Character
//    {

//        public Hero()
//        {
//            characterPicture = new BitmapImage(new Uri("hero.png", UriKind.Relative));
//        }

//        public Hero(int r, int c, int charspeed) : base(r ,c, charspeed)
//        {
//            characterPicture = new BitmapImage(new Uri("hero.png", UriKind.Relative));
//        }

//        public override int[,] Ability1(int[,] boardspaces)
//        {
//            //TEST ATTACK ONLY, will probably be removed later
//            //up
//            this.selectedAttackPower = 1.0;

//            if(row - 1 >= 0 && boardspaces[row -1, col] != -1)
//            {
//                boardspaces[row - 1, col] = 1;
//                if(row - 2 >= 0 && boardspaces[row - 2, col] != -1)
//                {
//                    boardspaces[row - 2, col] = 1;
//                    if (col - 1 >= 0 && boardspaces[row - 2, col - 1] != -1)
//                        boardspaces[row - 2, col - 1] = 1;
//                    if (col + 1 >= 0 && boardspaces[row - 2, col + 1] != -1)
//                        boardspaces[row - 2, col + 1] = 1;
//                }
//            }
//            //down
//            if (row + 1 < boardspaces.GetLength(0) && boardspaces[row + 1, col] != -1)
//            {
//                boardspaces[row + 1, col] = 2;
//                if (row + 2 < boardspaces.GetLength(0) && boardspaces[row + 2, col] != -1)
//                {
//                    boardspaces[row + 2, col] = 2;
//                    if (col - 1 >= 0 && boardspaces[row + 2, col - 1] != -1)
//                        boardspaces[row + 2, col - 1] = 2;
//                    if (col + 1 < boardspaces.GetLength(1) && boardspaces[row + 2, col + 1] != -1)
//                        boardspaces[row + 2, col + 1] = 2;
//                }
//            }
//            //left
//            if (col - 1 >= 0 && boardspaces[row, col - 1] != -1)
//            {
//                boardspaces[row, col - 1] = 3;
//                if (col - 2 >= 0 && boardspaces[row, col - 2] != -1)
//                {
//                    boardspaces[row, col - 2] = 3;
//                    if (row - 1 >= 0 && boardspaces[row -1, col - 2] != -1)
//                        boardspaces[row -1, col - 2] = 3;
//                    if (row + 1 < boardspaces.GetLength(1) && boardspaces[row + 1, col - 2] != -1)
//                        boardspaces[row + 1, col -2] = 3;
//                }
//            }
//            //right
//            if (col + 1 < boardspaces.GetLength(1) && boardspaces[row, col + 1] != -1)
//            {
//                boardspaces[row, col + 1] = 4;
//                if (col + 2 < boardspaces.GetLength(1) && boardspaces[row, col + 2] != -1)
//                {
//                    boardspaces[row, col + 2] = 4;
//                    if (row - 1 >= 0 && boardspaces[row - 1, col + 2] != -1)
//                        boardspaces[row - 1, col + 2] = 4;
//                    if (row + 1 < boardspaces.GetLength(0) && boardspaces[row + 1, col + 2] != -1)
//                        boardspaces[row + 1, col + 2] = 4;
//                }
//            }
//            return boardspaces;
//        }
//    }
//}

