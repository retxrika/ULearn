using System;
using System.Drawing;
using System.Drawing.Drawing2D;


namespace RefactorMe
{
    class Painter
    {
        static float x, y;
        static Graphics graphic;

        public static void Initialize(Graphics newGraphic)
        {
            graphic = newGraphic;
            graphic.SmoothingMode = SmoothingMode.None;
            graphic.Clear(Color.Black);
        }

        public static void SetPosition(float x0, float y0)
        { 
            x = x0; 
            y = y0; 
        }

        public static void DrawLine(Pen pen, double length, double angle)
        {
            //Делает шаг длиной length в направлении angle и рисует пройденную траекторию
            var x1 = (float)(x + length * Math.Cos(angle));
            var y1 = (float)(y + length * Math.Sin(angle));
            graphic.DrawLine(pen, x, y, x1, y1);
            SetPosition(x1, y1);
        }

        public static void ChangePosition(double length, double angle)
        {
            x = (float)(x + length * Math.Cos(angle));
            y = (float)(y + length * Math.Sin(angle));
        }
    }

    public class ImpossibleSquare
    {
        public static void Draw(int width, 
                                int height, 
                                double angle,
                                Graphics graphic)
        {
            Painter.Initialize(graphic);

            var minSide = Math.Min(width, height);

            var diagonalLength = Math.Sqrt(2) * (minSide * 0.375f + minSide * 0.04f) / 2;
            var x = (float)(diagonalLength * Math.Cos(Math.PI / 4 + Math.PI)) + width / 2f;
            var y = (float)(diagonalLength * Math.Sin(Math.PI / 4 + Math.PI)) + height / 2f;

            Painter.SetPosition(x, y);

            //Рисуем 1-ую сторону
            DrawSide(minSide, 0);

            //Рисуем 2-ую сторону
            DrawSide(minSide, -Math.PI / 2);

            //Рисуем 3-ю сторону
            DrawSide(minSide, Math.PI);

            //Рисуем 4-ую сторону
            DrawSide(minSide, Math.PI / 2);
        }

        private static void DrawSide(int minSide, double angle)
        {
            Painter.DrawLine(Pens.Yellow, minSide * 0.375f, angle);
            Painter.DrawLine(Pens.Yellow, minSide * 0.04f * Math.Sqrt(2), angle + Math.PI / 4);
            Painter.DrawLine(Pens.Yellow, minSide * 0.375f, angle + Math.PI);
            Painter.DrawLine(Pens.Yellow, minSide * 0.375f - minSide * 0.04f, angle + Math.PI / 2);

            Painter.ChangePosition(minSide * 0.04f, angle - Math.PI);
            Painter.ChangePosition(minSide * 0.04f * Math.Sqrt(2), angle + 3 * Math.PI / 4);
        }
    }
}