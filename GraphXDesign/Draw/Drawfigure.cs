using System.Drawing;

namespace GraphXDesign
{
    public class Drawfigure

    {
        public IFigure figure;
        public IBrush brush;
        public IFill fill;

        public  Drawfigure(IFigure figure, IBrush brush, IFill fill)
        {
            this.figure = (IFigure)figure.Clone();
            this.brush = (IBrush)brush.Clone();
            this.fill = (IFill)fill.Clone();
        }

        public void Draw(AbstractCanvas canvas)
        {
            //случай линии
            if (figure.dotlist.Count == 2)
            {
                Drawline drawer = new Drawline(figure.dotlist[0].X, figure.dotlist[0].Y, figure.dotlist[1].X, figure.dotlist[1].Y, brush, true);
                drawer.Draw(canvas);
                return;
            }

            BitmapWrap tmp = new BitmapWrap(canvas.Width, canvas.Height);
            tmp.Lock();

            IBrush tmpBrush = new SquareBrush(1, fill.FillColor);
            tmpBrush.DrawLine(tmp, figure.dotlist[0].X, figure.dotlist[0].Y, figure.dotlist[1].X, figure.dotlist[1].Y, true);
            for (int i = 1; i < figure.dotlist.Count - 1; i++)
            {
                tmpBrush.DrawLine(tmp, figure.dotlist[i].X, figure.dotlist[i].Y, figure.dotlist[i + 1].X, figure.dotlist[i + 1].Y);
            }
            tmpBrush.DrawLine(tmp, figure.dotlist[figure.dotlist.Count - 1].X, figure.dotlist[figure.dotlist.Count - 1].Y, figure.dotlist[0].X, figure.dotlist[0].Y);

            if(figure.IsInside(figure.center))
                fill.Fill(tmp, figure.center);

            if (!(fill is OnlyFill))
            {
                brush.DrawLine(tmp, figure.dotlist[0].X, figure.dotlist[0].Y, figure.dotlist[1].X, figure.dotlist[1].Y, true);
                for (int i = 1; i < figure.dotlist.Count - 1; i++)
                {
                    brush.DrawLine(tmp, figure.dotlist[i].X, figure.dotlist[i].Y, figure.dotlist[i + 1].X, figure.dotlist[i + 1].Y);
                }
                brush.DrawLine(tmp, figure.dotlist[figure.dotlist.Count - 1].X, figure.dotlist[figure.dotlist.Count - 1].Y, figure.dotlist[0].X, figure.dotlist[0].Y);
            }

            tmp.Unlock();
            Graphics g = Graphics.FromImage(canvas.Bmp.Bmp);
            g.DrawImage(tmp.Bmp, new System.Drawing.Rectangle(0, 0, canvas.Width, canvas.Height));
        }
    }
}
