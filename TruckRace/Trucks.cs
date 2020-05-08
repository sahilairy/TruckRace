using System;
using System.Drawing;
using System.Windows.Forms;

namespace TruckRace
{
    public class Trucks
    {
        private static int StartingPosition;
        private static int RacetrackLength;
        public PictureBox TrucksPictureBox = null;
        public int Location = 0;
        public static Random MyRandom = new Random(); //declared random object as static to avoid same random number

        public static int StartingPosition1 { get => StartingPosition; set => StartingPosition = value; }
        public static int RacetrackLength1 { get => RacetrackLength; set => RacetrackLength = value; }

        // generation across all Trucks objects

        public static bool Run(Trucks obj)
        {
            int distance = MyRandom.Next(2, 6);
            if (obj.TrucksPictureBox != null)
                obj.MoveTrucksPictureBox(distance);

            obj.Location += distance;
            if (obj.Location >= (RacetrackLength1 - StartingPosition1))
            {
                return true;
            }
            return false;
        }

        public void TakeStartingPosition()
        {
            MoveTrucksPictureBox(-Location); //reset location to -ve distance ie. to starting point
            Location = 0;

        }

        public void MoveTrucksPictureBox(int distance)
        {
            Point p = TrucksPictureBox.Location;
            p.X += distance;
            TrucksPictureBox.Location = p; //move Trucks in x-axis
        }
    }
}
