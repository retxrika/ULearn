using System;

namespace Rectangles
{
	public static class RectanglesTask
	{
		// Пересекаются ли два прямоугольника (пересечение только по границе также считается пересечением)
		public static bool AreIntersected(Rectangle r1, Rectangle r2)
		{
			return !(r2.Left > r1.Left + r1.Width
					|| r1.Left > r2.Left + r2.Width
					|| r2.Top > r1.Top + r1.Height
					|| r1.Top > r2.Top + r2.Height);
		}

		// Площадь пересечения прямоугольников
		public static int IntersectionSquare(Rectangle r1, Rectangle r2)
		{
			if (!AreIntersected(r1, r2))
				return 0;

			int left = Math.Max(r1.Left, r2.Left);
			int top = Math.Min(r1.Top + r1.Height, r2.Top + r2.Height);
			int right = Math.Min(r1.Left + r1.Width, r2.Left + r2.Width);
			int bottom = Math.Max(r1.Top, r2.Top);

			int height = right - left;
			int width = top - bottom;

			return height * width;
		}

		// Если один из прямоугольников целиком находится внутри другого — вернуть номер (с нуля) внутреннего.
		// Иначе вернуть -1
		// Если прямоугольники совпадают, можно вернуть номер любого из них.
		public static int IndexOfInnerRectangle(Rectangle r1, Rectangle r2)
		{
			Rectangle minRec, maxRec;

			MinMaxRec(r1, r2, out minRec, out maxRec);

			/// Если площадь одного из прямоугольников равна нулю проверяем 
			/// две точки на нахождение в другом прямоугольнике.
			if (AreIntersected(new Rectangle(minRec.Left, minRec.Top, 0, 0), maxRec)
				&& AreIntersected(new Rectangle(minRec.Left + minRec.Width, 
												minRec.Top + minRec.Height, 0, 0), maxRec))
			{
				if (minRec == r1)
					return 0;
				else
					return 1;
			}

			return -1;
		}

		private static void MinMaxRec(Rectangle r1, Rectangle r2, 
										   out Rectangle minRec, out Rectangle maxRec)
        {
			if (r1.Width * r1.Height < r2.Width * r2.Height)
			{
				minRec = r1;
				maxRec = r2;
			}
			else
            {
				minRec = r2;
				maxRec = r1;
            }
        }
	}
}