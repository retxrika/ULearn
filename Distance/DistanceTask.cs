using System;

namespace DistanceTask
{
	public static class DistanceTask
	{
		// Расстояние от точки (x, y) до отрезка AB с координатами A(ax, ay), B(bx, by)
		public static double GetDistanceToSegment(double ax, double ay, double bx, double by, double x, double y)
		{
			double areaTriangle, height, angleAlpha, angleBeta, ab, bc, ca;
			
			ab = GetLengthToSegment(ax, ay, bx, by);
			bc = GetLengthToSegment(x, y, bx, by);
			ca = GetLengthToSegment(x, y, ax, ay);

			areaTriangle = 0.25 * Math.Sqrt((ab + bc + ca) * (bc + ca - ab) 
											* (ab + ca - bc) * (ab + bc - ca));
			height = 2 * areaTriangle / ab;
			angleAlpha = Math.Acos((ab * ab + ca * ca - bc * bc) / (2 * ab * ca));
			angleBeta = Math.Acos((ab * ab + bc * bc - ca * ca) / (2 * ab * bc));

			if (angleAlpha < 1.8 && angleBeta < 1.8)
				return ab == 0 ? ca : height;
			else
				return Math.Min(bc, ca);
		}

		private static double GetLengthToSegment(double x1, double y1, double x2, double y2)
        {
			return Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));
		}
	}
}