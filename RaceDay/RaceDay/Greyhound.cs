using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace RaceDay
{
    class Greyhound
    {
        public int StartingPosition;
        public int RacetrackLength;
        public PictureBox MyPictureBox = null;
        public int Location = 0;
        public Random Randomizer;
       
        public bool Run()
        {
            
            Point P = MyPictureBox.Location;
            int Distance = Randomizer.Next(4);
            P.X += Distance;
            Location += Distance;
            MyPictureBox.Location = P;   

            if (Location > RacetrackLength)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void ReturnToStart()
        {
            Location = 0;
            Point P = MyPictureBox.Location;
            P.X = StartingPosition;
            MyPictureBox.Location = P;
        }

    }
}
