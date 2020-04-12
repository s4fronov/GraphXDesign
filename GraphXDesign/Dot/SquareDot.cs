using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphXDesign
{
    public class SquareDot:Dot
    {
        public SquareDot(int x, int y, int size, Color colour) : base(x, y, size, colour) { }

        public override void Draw(Bitmap bmp)
        {
            //x1 y1 левый верхний угол
            //x2 y2 правый нижний
            int x1 = X - Size / 2;
            int x2 = x1 + Size - 1;
            int y1 = Y - Size / 2;
            int y2 = y1 + Size - 1;

            //отрезаем то, что выходит за пределы битмапа
            if (x1 < 0) 
                x1 = 0;
            if (x2 >= bmp.Width)
                x2 = bmp.Width - 1;
            if (y1 < 0)
                y1 = 0;
            if (y2 >= bmp.Height)
                y2 = bmp.Height - 1;

            //заполняем
            for (int x = x1; x <= x2; x++)
            {
                for (int y = y1; y <= y2; y++)
                {
                    bmp.SetPixel(x, y, Colour);
                }
            }
        }
    }
}
