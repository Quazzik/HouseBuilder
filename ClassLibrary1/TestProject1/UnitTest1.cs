using System.Diagnostics.Metrics;

namespace TestProject1
{
    public class Tests
    {
        Builder builder = new Builder();

        [Test]
        public void TestMinAll()
        {
            builder.FirstFloorArea = -12;
            builder.SecondFloorArea = -12;
            builder.ThirdFloorArea = -12;
            builder.FourthFloorArea = -12;
            builder.FifthFloorArea = -12;
            var exception = Assert.Throws<ArgumentException>(() => builder.CalculateTotalArea(), "throw exception");
            Assert.AreEqual("Values cannot be negative", exception.Message);
        }
        [Test]
        public void TestNumOptions()
        {
            builder.NumberOfOptions = -1;
            var exception = Assert.Throws<ArgumentException>(() => builder.CalculateOptionCost(), "throw exception");
            Assert.AreEqual("Values cannot be negative.", exception.Message);
        }
        [Test]
        public void AreaGood()
        {
            builder.FirstFloorArea = 12;
            builder.SecondFloorArea = 12;
            builder.ThirdFloorArea = 12;
            builder.FourthFloorArea = 12;
            builder.FifthFloorArea = 12;
            double expected = 60;
            double actual = builder.CalculateTotalArea();
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void OptionsGood()
        {
            builder.NumberOfOptions = 2;
            double expected = 10000;
            double actual = builder.CalculateOptionCost();
            Assert.AreEqual(expected, actual);
        }
    }
}