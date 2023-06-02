using Newtonsoft.Json.Linq;
using System.Diagnostics.Metrics;
using System.Reflection.Metadata;

namespace TestProject1
{
    public class Tests
    {
        [Test]
        public void TestMinAll()
        {
            Builder Minall = new Builder();
            Minall.FirstFloorArea = -12;
            Minall.SecondFloorArea = -12;
            Minall.ThirdFloorArea = -12;
            Minall.FourthFloorArea = -12;
            Minall.FifthFloorArea = -12;
            var exception = Assert.Throws<ArgumentException>(() => Minall.CalculateTotalArea(), "throw exception");
            Assert.AreEqual("Values cannot be negative", exception.Message);
        }
        [Test]
        public void TestNumOptions()
        {
            Builder NunOpt = new Builder();
            NunOpt.NumberOfOptions = -1;
            var exception = Assert.Throws<ArgumentException>(() => NunOpt.CalculateOptionCost(), "throw exception");
            Assert.AreEqual("Values cannot be negative.", exception.Message);
        }
        [Test]
        public void AreaGood()
        {
            Builder AreaGood = new Builder();
            AreaGood.FirstFloorArea = 12;
            AreaGood.SecondFloorArea = 12;
            AreaGood.ThirdFloorArea = 12;
            AreaGood.FourthFloorArea = 12;
            AreaGood.FifthFloorArea = 12;
            double expected = 60;
            double actual = AreaGood.CalculateTotalArea();
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void OptionsGood()
        {
            Builder OptGood = new Builder();
            OptGood.NumberOfOptions = 2;
            double expected = 10000;
            double actual = OptGood.CalculateOptionCost();
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void TotalAreaGood() 
        {
            Builder TotalGood = new Builder();
            TotalGood.FirstFloorArea = 12; TotalGood.SecondFloorArea = 12;
            double expected = 24;
            double actual = TotalGood.CalculateTotalArea();
            Assert.AreEqual(expected, actual);
        }

        /*
        This solution completely lacks the meaning of the tests given below
        The problem is that constant variables in a real project would getthe
        value from a conditional database/directory, which currently do not exist.
        */

        [Test]
        public void MaterialCost()
        {
            Builder MaterialCost = new Builder();
            double expected = 100000;
            double actual = MaterialCost.CalculateMaterialCost();
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void LaborCost()
        {
            Builder LaborCost = new Builder();
            double expected = 50000;
            double actual = LaborCost.CalculateLaborCost();
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void PermitCost()
        {
            Builder PermitCost = new Builder();
            double expected = 15000;
            double actual = PermitCost.CalculatePermitCost();
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void TotalCost()
        {
            Builder TotalCost = new Builder();
            TotalCost.NumberOfOptions = 1;
            TotalCost.FirstFloorArea = 12;
            TotalCost.SecondFloorArea = 12;
            double expected = 650000;
            double actual = TotalCost.CalculateTotalCost();
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void MonthlyPayment()
        {
            Builder MonthlyPayment = new Builder();
            MonthlyPayment.NumberOfOptions = 1;
            MonthlyPayment.FirstFloorArea = 12;
            MonthlyPayment.SecondFloorArea = 12;
            double expected = 271;
            double actual = MonthlyPayment.CalculateMonthlyPayment();
            Assert.AreEqual(expected, actual,0.5);
        }
        [Test]
        public void TotalSavings()
        {
            Builder TotalSavings = new Builder();
            TotalSavings.NumberOfOptions = 1;
            TotalSavings.FirstFloorArea = 12;
            TotalSavings.SecondFloorArea = 12;
            double expected = 780000;
            double actual = TotalSavings.CalculateTotalSavingsNeeded();
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void MonthlySavings()
        {
            Builder MonthlySavings = new Builder();
            MonthlySavings.NumberOfOptions = 1;
            MonthlySavings.FirstFloorArea = 12;
            MonthlySavings.SecondFloorArea = 12;
            double expected = 32500;
            double actual = MonthlySavings.CalculateMonthlySavings();
            Assert.AreEqual(expected, actual);
        }
    }
}