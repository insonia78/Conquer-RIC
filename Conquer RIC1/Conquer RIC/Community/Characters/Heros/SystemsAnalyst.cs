using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Collections;

namespace Community
{
    public class SystemsAnalyst : Hero
    {
        public SystemsAnalyst(String nam, bool sex)
        {
            Init(nam, sex);
        }

        // Second constructor.
        public SystemsAnalyst(int r, int c) : base(r, c)
        {
            Init(null, true);
            Row = r;
            Col = c;
        }

        private void Init(String n, bool s)
        {
            Name = n;
            Male = s;
            JobRole = "Systems Analyst";

            // Picture will be generated depending on the sex.
            if(Male)
            {
                PortraitFile = "Male_System_Analyst_portrait.png";
                pictureFile = "Heroes/System_Analyst_MALE.png";
                //CharacterPicture = " "; 
            }
            else
            {
                PortraitFile = "Female_System_Analyst_portrait.png";
                pictureFile = "Heroes/System_Analyst_FEMALE.png";
                //CharacterPicture = " "; 
            }
            CharacterPicture = new BitmapImage(new Uri(pictureFile, UriKind.Relative));

            statEffects = new List<Effect>();

            /******************************************************************
             * stat progression unique to this job role.
             * ****************************************************************
             */
            HealthMulti = 1.75;
            EnergyMulti = 3.00;
            AttackMulti = 1.25;
            DefenseMulti = 1.25;
            SpeedMulti = 2;
            AgilityMulti = 2;
            AttackRangeMulti = 2.00;
            SpecialAttackMulti = 3.00;
            SpecialDefenseMulti = 2.00;

            /******************************************************************
             * stats initialized after multipliers applied.
             * ****************************************************************
             */
            InstantiateLevel(1);
        }
    }
}