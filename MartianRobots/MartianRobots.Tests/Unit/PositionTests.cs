using MartianRobots.Core.Entities;
using NUnit.Framework;

namespace MartianRobots.Tests.Unit
{
    public class PositionTests
    {
        [Test]
        public void MovesForward()
        {
            var initialPosition = new Position(new Coordinate(1, 1), Orientation.North);

            var newPosition = initialPosition.executeInstruction(Instruction.Forward);
            var expectedPosition = new Coordinate(1, 2);

            Assert.AreEqual(expectedPosition.X,newPosition.Coordinate.X);
            Assert.AreEqual(expectedPosition.Y, newPosition.Coordinate.Y);
        }

        [Test]
        public void MovesRight()
        {
            var initialPosition = new Position(new Coordinate(1, 1), Orientation.North);

            var newPosition = initialPosition.executeInstruction(Instruction.Right);
            Assert.AreEqual(Orientation.East, newPosition.Orientation);

            newPosition = newPosition.executeInstruction(Instruction.Right);
            Assert.AreEqual(Orientation.South, newPosition.Orientation);

            newPosition = newPosition.executeInstruction(Instruction.Right);
            Assert.AreEqual(Orientation.West, newPosition.Orientation);

            newPosition = newPosition.executeInstruction(Instruction.Right);
            Assert.AreEqual(Orientation.North, newPosition.Orientation);
        }

        [Test]
        public void MovesLeft()
        {
            var initialPosition = new Position(new Coordinate(1, 1), Orientation.North);

            var newPosition = initialPosition.executeInstruction(Instruction.Left);
            Assert.AreEqual(Orientation.West, newPosition.Orientation);

            newPosition = newPosition.executeInstruction(Instruction.Left);
            Assert.AreEqual(Orientation.South, newPosition.Orientation);

            newPosition = newPosition.executeInstruction(Instruction.Left);
            Assert.AreEqual(Orientation.East, newPosition.Orientation);

            newPosition = newPosition.executeInstruction(Instruction.Left);
            Assert.AreEqual(Orientation.North, newPosition.Orientation);
        }
    }
}
