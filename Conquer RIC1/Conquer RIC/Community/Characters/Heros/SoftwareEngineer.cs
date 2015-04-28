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
    /**************************************************************************
         * TODO:
         * Job-specific abilities
         * ********************************************************************
         */
    public class SoftwareEngineer : Hero
    {
        public SoftwareEngineer(String nam, bool sex)
        {
            Init(nam, sex);
        }

        // Second constructor.
        public SoftwareEngineer(int r, int c) : base(r, c)
        {
            Init(null, true);
            Row = r;
            Col = c;
        }

        private void Init(String n, bool s)
        {
            Name = n;
            Male = s;
            JobRole = "Software Engineer";

            // Picture will be generated depending on the sex.
            if(Male)
            {
                PortraitFile = "Male_Software_Engineer_portrait.png";
                pictureFile = "Heroes/Software_Engineer_MALE.png";
                //CharacterPicture = " "; 
            }
            else
            {
                PortraitFile = "Female_Software_Engineer_portrait.png";
                pictureFile = "Heroes/Software_Engineer_FEMALE.png";
                //CharacterPicture = " "; 
            }
            characterPicture = new BitmapImage(new Uri(pictureFile, UriKind.Relative));

            statEffects = new List<Effect>();

            /******************************************************************
             * stat progression unique to this job role.
             * ****************************************************************
             */
            HealthMulti = 3.00;
            EnergyMulti = 1.50;
            AttackMulti = 2.00;
            DefenseMulti = 3.00;
            SpeedMulti = 1;
            AgilityMulti = 1;
            AttackRangeMulti = 1.00;
            SpecialAttackMulti = 2.00;
            SpecialDefenseMulti = 2.00;

            /******************************************************************
             * stats initialized after multipliers applied.
             * ****************************************************************
             */
            InstantiateLevel(1);
        }
    }
}