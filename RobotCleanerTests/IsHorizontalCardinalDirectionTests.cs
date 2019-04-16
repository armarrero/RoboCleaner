using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobotCleaner;

namespace RobotCleanerTests
{
    [TestClass]
    public class IsHorizontalCardinalDirectionTests
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
        public void IsHorizontalCardinalDirection_ReturnsTrueForEastWest()
        {        
            Assert.IsTrue(testRobot.IsHorizontalCardinalDirection(east));
            Assert.IsTrue(testRobot.IsHorizontalCardinalDirection(west));
        }

        [TestMethod]
        public void IsHorizontalCardinalDirection_ReturnsFalseForNorthSouth()
        {
            Assert.IsFalse(testRobot.IsHorizontalCardinalDirection(north));
            Assert.IsFalse(testRobot.IsHorizontalCardinalDirection(south));
        }
    }
}
