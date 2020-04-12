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
        public void Draw(Bitmap bmp, int x, int y, int size, Color color)
        {
            //x1 y1 левый верхний угол
            //x2 y2 правый нижний
            int x1 = x - size / 2;
            int x2 = x1 + size - 1;
            int y1 = y - size / 2;
            int y2 = y1 + size - 1;

            //координаты центра
            double xCenter = (x1 + x2) / (double)2;
            double yCenter = (y1 + y2) / (double)2;
 

            //отрезаем то, что выходит за пределы битмапа
            if (x1 < 0)
                x1 = 0;
            if (x2 >= bmp.Width)
                x2 = bmp.Width - 1;
            if (y1 < 0)
                y1 = 0;
            if (y2 >= bmp.Height)
                y2 = bmp.Height - 1;

            double radius = size / (double)2;
            //заполняем с проверкой на расстояние от центра
            for (int i = x1; i <= x2; i++)
            {
                for (int j = y1; j <= y2; j++)
                {
                    if ((i - xCenter) * (i - xCenter) + (j - yCenter) * (j - yCenter) <= radius * radius)
                        bmp.SetPixel(i, j, color);
                }
            }
        }
    }
}
