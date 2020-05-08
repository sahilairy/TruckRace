using System;
using System.Windows.Forms;

namespace TruckRace
{
    public partial class TruckForm : Form
    {
        Trucks[] Truckss = new Trucks[4];

        Factory pFactory = new Factory();
        Racer[] Racers = new Racer[3];

        public TruckForm()
        {
            InitializeComponent();
            SetupRaceTrack();
        }

        private void SetupRaceTrack()
        {

            Trucks.StartingPosition1 = Truck1.Right - racetrack.Left;
            Trucks.RacetrackLength1 = racetrack.Size.Width - 70; //fixing length of race - till finish line

            Truckss[0] = new Trucks() { TrucksPictureBox = Truck1 };
            Truckss[1] = new Trucks() { TrucksPictureBox = Truck2 };
            Truckss[2] = new Trucks() { TrucksPictureBox = Truck3 };
            Truckss[3] = new Trucks() { TrucksPictureBox = Truck4 };

            Racers[0] = pFactory.getRacer("Jhong", MaximumBet, RajdeepBet); //getting Jhong object from factory class
            Racers[1] = pFactory.getRacer("Romy", MaximumBet, RamanBet); //getting Romy object from factory class
            Racers[2] = pFactory.getRacer("Lucy", MaximumBet, LovedeepBet); //getting Lucy object from factory class


            foreach (Racer Racer in Racers)
            {
                Racer.UpdateLabels();
            }
        }

        private void RajdeepButton_CheckedChanged(object sender, EventArgs e)
        {
            setMaximumBetTextLabel(Racers[0].Cash);
        }

        private void RamanButton_CheckedChanged(object sender, EventArgs e)
        {
            setMaximumBetTextLabel(Racers[1].Cash);
        }

        private void LovedeepButton_CheckedChanged(object sender, EventArgs e)
        {
            setMaximumBetTextLabel(Racers[2].Cash);
        }

        private void setMaximumBetTextLabel(int Cash)
        {
            MaximumBet.Text = String.Format("Maximum Bet: ${0}", Cash);
        }

        // setting the bet for each Racer and updating labels respectively
        private void Bets_Click(object sender, EventArgs e)
        {
            int RacerNum = 0;

            if (RajdeepButton.Checked)
            {
                RacerNum = 0;
            }
            if (RamanRButton.Checked)
            {
                RacerNum = 1;
            }
            if (LovedeepRButton.Checked)
            {
                RacerNum = 2;
            }

            Racers[RacerNum].PlaceBet((int)TruckRaceAmount.Value, (int)TrucksNumber.Value);
            Racers[RacerNum].UpdateLabels();
        }

        private void race_Click(object sender, EventArgs e)
        {
            bool NoWinner = true;
            int winningTrucks;
            race.Enabled = false; //disable start race button

            while (NoWinner)
            { // loop until we have a winner
                Application.DoEvents();
                for (int i = 0; i < Truckss.Length; i++)
                {
                    if (Trucks.Run(Truckss[i]))
                    {
                        winningTrucks = i + 1;
                        NoWinner = false;
                        MessageBox.Show("winner of the race is - Trucks #" + winningTrucks);
                        foreach (Racer Racer in Racers)
                        {
                            if (Racer.bet != null)
                            {
                                Racer.Collect(winningTrucks); //give double amount to all who've won or deduce betted amount
                                Racer.bet = null;
                                Racer.UpdateLabels();
                            }
                        }
                        foreach (Trucks Trucks in Truckss)
                        {
                            Trucks.TakeStartingPosition();
                        }
                        break;
                    }
                }
            }
            if (Racers[0].busted && Racers[1].busted && Racers[2].busted)
            {  //stop Racers from betting if they run out of cash
                String message = "Do you want to Play Again?";
                String title = "GAME OVER!";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                    SetupRaceTrack(); //restart game
                }
                else
                {
                    this.Close();
                }

            }
            race.Enabled = true; //enable race button 
        }

        private void Truck1_Click(object sender, EventArgs e)
        {

        }
    }
}
