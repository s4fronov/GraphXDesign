using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphXDesign
{
    public class CircleBrush : IBrush
    {
        public int BrushSize { get; set; }
        public Color BrushColor { get; set; }
        public CircleBrush(int size, Color color)
        {
            BrushSize = size;
            BrushColor = color;
        }
        public CircleBrush(IBrush brush)
        {
            BrushSize = brush.BrushSize;
            BrushColor = brush.BrushColor;
        }
        public void DrawDot(Canvas canvas, int x, int y)
        {
            //x1 y1 левый верхний угол
            //x2 y2 правый нижний
            int x1 = x - BrushSize / 2;
            int x2 = x1 + BrushSize - 1;
            int y1 = y - BrushSize / 2;
            int y2 = y1 + BrushSize - 1;

            //координаты центра
            double xCenter = (x1 + x2) / (double)2;
            double yCenter = (y1 + y2) / (double)2;
 

            //отрезаем то, что выходит за пределы битмапа
            if (x1 < 0)
                x1 = 0;
            if (x2 >= canvas.Width)
                x2 = canvas.Width - 1;
            if (y1 < 0)
                y1 = 0;
            if (y2 >= canvas.Height)
                y2 = canvas.Height - 1;

            double radius = BrushSize / (double)2;
            //заполняем с проверкой на расстояние от центра
            for (int i = x1; i <= x2; i++)
            {
                for (int j = y1; j <= y2; j++)
                {
                    if ((i - xCenter) * (i - xCenter) + (j - yCenter) * (j - yCenter) <= radius * radius)
                        canvas.SetPixel(i, j, BrushColor);
                }
            }
        }
        public void DrawLine(Canvas canvas, int x1, int y1, int x2, int y2)
        {
            int deltaX = x2 - x1;
            int deltaY = y2 - y1;

            //если 2 крайние точки совпадают просто рисую точку
            if (deltaX == 0 && deltaY == 0)
            {
                DrawDot(canvas, x1, y1);
                return;
            }

            if (Math.Abs(deltaX) >= Math.Abs(deltaY))
            {
                //идем по оси х и считаем на каждом шаге y
                int y;
                double dydx = (double)deltaY / deltaX;

                //двигаемся слева направо
                if (x1 <= x2)
                    for (int x = x1; x <= x2; x++)
                    {
                        y = (int)(Math.Round((x - x1) * dydx)) + y1;
                        DrawDot(canvas, x, y);
                    }
                //справа налево
                else
                    for (int x = x1; x >= x2; x--)
                    {
                        y = (int)(Math.Round((x - x1) * dydx)) + y1;
                        DrawDot(canvas, x, y);
                    }
            }
            else
            {
                //идем по оси y и считаем на каждом шаге x
                int x;
                double dxdy = (double)deltaX / deltaY;
                //сверху вниз
                if (y1 <= y2)
                    for (int y = y1; y <= y2; y++)
                    {
                        x = (int)(Math.Round((y - y1) * dxdy)) + x1;
                        DrawDot(canvas, x, y);
                    }
                //снизу вверх
                else
                    for (int y = y1; y >= y2; y--)
                    {
                        x = (int)(Math.Round((y - y1) * dxdy)) + x1;
                        DrawDot(canvas, x, y);
                    }
            }

        }

    }
}
