using System;

namespace TruckRace
{
    // this coding is for bet class
    public class Bet
    {
        public int Amount;
        public int TruckNum;
        public Racer Bettor;

        public Bet(int Amount, int TruckNum, Racer Bettor)
        {
            this.Amount = Amount;
            this.TruckNum = TruckNum;
            this.Bettor = Bettor;
        }
        //this coding is for winner class

        public int Pay(int Winner)
        {
            if (TruckNum == Winner)
            {
                return Amount;
            }
            return -Amount;
        }

        // this coding is for description
        public string Descr()
        {
            string description = "";

            if (Amount > 0)
            {
                description = String.Format("{0} bets {1} on Truck #{2}",
                    Bettor.Name, Amount, TruckNum);
            }
            else
            {
                description = String.Format("{0} hasn't placed any bets",
                    Bettor.Name);
            }
            return description;
        }

    }
}
