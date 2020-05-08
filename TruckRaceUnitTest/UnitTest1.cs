using Microsoft.VisualStudio.TestTools.UnitTesting;
using TruckRace;
namespace TruckRaceTest
{
    [TestClass]
    public class UnitTest1
    {
        Factory Obj_Factory = new Factory();
        Racer Lucy;
        Trucks[] Truckss = new Trucks[1];

        [TestMethod]
        public void TestWinnerOutcome()
        {
            Trucks.StartingPosition1 = 0;
            Trucks.RacetrackLength1 = 50;
            int TruckRaceAmount = 50;
            int TrucksNumber = 1;
            int expectedWin = 100;
            int expectedLose = 0;
            Truckss[0] = new Trucks() { TrucksPictureBox = null };
            //  Truckss[1] = new Trucks() { TrucksPictureBox = null };
            Lucy = Obj_Factory.getRacer("Lucy", null, null);
            Lucy.Cash = TruckRaceAmount;
            Lucy.PlaceBet((int)TruckRaceAmount, TrucksNumber);

            bool nowin = true;
            int win = -1;
            while (nowin)
            {
                for (int i = 0; i < Truckss.Length; i++)
                {
                    if (Trucks.Run(Truckss[i]))
                    {
                        win = i + 1;
                        Lucy.Collect(win);
                        nowin = false;

                    }
                }
            }
            if (Lucy.bet.TruckNum == win)
            {
                Assert.AreEqual(expectedWin, Lucy.Cash, "Account not credited correctly");
            }
            if (Lucy.bet.TruckNum != win)
            {
                Assert.AreEqual(expectedLose, Lucy.Cash, "Account not debited correctly");

            }
        }
    }

}
