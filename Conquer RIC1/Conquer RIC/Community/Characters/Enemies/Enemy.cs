﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Community
{
    /**************************************************************************
     * Enemy is contrast to hero. when defeated by heros, the enemy character
     * will give experience points to the part of heros. the amount of 
     * experience points given to the party depend on the job role and level
     * of that enemy character.
     * ************************************************************************
     */
    public class Enemy : Character
    {
        // fields
        private int baseExperienceAmount = 10;      // least experience given.
        private double experienceAmountMulti;      // increase amount depending on enemy type.
        private int maxExperienceAmount;           // amount of experience given for the kill. 
        private int currentExperienceAmount;       // amount of experience given for the kill that can be played with.

        // Constructor.
        public Enemy()
        {
            Init();
        }

        public Enemy(int r, int c) : base(r, c)
        {
            Init();
            row = r;
            col = c;
        }

        public void Init()
        {
            experienceAmountMulti = 1.0;
            statEffects = new List<Effect>();
            maxExperienceAmount = (int)(baseExperienceAmount * experienceAmountMulti);
            currentExperienceAmount = maxExperienceAmount;
        }

        /**********************************************************************
         * Get and sets for the variables.
         **********************************************************************
         */
        // get and set for the baseExperienceAmount variable.
        public int BaseExperienceAmount
        {
            get
            {
                return baseExperienceAmount;
            }
            set
            {
                baseExperienceAmount = value;
            }
        }
        public override int[,] Ability1E(int[,] boardspaces)
        {
            //TEST ATTACK ONLY, will probably be removed later
            //up
            this.selectedAttackPower = 1.0;

            if (row - 1 >= 0 && boardspaces[row - 1, col] == 0)
            {
                boardspaces[row - 1, col] = 1;
                if (row - 2 >= 0 && boardspaces[row - 2, col] == 0)
                {
                    boardspaces[row - 2, col] = 1;
                    if (col - 1 >= 0 && boardspaces[row - 2, col - 1] == 0)
                        boardspaces[row - 2, col - 1] = 1;
                    if (col + 1 >= 0 && boardspaces[row - 2, col + 1] == 0)
                        boardspaces[row - 2, col + 1] = 1;
                }
            }
            //down
            if (row + 1 < boardspaces.GetLength(0) && boardspaces[row + 1, col] == 0)
            {
                boardspaces[row + 1, col] = 2;
                if (row + 2 < boardspaces.GetLength(0) && boardspaces[row + 2, col] == 0)
                {
                    boardspaces[row + 2, col] = 2;
                    if (col - 1 >= 0 && boardspaces[row + 2, col - 1] == 0)
                        boardspaces[row + 2, col - 1] = 2;
                    if (col + 1 < boardspaces.GetLength(1) && boardspaces[row + 2, col + 1] == 0)
                        boardspaces[row + 2, col + 1] = 2;
                }
            }
            //left
            if (col - 1 >= 0 && boardspaces[row, col - 1] == 0)
            {
                boardspaces[row, col - 1] = 3;
                if (col - 2 >= 0 && boardspaces[row, col - 2] == 0)
                {
                    boardspaces[row, col - 2] = 3;
                    if (row - 1 >= 0 && boardspaces[row - 1, col - 2] == 0)
                        boardspaces[row - 1, col - 2] = 3;
                    if (row + 1 < boardspaces.GetLength(1) && boardspaces[row + 1, col - 2] == 0)
                        boardspaces[row + 1, col - 2] = 3;
                }
            }
            //right
            if (col + 1 < boardspaces.GetLength(1) && boardspaces[row, col + 1] == 0)
            {
                boardspaces[row, col + 1] = 4;
                if (col + 2 < boardspaces.GetLength(1) && boardspaces[row, col + 2] == 0)
                {
                    boardspaces[row, col + 2] = 4;
                    if (row - 1 >= 0 && boardspaces[row - 1, col + 2] == 0)
                        boardspaces[row - 1, col + 2] = 4;
                    if (row + 1 < boardspaces.GetLength(0) && boardspaces[row + 1, col + 2] == 0)
                        boardspaces[row + 1, col + 2] = 4;
                }
            }
            return boardspaces;
        }

        // get and set for the experienceAmountMulti variable.
        public double ExperienceAmountMulti
        {
            get
            {
                return experienceAmountMulti;
            }
            set
            {
                experienceAmountMulti = value;
            }
        }

        // get and set for the maxExperienceAmount variable.
        public int MaxExperienceAmount
        {
            get
            {
                return maxExperienceAmount;
            }
            set
            {
                maxExperienceAmount = value;
            }
        }

        // get and set for the currentExperienceAmount variable.
        public int CurrentExperienceAmount
        {
            get
            {
                return currentExperienceAmount;
            }
            set
            {
                currentExperienceAmount = value;
            }
        }

        /**********************************************************************
         * Other methods.
         * ********************************************************************
         */

        // Prints out the variables for testing purposes.
        public String ToString()
        {
            String text;

            text = (
                base.ToString() +
                "\nBase experience amount: " + baseExperienceAmount +
                "\nExperience Amount Multiplier: " + experienceAmountMulti +
                "\nMax Experience Amount: " + maxExperienceAmount +
                "\nCurrent Experience Amount: " + currentExperienceAmount + "\n");

            return text;
        }
    }
}