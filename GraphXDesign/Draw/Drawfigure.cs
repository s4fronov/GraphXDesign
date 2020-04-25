using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            IBrush tmpBrush = new SquareBrush(1, fill.FillColor);
            tmpBrush.DrawLine(figure.dotlist[0].X, figure.dotlist[0].Y, figure.dotlist[1].X, figure.dotlist[1].Y, true);
            for (int i = 1; i < figure.dotlist.Count - 1; i++)
            {
                tmpBrush.DrawLine(figure.dotlist[i].X, figure.dotlist[i].Y, figure.dotlist[i + 1].X, figure.dotlist[i + 1].Y);
            }
            tmpBrush.DrawLine(figure.dotlist[figure.dotlist.Count - 1].X, figure.dotlist[figure.dotlist.Count - 1].Y, figure.dotlist[0].X, figure.dotlist[0].Y);

            fill.Fill(figure.center);

            brush.DrawLine(figure.dotlist[0].X, figure.dotlist[0].Y, figure.dotlist[1].X, figure.dotlist[1].Y, true);
            for (int i = 1; i < figure.dotlist.Count - 1; i++)
            {
                brush.DrawLine( figure.dotlist [i].X, figure.dotlist[i].Y, figure.dotlist[i + 1].X, figure.dotlist[i + 1].Y);
            }
            brush.DrawLine(figure.dotlist[figure.dotlist.Count - 1].X, figure.dotlist[figure.dotlist.Count - 1].Y, figure.dotlist[0].X, figure.dotlist[0].Y);
        }
    }
}
