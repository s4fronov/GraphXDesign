using System;
using System.Collections.Generic;

namespace GraphXDesign
{
    public class PathCalculator
    {
        //список точек, соединяющиз x1 y1 и x2 y2
        public List<Tuple<int, int>> CalculateLinePath(int x1, int y1, int x2, int y2)
        {
            List<Tuple<int, int>> dotList = new List<Tuple<int, int>>();
            int deltaX = x2 - x1;
            int deltaY = y2 - y1;

            dotList.Add(new Tuple<int, int>(x1, y1));

            if (deltaX == 0 && deltaY == 0)
            {
                return dotList;
            }

            if (Math.Abs(deltaX) >= Math.Abs(deltaY))
            {
                //идем по оси х и считаем на каждом шаге y
                int y;
                double dydx = (double)deltaY / deltaX;

                //двигаемся слева направо
                if (x1 <= x2)
                    for (int x = x1+1; x <= x2; x++)
                    {
                        y = (int)(Math.Round((x - x1) * dydx)) + y1;
                        dotList.Add(new Tuple<int, int>(x, y));
                    }
                //справа налево
                else
                    for (int x = x1-1; x >= x2; x--)
                    {
                        y = (int)(Math.Round((x - x1) * dydx)) + y1;
                        dotList.Add(new Tuple<int, int>(x, y));
                    }
            }
            else
            {
                //идем по оси y и считаем на каждом шаге x
                int x;
                double dxdy = (double)deltaX / deltaY;
                //сверху вниз
                if (y1 <= y2)
                    for (int y = y1+1; y <= y2; y++)
                    {
                        x = (int)(Math.Round((y - y1) * dxdy)) + x1;
                        dotList.Add(new Tuple<int, int>(x, y));
                    }
                //снизу вверх
                else
                    for (int y = y1-1; y >= y2; y--)
                    {
                        x = (int)(Math.Round((y - y1) * dxdy)) + x1;
                        dotList.Add(new Tuple<int, int>(x, y));
                    }
            }
            return dotList;
        }
    }
}
