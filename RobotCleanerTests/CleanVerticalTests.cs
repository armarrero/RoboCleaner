using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobotCleaner;
using System;

namespace RobotCleanerTests
{
    [TestClass]
    public class CleanVerticalTests
    {
        Robot testRobot;
        CardinalDirectionEnum north;
        CardinalDirectionEnum south;

        [TestInitialize]
        public void Setup()
        {
            north = CardinalDirectionEnum.N;
            south = CardinalDirectionEnum.S;
            testRobot = new Robot(0, 0);
        }

        [TestMethod]
        public void TestCleanVertical_TwoSteps_MarksCoordinatesClean_AndHasThreeCoordinate()
        {
            testRobot.CleanVertical(north, 2);
            bool cleaned01;
            testRobot.CleanedCoordinates.TryGetValue(new Tuple<int, int>(0, 1), out cleaned01);
            Assert.IsTrue(cleaned01);

            bool cleaned02;
            testRobot.CleanedCoordinates.TryGetValue(new Tuple<int, int>(0, 2), out cleaned02);
            Assert.IsTrue(cleaned02);

            var expectedCount = 3;
            var actualCount = testRobot.CleanedCoordinates.Count;
            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestMethod]
        public void TestCleanVertical_OneStepSouth_MarksCoordinatesClean_AndHasTwoCoordinate()
        {
            testRobot.CleanVertical(south, 1);
            bool cleaned01;
            testRobot.CleanedCoordinates.TryGetValue(new Tuple<int, int>(0, -1), out cleaned01);
            Assert.IsTrue(cleaned01);

            var expectedCount = 2;
            var actualCount = testRobot.CleanedCoordinates.Count;
            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestMethod]
        public void TestCleanVertical_OneStepNorthThenSouth_MarksCoordinatesClean_AndHasTwoCoordinate()
        {
            testRobot.CleanVertical(north, 1);
            testRobot.CleanVertical(south, 1);
            bool cleaned01;
            testRobot.CleanedCoordinates.TryGetValue(new Tuple<int, int>(0, 1), out cleaned01);
            Assert.IsTrue(cleaned01);

            var expectedCount = 2;
            var actualCount = testRobot.CleanedCoordinates.Count;
            Assert.AreEqual(expectedCount, actualCount);
        }


    }
}
