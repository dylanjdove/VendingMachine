using Capstone;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CapstoneTests
{
    [TestClass]
    public class MoneyTillTests
    {
        [TestMethod]
        public void Money_Till_Should_Return_1_95_When_Purchasing_PotatoCrisps_With_5()
        {
            MoneyTill moneyTill = new MoneyTill();
            Chip newChip = new Chip("Potato Crisps", 3.05m, "A1");
            decimal expected = 1.95m;
            decimal actual = moneyTill.Purchase(newChip, 5m);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Money_Till_Should_Return_55_When_Purchasing_Stackers_With_2()
        {
            MoneyTill moneyTill = new MoneyTill();
            Chip newChip = new Chip("Stackers", 1.45m, "A2");
            decimal expected = .55m;
            decimal actual = moneyTill.Purchase(newChip, 2m);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Money_Till_Should_Return_2_When_Purchasing_Moonpie_With_2()
        {
            MoneyTill moneyTill = new MoneyTill();
            Candy newCandy = new Candy("MoonPie", 1.8m, "B1");
            decimal expected = .2m;
            decimal actual = moneyTill.Purchase(newCandy, 2m);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Money_Till_Should_Return_75_When_Purchasing_Cola_With_2()
        {
            MoneyTill moneyTill = new MoneyTill();
            Drink newDrink = new Drink("Cola", 1.25m, "C1");
            decimal expected = .75m;
            decimal actual = moneyTill.Purchase(newDrink, 2m);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Money_Till_Should_Return_125_When_Purchasing_Chiclets_With_2()
        {
            MoneyTill moneyTill = new MoneyTill();
            Gum newGum = new Gum("Chiclets", .75m, "D3");
            decimal expected = 1.25m;
            decimal actual = moneyTill.Purchase(newGum, 2m);

            Assert.AreEqual(expected, actual);
        }
    }
}
