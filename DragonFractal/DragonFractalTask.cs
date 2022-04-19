/*
Начните с точки (1, 0)
Создайте генератор рандомных чисел с сидом seed

На каждой итерации:

1. Выберите случайно одно из следующих преобразований и примените его к текущей точке:

    Преобразование 1. (поворот на 45° и сжатие в sqrt(2) раз):
    x' = (x · cos(45°) - y · sin(45°)) / sqrt(2)
    y' = (x · sin(45°) + y · cos(45°)) / sqrt(2)

    Преобразование 2. (поворот на 135°, сжатие в sqrt(2) раз, сдвиг по X на единицу):
    x' = (x · cos(135°) - y · sin(135°)) / sqrt(2) + 1
    y' = (x · sin(135°) + y · cos(135°)) / sqrt(2)

2. Нарисуйте текущую точку методом pixels.SetPixel(x, y)

*/

// В этом пространстве имен содержатся средства для работы с изображениями. 
// Чтобы оно стало доступно, в проект был подключен Reference на сборку System.Drawing.dll
using System;
using System.Drawing;
using static System.Math;

namespace Fractals
{
	internal static class DragonFractalTask
	{
		public static void DrawDragonFractal(Pixels pixels, int iterationsCount, int seed)
		{
			Random random = new Random(seed);
			double x, y;

			x = 1.0;
			y = 0.0;
            for (int i = 0; i < iterationsCount; i++)
            {
				SetXY(random.Next(2), ref x, ref y);
				pixels.SetPixel(x, y);
			}
		}

		private static void SetXY(int option, ref double x, ref double y)
        {
			if (option == 0)
			{
				double xTemp = (x * Cos(PI / 4) - y * Sin(PI / 4)) / Sqrt(2);
				double yTemp = (x * Sin(PI / 4) + y * Cos(PI / 4)) / Sqrt(2);

				x = xTemp;
				y = yTemp;
			}
			else
			{
				double xTemp = (x * Cos(3 * PI / 4) - y * Sin(3 * PI / 4)) / Sqrt(2) + 1;
				double yTemp = (x * Sin(3 * PI / 4) + y * Cos(3 * PI / 4)) / Sqrt(2);

				x = xTemp;
				y = yTemp;
			}
		}
	}
}
