using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphXDesign
{
    public class Line
    {
        public int X1 { get; set; }
        public int Y1 { get; set; }
        public int X2 { get; set; }
        public int Y2 { get; set; }
        public int Size { get; set; }
        public Color Colour { get; set; }

        public Line(int x1, int y1, int x2, int y2, int size, Color colour)
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
            Size = size;
            Colour = colour;
        }

        //пока не соединяет точки, просто прорисовывает обе
        public void Draw(Bitmap bmp, IBrush brush)
        {
            Dot tmp = new Dot(X1, Y1, Size, Colour);

            int deltaX = X2 - X1;
            int deltaY = Y2 - Y1;

            //если 2 крайние точки совпадают просто рисую точку
            if (deltaX == 0 && deltaY == 0)
            {
                tmp.Draw(bmp, brush);
                return;
            }

            if (Math.Abs(deltaX) >= Math.Abs(deltaY))
            {
                //идем по оси х и считаем на каждом шаге y
                int y;

                //двигаемся слева направо
                if (X1 <= X2)
                    for (int x = X1; x <= X2; x++)
                    {
                        y = (int)(Math.Round((x - X1) * ((double)deltaY / deltaX))) + Y1;
                        tmp.X = x;
                        tmp.Y = y;
                        tmp.Draw(bmp, brush);
                    }
                //справа налево
                else
                    for (int x = X1; x >= X2; x--)
                    {
                        y = (int)(Math.Round((x - X1) * ((double)deltaY / deltaX))) + Y1;
                        tmp.X = x;
                        tmp.Y = y;
                        tmp.Draw(bmp, brush);
                    }                
            }
            else
            {
                //идем по оси y и считаем на каждом шаге x
                int x;
                //сверху вниз
                if (Y1 <= Y2)
                    for (int y = Y1; y <= Y2; y++)
                    {
                        x = (int)(Math.Round((y - Y1) * ((double)deltaX / deltaY))) + X1;
                        tmp.X = x;
                        tmp.Y = y;
                        tmp.Draw(bmp, brush);
                    }
                //снизу вверх
                else
                    for (int y = Y1; y >= Y2; y--)
                    {
                        x = (int)(Math.Round((y - Y1) * ((double)deltaX / deltaY))) + X1;
                        tmp.X = x;
                        tmp.Y = y;
                        tmp.Draw(bmp, brush);
                    }
            }
        }
    }
}
