using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Community
{
    public class Gardener : Enemy
    {
        private int p1;
        private int p2;

        public Gardener()
        {
            Init();
        }

        // Second constructor.
        public Gardener(int r, int c) : base(r, c)
        {
            Init();
            row = r;
            col = c;
        }

        private void Init()
        {
            /******************************************************************
             * stat progression unique to this job role.
             * ****************************************************************
             */
            JobRole = "Gardener";

            pictureFile = "Enemies/Gardener.png";
            characterPicture = new BitmapImage(new Uri(pictureFile, UriKind.Relative));

            statEffects = new List<Effect>();

            HealthMulti = 1.75;
            EnergyMulti = 1.50;
            AttackMulti = 3.00;
            DefenseMulti = 1.50;
            SpeedMulti = 1;
            AgilityMulti = 1;
            AttackRangeMulti = 3.00;
            SpecialAttackMulti = 2.00;
            SpecialDefenseMulti = 1.50;

            ExperienceAmountMulti = 20.00;
            /******************************************************************
             * stats initialized after multipliers applied.
             * ****************************************************************
             */
            InstantiateLevel(1);
        }
    }
}