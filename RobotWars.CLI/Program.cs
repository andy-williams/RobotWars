using System;
using System.Linq;

namespace RobotWars.CLI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter upper bound coordinates as X Y");
            var upperBoundCoordinatesArray = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var upperBoundCoordinates = new Coordinates(upperBoundCoordinatesArray[0], upperBoundCoordinatesArray[1]);


            Console.WriteLine("Enter initial robot position as X Y D");
            var initialRobotPosition = Console.ReadLine();
            while (!string.IsNullOrEmpty(initialRobotPosition))
            {
                var robotPositionArray = initialRobotPosition.Split(' ');
                var initialCoordinates = new Coordinates(int.Parse(robotPositionArray[0]), int.Parse(robotPositionArray[1]));
                var initialDirection = StringToDirection(robotPositionArray[2]);

                var robot = new Robot(upperBoundCoordinates, initialCoordinates, initialDirection);

                var robotActions = GetRobotActions();
                robot = InvokeActionsOnRobot(robot, robotActions);
                var robotCoordinates = robot.GetCoordinates();
                Console.WriteLine($"{robotCoordinates.X} {robotCoordinates.Y} {DirectionToString(robot.GetDirection())}");

                initialRobotPosition = GetInitialRobotPosition();
            }
        }

        private static string GetInitialRobotPosition()
        {
            Console.WriteLine("Enter initial robot position as X Y D - enter blank to exit");
            var initialRobotPosition = Console.ReadLine();
            return initialRobotPosition;
        }

        private static string[] GetRobotActions()
        {
            Console.WriteLine("Enter robot actions");
            var robotActions = Console.ReadLine().ToArray().Select(x => new string(new[] { x })).ToArray();
            return robotActions;
        }

        private static Robot InvokeActionsOnRobot(Robot robot, string[] actions)
        {
            foreach (var action in actions)
            {
                if (action == "L")
                    robot.ChangeDirection(DirectionalMove.Left);

                else if (action == "R")
                    robot.ChangeDirection(DirectionalMove.Right);

                else if (action == "M")
                    robot.MoveForward();
                else
                    throw new Exception($"Unknown action: {action}");
            }

            return robot;
        }

        private static Direction StringToDirection(string direction)
        {
            if (direction == "N")
                return Direction.North;

            if (direction == "S")
                return Direction.South;

            if (direction == "W")
                return Direction.West;

            if (direction == "E")
                return Direction.East;

            throw new Exception("Unknown direction");
        }

        private static string DirectionToString(Direction direction)
        {
            switch (direction)
            {
                case Direction.East:
                    return "E";
                case Direction.North:
                    return "N";
                case Direction.South:
                    return "S";
                case Direction.West:
                    return "W";
                default:
                    throw new Exception("Unknown direction");
            }
        }
    }
}