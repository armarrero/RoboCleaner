using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobotCleaner;
using System;

namespace RobotCleanerTests
{
    [TestClass]
    public class MarkedCoordinatesCleanedTests
    {
        Robot testRobot;

        [TestInitialize]
        public void Setup()
        {
            testRobot = new Robot(0, 0);
        }

        [TestMethod]
        public void TestInitializing_MarksCoordinateClean_AndHasOneCoordinate()
        {
            var initializeRobot = new Robot(0, 0);
            bool cleaned00;
            initializeRobot.CleanedCoordinates.TryGetValue(new Tuple<int, int>(0, 0), out cleaned00);
            Assert.IsTrue(cleaned00);

            var expectedCount = 1;
            var actualCount = initializeRobot.CleanedCoordinates.Count;
            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestMethod]
        public void Test_MarkCoordinatesClean_AddsOneCleanedTotal()
        {
            testRobot.X = 1;
            testRobot.MarkCoordinatesCleaned();

            bool cleaned10;
            testRobot.CleanedCoordinates.TryGetValue(new Tuple<int, int>(1, 0), out cleaned10);
            Assert.IsTrue(cleaned10);

            var expectedCount = 2;
            var actualCount = testRobot.CleanedCoordinates.Count;
            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestMethod]
        public void Test_MarkSameCoordinatesCleanMultipleTimes_AddsOneCleanedTotal()
        {
            testRobot.X = 1;
            testRobot.MarkCoordinatesCleaned();
            testRobot.MarkCoordinatesCleaned();
            testRobot.MarkCoordinatesCleaned();

            bool cleaned10;
            testRobot.CleanedCoordinates.TryGetValue(new Tuple<int, int>(1, 0), out cleaned10);
            Assert.IsTrue(cleaned10);

            var expectedCount = 2;
            var actualCount = testRobot.CleanedCoordinates.Count;
            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestMethod]
        public void Test_MarkTwoCoordinatesClean_AddsTwoCleanedTotal()
        {
            testRobot.X = 2;
            testRobot.MarkCoordinatesCleaned();
            testRobot.Y = 1;
            testRobot.MarkCoordinatesCleaned();

            bool cleaned20;
            testRobot.CleanedCoordinates.TryGetValue(new Tuple<int, int>(2, 0), out cleaned20);
            Assert.IsTrue(cleaned20);
            bool cleaned21;
            testRobot.CleanedCoordinates.TryGetValue(new Tuple<int, int>(2, 1), out cleaned21);
            Assert.IsTrue(cleaned21);

            var expectedCount = 3;
            var actualCount = testRobot.CleanedCoordinates.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }
    }
}
