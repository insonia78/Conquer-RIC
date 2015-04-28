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
//    public class Character : System.Windows.Controls.Button
//    {
//        protected int row;
//        protected int col;
//        protected int health;
//        protected int maxHealth;
//        protected int level;
//        protected int experience;
//        protected int attackStat;
//        protected int specialAttackStat;
//        protected int defenseStat;
//        protected int specialDefenseStat;
//        protected int moveSpeed;
//        protected List<Effect> statEffects;
//        protected String name;
//        protected bool hasMovedOnTurn = false;
//        protected bool hasAttackedOnTurn = false;
//        protected bool hasUsedItemOnTurn = false;
//        protected bool isActiveOnTurn = true;
//        protected double chosenAttackPower = 0.0;
//        protected ImageSource characterPicture;

//        //accessors/mutators
//        public virtual int Col
//        {
//            get { return col; }
//            set { col = value; }
//        }
//        public virtual int Row
//        {
//            get { return row; }
//            set { row = value; }
//        }

//        public ImageSource characterImage
//        {
//            get
//            {
//                return characterPicture;
//            }
//            set { }
//        }

//        public int hp
//        {
//            get
//            {
//                return health;
//            }
//            set
//            {
//                health = value;
//            }
//        }

//        /*
//         * The "base" accessors/mutators for each stat will return the stat without any effects applied to it, the other ones for each stat give the stat
//         * with all effects applied to it, intended for use in actual game calculations where the effect(s) will apply.
//         */
//        public int baseSpeed
//        {
//            get
//            {
//                return moveSpeed;
//            }
//            set { }
//        }

//        public int speed
//        {
//            get
//            {
//                return moveSpeed + sumAllEffects_Speed();
//            }
//            set { }
//        }

//        public int baseAttack
//        {
//            get
//            {
//                return attackStat;
//            }
//            set { }
//        }

//        public int attack
//        {
//            get
//            {
//                return (int)(attackStat * (1 + sumAllEffects_Attack()));
//                //If the sum of the percentages = 0.50, we want to add 50% of the character's attack stat to their base attack, so we need to multiply it by 1.5 (150%).
//            }
//            set { }
//        }

//        public int baseSpecialAttack
//        {
//            get
//            {
//                return specialAttackStat;
//            }
//            set { }
//        }

//        public int specialAttack
//        {
//            get
//            {
//                return (int)(specialAttackStat * (1 + sumAllEffects_SpAttack()));
//            }
//            set { }
//        }

//        public int baseDefense
//        {
//            get
//            {
//                return defenseStat;
//            }
//            set { }
//        }

//        public int defense
//        {
//            get
//            {
//                return (int)(defenseStat * (1 + sumAllEffects_Defense()));
//            }
//            set { }
//        }

//        public int baseSpecialDefense
//        {
//            get
//            {
//                return specialDefenseStat;
//            }
//            set { }
//        }

//        public int specialDefense
//        {
//            get
//            {
//                return (int)(specialDefenseStat * (1 + sumAllEffects_SpDefense()));
//            }
//            set { }
//        }

//        public bool hasMoved
//        {
//            get
//            {
//                return hasMovedOnTurn;
//            }
//            set
//            {
//                hasMovedOnTurn = value;
//            }
//        }
//        public bool hasAttacked
//        {
//            get
//            {
//                return hasAttackedOnTurn;
//            }
//            set
//            {
//                hasAttackedOnTurn = value;
//            }
//        }
//        public bool hasUsedItem
//        {
//            get
//            {
//                return hasUsedItemOnTurn;
//            }
//            set
//            {
//                hasUsedItemOnTurn = value;
//            }
//        }
//        public bool isActive
//        {
//            get
//            {
//                if (hasMovedOnTurn && hasAttackedOnTurn && hasUsedItemOnTurn) //If these three are true, then the character is no longer active, change before returning the value.
//                    isActiveOnTurn = false;
//                return isActiveOnTurn;
//            }
//            set
//            {
//                isActiveOnTurn = value;
//                hasMovedOnTurn = !value;
//                hasUsedItemOnTurn = !value;
//                hasAttackedOnTurn = !value;
//                //If isActiveOnTurn = true, hasMovedOnTurn, etc. = !true = false.
//                //If we want to set isActive = true, then we're making the character completely available for a new turn, so the other variables need to be false
//                //If we're setting isActive to false, we're ending their turn, so the other variables should be true for the purposes of the code, whether actually true or not.
//            }
//        }

//        public double selectedAttackPower
//        {
//            get
//            {
//                return chosenAttackPower;
//            }
//            set
//            {
//                chosenAttackPower = value;
//            }
//        }

//        //Constructor(s)
//        public Character()
//        {
//            row = 0;
//            col = 0;
//            statEffects = new List<Effect>();

//            //Temporary test stats
//            attackStat = 1;
//            specialAttackStat = 1;
//            defenseStat = 1;
//            specialDefenseStat = 1;
//        }

//        public Character(int r, int c, int charSpeed)
//        {
//            row = r;
//            col = c;
//            moveSpeed = charSpeed;
//            statEffects = new List<Effect>();

//            //Temporary test stats
//            health = 10;
//            attackStat = 1;
//            specialAttackStat = 1;
//            defenseStat = 1;
//            specialDefenseStat = 1;
//        }

//        /*
//         * Sums the percentage(s) (as doubles) for the Effects' corresponding stat changes. A positive sum will increase stats, negative will decrease.
//         */
//        protected double sumAllEffects_Hp()
//        {
//            double sum = 0;

//            foreach (Effect anEffect in statEffects)
//            {
//                sum = sum + anEffect.healthChange;
//            }

//            return sum;
//        }

//        protected int sumAllEffects_Speed()
//        {
//            int sum = 0;

//            foreach (Effect anEffect in statEffects)
//            {
//                sum = sum + anEffect.moveSpeedChange;
//            }

//            return sum;
//        }

//        protected double sumAllEffects_Attack()
//        {
//            double sum = 0;

//            foreach (Effect anEffect in statEffects)
//            {
//                sum = sum + anEffect.attackChange;
//            }

//            return sum;
//        }

//        protected double sumAllEffects_SpAttack()
//        {
//            double sum = 0;

//            foreach (Effect anEffect in statEffects)
//            {
//                sum = sum + anEffect.spAttackChange;
//            }

//            return sum;
//        }

//        protected double sumAllEffects_Defense()
//        {
//            double sum = 0;

//            foreach (Effect anEffect in statEffects)
//            {
//                sum = sum + anEffect.defenseChange;
//            }

//            return sum;
//        }

//        protected double sumAllEffects_SpDefense()
//        {
//            double sum = 0;

//            foreach (Effect anEffect in statEffects)
//            {
//                sum = sum + anEffect.spDefenseChange;
//            }

//            return sum;
//        }

//        /*
//         * For taking damage (when another character attacks you).
//         * 
//         * Calculates damage that should be applied to the character based on the opponent's attack and special attack stats, and the attack power of the attack they used
//         * Character who's being attacked's defense is used "against" the opponent's attack, and their special defense is used against the opponent's special attack.
//         * Checks if health is less than or equal to zero, so
//         */
//        public void damage(int opponentAttack, int opponentSpecialAttack, double attackPower)
//        {
//            //Damage calculating formula I made up off the top of my head. Almost definitely will need to be replaced/adjusted.
//            int damage = (int)(((opponentAttack / defense + opponentSpecialAttack / specialDefense) * attackPower));

//            health = health - damage;

//            if (health <= 0)
//            {
//                //NEEDS TO BE DONE:
//                //character dies *insert code here*
//                //if hero, can't just set it to null, need it to be stored somewhere.
//            }
//        }

//        public void addEffect(Effect anEffect)
//        {
//            statEffects.Add(anEffect);
//        }

//        /*
//         * Loops through all status effects applied to the character, decrements the amount of turns it will continue to affect their stats, and if 0, removes.
//         * 
//         * Should be ran after every turn.
//         */
//        public void decrementEffectDurations()
//        {
//            foreach (Effect anEffect in statEffects)
//            {
//                anEffect.decrement();

//                if (anEffect.turnsLeft <= 0)
//                {
//                    statEffects.Remove(anEffect);
//                }
//            }
//        }

//        /*
//         * Adds a percentage of the character's health to the health points based on the total sum of percentages of hp change of all Effect(s)
//         * Negative sumAllEffects_Hp() will decrease health, positive will increase/"heal"
//         */
//        public void applyEffectHealthChange()
//        {
//            health = health + (int)(health * sumAllEffects_Hp());
//        }

//        public virtual int[,] Ability1(int[,] boardspaces)
//        {
//            return boardspaces;
//        }

//        public virtual int[,] Ability2(int[,] boardspaces)
//        {
//            return boardspaces;
//        }

//        public virtual int[,] Ability3(int[,] boardspaces)
//        {
//            return boardspaces;
//        }

//        public virtual int[,] Ability4(int[,] boardspaces)
//        {
//            return boardspaces;
//        }
//    }
//}
