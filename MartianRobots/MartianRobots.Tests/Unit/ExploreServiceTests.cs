using MartianRobots.Core;
using MartianRobots.Core.Entities;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace MartianRobots.Tests.Unit
{
    public class ExploreServiceTests
    {
        [Test]
        public void SampleInput()
        {
            var robot1 = new Robot(
                new Position(new Coordinate(1, 1), Orientation.East),
                new List<Instruction> {
                    Instruction.Right,
                    Instruction.Forward,
                    Instruction.Right,
                    Instruction.Forward,
                    Instruction.Right,
                    Instruction.Forward,
                    Instruction.Right,
                    Instruction.Forward
                }
            );
            var robot2 = new Robot(
                new Position(new Coordinate(3, 2), Orientation.North),
                new List<Instruction> {
                    Instruction.Forward,
                    Instruction.Right,
                    Instruction.Right,
                    Instruction.Forward,
                    Instruction.Left,
                    Instruction.Left,
                    Instruction.Forward,
                    Instruction.Forward,
                    Instruction.Right,
                    Instruction.Right,
                    Instruction.Forward,
                    Instruction.Left,
                    Instruction.Left
                }
            );
            var robot3 = new Robot(
                new Position(new Coordinate(0, 3), Orientation.West),
                new List<Instruction> {
                    Instruction.Left,
                    Instruction.Left,
                    Instruction.Forward,
                    Instruction.Forward,
                    Instruction.Forward,
                    Instruction.Right,
                    Instruction.Forward,
                    Instruction.Left,
                    Instruction.Forward,
                    Instruction.Left
                }
            );

            var request = TestRequest(new List<Robot> { robot1, robot2, robot3});
            var exploreService = InitializeExploreService();
            var response = exploreService.ExploreWorld(request);
            Assert.AreEqual("1 1 E\n3 3 N LOST\n4 2 N", response.Result);
        }

        [Test]
        public void SecondRobotDoesNotLose()
        {
            var robot1 = new Robot(
                new Position(new Coordinate(5, 3), Orientation.East),
                new List<Instruction> {
                    Instruction.Forward
                }
            );
            var robot2 = new Robot(
                new Position(new Coordinate(5, 3), Orientation.East),
                new List<Instruction> {
                    Instruction.Forward
                }
            );
            var request = TestRequest(new List<Robot> { robot1, robot2 });
            var exploreService = InitializeExploreService();
            var response = exploreService.ExploreWorld(request);
            Assert.AreEqual("5 3 E LOST\n5 3 E", response.Result);
        }

        [Test]
        public void SecondRobotDoesNotLoseDifferentOrientation()
        {
            var robot1 = new Robot(
                new Position(new Coordinate(0, 3), Orientation.North),
                new List<Instruction> {
                    Instruction.Forward
                }
            );
            var robot2 = new Robot(
                new Position(new Coordinate(0, 3), Orientation.West),
                new List<Instruction> {
                    Instruction.Forward
                }
            );
            var request = TestRequest(new List<Robot> { robot1, robot2 });
            var exploreService = InitializeExploreService();
            var response = exploreService.ExploreWorld(request);
            Assert.AreEqual("0 3 N LOST\n0 3 W", response.Result);
        }

        [Test]
        public void CanGetBetterScore()
        {
            var robot1 = new Robot(
                new Position(new Coordinate(0, 3), Orientation.East),
                new List<Instruction> {
                    Instruction.Forward,
                    Instruction.Forward,
                }
            );

            var request1 = TestRequest(new List<Robot> { robot1 });
            var exploreService1 = InitializeExploreService();
            var response1 = exploreService1.ExploreWorld(request1);

            var robot2 = new Robot(
                new Position(new Coordinate(0, 3), Orientation.East),
                new List<Instruction> {
                    Instruction.Forward,
                    Instruction.Forward,
                    Instruction.Forward
                }
            );

            var request2 = TestRequest(new List<Robot> { robot2 });
            var exploreService2 = InitializeExploreService();
            var response2 = exploreService2.ExploreWorld(request2);

            Assert.AreEqual(3, response1.ScoreResult);
            Assert.AreEqual(4, response2.ScoreResult);
        }

        [Test]
        public void LosesScore()
        {
            var robot1 = new Robot(
                new Position(new Coordinate(0, 3), Orientation.East),
                new List<Instruction> {
                    Instruction.Forward,
                    Instruction.Forward,
                }
            );

            var robot2 = new Robot(
                new Position(new Coordinate(0, 3), Orientation.East),
                new List<Instruction> {
                    Instruction.Forward,
                    Instruction.Forward
                }
            );
            var request = TestRequest(new List<Robot> { robot1, robot2 });
            var exploreService = InitializeExploreService();
            var response = exploreService.ExploreWorld(request);
            Assert.AreEqual(0,response.ScoreResult);
        }

        private static ExploreRequest TestRequest(List<Robot> robots)
        {
            var world = new World(new Coordinate(5, 3));
            return new ExploreRequest(world, robots);
        }

        private static IExploreService InitializeExploreService()
        {
            var topScoreRepository = new Mock<ITopScoreRepository>();
            return new ExploreService(topScoreRepository.Object);
        }
    }
}
