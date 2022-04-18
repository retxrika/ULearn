namespace Mazes
{
	public static class SnakeMazeTask
	{
		public static void MoveOut(Robot robot, int width, int height)
		{
            while (true)
            {
                MoveToRightToEnd(robot, width - 2);
                MoveThreeStepsDown(robot);
                MoveToLeftToStart(robot, width - 2);
                
                if (robot.Finished) break;
                
                MoveThreeStepsDown(robot);
            }
        }

        private static void MoveToRightToEnd(Robot robot, int end)
        {
            for (int i = 0; i < end - 1; i++)
                robot.MoveTo(Direction.Right);
        }

        private static void MoveToLeftToStart(Robot robot, int end)
        {
            for (int i = end; i > 1; i--)
                robot.MoveTo(Direction.Left);
        }

        private static void MoveThreeStepsDown(Robot robot)
        {
            for (int i = 0; i < 2; i++)
                robot.MoveTo(Direction.Down);
        }
	}
}