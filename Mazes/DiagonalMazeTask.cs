using System;

namespace Mazes
{
	public static class DiagonalMazeTask
	{
		// 30 11
		// 7 13
		// 11 12
		public static void MoveOut(Robot robot, int width, int height)
		{
            SetDirections(width, height, out Direction mainDir, out Direction secDir);
            int countSteps = GetCountSteps(width, height);

            while (true)
            {
                MoveToEnd(robot, mainDir, countSteps);
                if (robot.Finished) break;
                MoveToEnd(robot, secDir, 1);
            }
        }

		private static void MoveToEnd(Robot robot, Direction dir, int end)
        {
            for (int i = 0; i < end; i++)
				robot.MoveTo(dir);
        }

        private static void SetDirections(int width, int height, 
                                          out Direction mainDir, 
                                          out Direction secDir)
        {
            mainDir = (width > height) ? Direction.Right : Direction.Down;
            secDir = (mainDir == Direction.Right) ? Direction.Down : Direction.Right;
        }

        private static int GetCountSteps(int width, int height)
        {
            return (int)Math.Round((double)Math.Max(width, height) / Math.Min(width, height));
        }
	}
}