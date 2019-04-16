using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobotCleaner;

namespace RobotCleanerTests
{
    [TestClass]
    public class GetCardinalDirectionTests
    {
        CardinalDirectionEnum east;
        CardinalDirectionEnum west;
        CardinalDirectionEnum north;
        CardinalDirectionEnum south;
        Robot testRobot;

        [TestInitialize]
        public void Setup()
        {
            east = CardinalDirectionEnum.E;
            west = CardinalDirectionEnum.W;
            north = CardinalDirectionEnum.N;
            south = CardinalDirectionEnum.S;
            testRobot = new Robot(0, 0);
        }

        [TestMethod]
        public void GetCardinalDirection_Returns1ForEast()
        {
            var expected = 1;
            var actual = testRobot.GetCardinalDirectionValue(east);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetCardinalDirection_Returns1ForNorth()
        {
            var expected = 1;
            var actual = testRobot.GetCardinalDirectionValue(north);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetCardinalDirection_ReturnsNegative1ForWest()
        {
            var expected = -1;
            var actual = testRobot.GetCardinalDirectionValue(west);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetCardinalDirection_ReturnsNegative1ForSouth()
        {
            var expected = -1;
            var actual = testRobot.GetCardinalDirectionValue(south);
            Assert.AreEqual(expected, actual);
        }
    }
}
