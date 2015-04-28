using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Community
{
    public class CampusPolice : Enemy
    {
        public CampusPolice()
        {
            Init();
        }

        // Second constructor.
        public CampusPolice(int r, int c) : base(r, c)
        {
            Init();
            Row = r;
            Col = c;
        }

        private void Init()
        {
            /******************************************************************
             * stat progression unique to this job role.
             * ****************************************************************
             */
            JobRole = "Campus Police";

            pictureFile = "Enemies/Campus_Police.png";
            characterPicture = new BitmapImage(new Uri(pictureFile, UriKind.Relative));

            statEffects = new List<Effect>();

            HealthMulti = 3.00;
            EnergyMulti = 1.50;
            AttackMulti = 2.00;
            DefenseMulti = 3.00;
            SpeedMulti = 1;
            AgilityMulti = 1;
            AttackRangeMulti = 1.00;
            SpecialAttackMulti = 2.00;
            SpecialDefenseMulti = 2.00;

            ExperienceAmountMulti = 25.00;
            /******************************************************************
             * stats initialized after multipliers applied.
             * ****************************************************************
             */
            InstantiateLevel(1);
        }
    }
}