namespace TestProject1
{
    public class Tests
    {
        [Test]
        public void TestMinAll()
        {
            Builder Minall = new(1);
            for (int i = 0; i < 5; i++)
                Minall.FloorsArea.Add(-12);
            Assert.Throws<ArgumentException>(() => Minall.CalculateTotalArea(), "Floors area cannot be negative");
        }

        [Test]
        public void AreaGood()
        {
            Builder AreaGood = new(1);
            for (int i = 0; i < 5; i++)
                AreaGood.FloorsArea.Add(12);
            double expected = 60;
            double actual = AreaGood.CalculateTotalArea();
            Assert.That(actual, Is.EqualTo(expected));
        }
        [Test]
        public void OptionsGood()
        {
            Builder OptGood = new(1);
            double expected = 5000;
            double actual = OptGood.CalculateOptionCost();
            Assert.That(actual, Is.EqualTo(expected));
        }
        [Test]
        public void TotalAreaGood()
        {
            Builder TotalGood = new(1);
            for (int i = 0; i < 2; i++)
                TotalGood.FloorsArea.Add(12);

            double expected = 24;
            double actual = TotalGood.CalculateTotalArea();
            Assert.That(actual, Is.EqualTo(expected));
        }

        /*
        This solution completely lacks the meaning of the tests given below
        The problem is that constant variables in a real project would get the
        value from a conditional database/directory, which currently do not exist.
        */

        [Test]
        public void MaterialCost()
        {
            Builder MaterialCost = new(1);
            double expected = 100000;
            double actual = MaterialCost.CalculateMaterialCost();
            Assert.That(actual, Is.EqualTo(expected));
        }
        [Test]
        public void LaborCost()
        {
            Builder LaborCost = new(1);
            double expected = 50000;
            double actual = LaborCost.CalculateLaborCost();
            Assert.That(actual, Is.EqualTo(expected));
        }
        [Test]
        public void PermitCost()
        {
            Builder PermitCost = new(1);
            double expected = 15000;
            double actual = PermitCost.CalculatePermitCost();
            Assert.That(actual, Is.EqualTo(expected));
        }
        [Test]
        public void TotalCost()
        {
            Builder TotalCost = new(1);
            for (int i = 0; i < 2; i++)
                TotalCost.FloorsArea.Add(12);
            double expected = 650000;
            double actual = TotalCost.CalculateTotalCost();
            Assert.That(actual, Is.EqualTo(expected));
        }
        [Test]
        public void MonthlyPayment()
        {
            Builder MonthlyPayment = new(1);
            for (int i = 0; i < 2; i++)
                MonthlyPayment.FloorsArea.Add(12);
            double expected = 271;
            double actual = MonthlyPayment.CalculateMonthlyPayment();
            Assert.That(actual, Is.EqualTo(expected).Within(0.5));
        }
        [Test]
        public void TotalSavings()
        {
            Builder TotalSavings = new(1);
            for (int i = 0; i < 2; i++)
                TotalSavings.FloorsArea.Add(12);
            double expected = 780000;
            double actual = TotalSavings.CalculateTotalSavingsNeeded();
            Assert.That(actual, Is.EqualTo(expected));
        }
        [Test]
        public void MonthlySavings()
        {
            Builder MonthlySavings = new(1);
            for (int i = 0; i < 2; i++)
                MonthlySavings.FloorsArea.Add(12);
            double expected = 32500;
            double actual = MonthlySavings.CalculateMonthlySavings();
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}