using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphXDesign
{
    public class Drawfigure:IDraw

    {
        IFigure figure;
        IBrush brush;
        IFill fill;

        public  Drawfigure(IFigure figure, IBrush brush, IFill fill)
        {
            this.figure = figure;
            this.brush = brush;
            this.fill = fill;
        }

        public void Draw()
        {
            Bitmap tmp = new Bitmap(Canvas.GetCanvas.Width, Canvas.GetCanvas.Height);

            IBrush tmpBrush = new SquareBrush(1, fill.FillColor);
            tmpBrush.DrawLine(tmp, figure.dotlist[0].X, figure.dotlist[0].Y, figure.dotlist[1].X, figure.dotlist[1].Y, true);
            for (int i = 1; i < figure.dotlist.Count - 1; i++)
            {
                tmpBrush.DrawLine(tmp, figure.dotlist[i].X, figure.dotlist[i].Y, figure.dotlist[i + 1].X, figure.dotlist[i + 1].Y);
            }
            tmpBrush.DrawLine(tmp, figure.dotlist[figure.dotlist.Count - 1].X, figure.dotlist[figure.dotlist.Count - 1].Y, figure.dotlist[0].X, figure.dotlist[0].Y);

            fill.Fill(tmp, figure.center);

            brush.DrawLine(tmp, figure.dotlist[0].X, figure.dotlist[0].Y, figure.dotlist[1].X, figure.dotlist[1].Y, true);
            for (int i = 1; i < figure.dotlist.Count - 1; i++)
            {
                brush.DrawLine(tmp, figure.dotlist [i].X, figure.dotlist[i].Y, figure.dotlist[i + 1].X, figure.dotlist[i + 1].Y);
            }
            brush.DrawLine(tmp, figure.dotlist[figure.dotlist.Count - 1].X, figure.dotlist[figure.dotlist.Count - 1].Y, figure.dotlist[0].X, figure.dotlist[0].Y);

            Graphics g = Graphics.FromImage(Canvas.GetCanvas.Bmp);
            g.DrawImage(tmp, new System.Drawing.Rectangle(0, 0, Canvas.GetCanvas.Width, Canvas.GetCanvas.Height));
        }
    }
}
