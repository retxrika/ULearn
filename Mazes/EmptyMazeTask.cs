namespace Mazes
{
	public static class EmptyMazeTask
	{
		public static void MoveOut(Robot robot, int width, int height)
		{
			while (!robot.Finished)
				robot.MoveTo(robot.X < width - 2 ? Direction.Right : Direction.Down);
		}
	}
}