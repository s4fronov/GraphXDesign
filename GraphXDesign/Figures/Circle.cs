﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace GraphXDesign
{
    public class Circle : IFigure
    {
     
        public override void Createdotlist(int x1, int y1, int x2, int y2)
        {
            dotlist = new List<Point>();
            int n = 360;
            int delx;
            int dely;
            if (x2 >= x1)
            {
                delx = Math.Abs(x1 - x2);
                dely = Math.Abs(y1 - y2);
            }
            else
            {
                delx = Math.Abs(x2 - x1);
                dely = Math.Abs(y2 - y1);
            }
            double r = Math.Sqrt(Math.Pow(delx, 2) + Math.Pow(dely, 2));
            for (int i = 1; i <= n + 1; i++)
            {
                double angle = Math.PI * 2 / n * i;
                int xd = Convert.ToInt32(Math.Cos(angle) * delx - Math.Sin(angle) * dely + x1); // круг
                int yd = Convert.ToInt32(Math.Cos(angle) * dely + Math.Sin(angle) * delx + y1);
               
                dotlist.Add(new Point(xd, yd));
            }
           
        }

    }
}
