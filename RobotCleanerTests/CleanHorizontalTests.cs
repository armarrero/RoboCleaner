using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobotCleaner;
using System;

namespace RobotCleanerTests
{
    [TestClass]
    public class CleanHorizontalTests
    {
        Robot testRobot;
        CardinalDirectionEnum east;
        CardinalDirectionEnum west;

        [TestInitialize]
        public void Setup()
        {
            east = CardinalDirectionEnum.E;
            west = CardinalDirectionEnum.W;
            testRobot = new Robot(0, 0);
        }

        [TestMethod]
        public void TestCleanHorizontal_TwoSteps_MarksCoordinatesClean_AndHasThreeCoordinate()
        {
            testRobot.CleanHorizontal(east, 2);
            bool cleaned10;
            testRobot.CleanedCoordinates.TryGetValue(new Tuple<int, int>(1, 0), out cleaned10);
            Assert.IsTrue(cleaned10);

            bool cleaned20;
            testRobot.CleanedCoordinates.TryGetValue(new Tuple<int, int>(2, 0), out cleaned20);
            Assert.IsTrue(cleaned20);

            var expectedCount = 3;
            var actualCount = testRobot.CleanedCoordinates.Count;
            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestMethod]
        public void TestCleanHorizontal_OneStepWest_MarksCoordinatesClean_AndHasTwoCoordinate()
        {
            testRobot.CleanHorizontal(west, 1);
            bool cleaned10;
            testRobot.CleanedCoordinates.TryGetValue(new Tuple<int, int>(-1, 0), out cleaned10);
            Assert.IsTrue(cleaned10);

            var expectedCount = 2;
            var actualCount = testRobot.CleanedCoordinates.Count;
            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestMethod]
        public void TestCleanHorizontal_OneStepEastThenWest_MarksCoordinatesClean_AndHasTwoCoordinate()
        {
            testRobot.CleanHorizontal(east, 1);
            testRobot.CleanHorizontal(west, 1);
            bool cleaned10;
            testRobot.CleanedCoordinates.TryGetValue(new Tuple<int, int>(1, 0), out cleaned10);
            Assert.IsTrue(cleaned10);

            var expectedCount = 2;
            var actualCount = testRobot.CleanedCoordinates.Count;
            Assert.AreEqual(expectedCount, actualCount);
        }


    }
}
