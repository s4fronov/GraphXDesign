using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace GraphXDesign
{
    public class VectorCanvas : AbstractCanvas
    {
        //singleton pattern
        private static VectorCanvas instance;
        private VectorCanvas() { }
        public static VectorCanvas GetCanvas
        {
            get
            {
                if (instance == null)
                {
                    instance = new VectorCanvas();
                }
                return instance;
            }
        }

        public List<Drawfigure> figures;

        public void Init(int width, int height)
        {
            Bmp = new BitmapWrap(width, height);
            Cache = new BitmapWrap(width, height);
            Width = width;
            Height = height;
            figures = new List<Drawfigure>();
        }
        public void RenderWrite(PictureBox pb)
        {
            Render();
            WriteToPictureBox(pb);
        }
        public void Render()
        {
            Bmp = new BitmapWrap(Width, Height);
            foreach (Drawfigure f in figures)
            {
                f.Draw(this);
            }
        }
        public void RenderExceptFigure(Drawfigure df)
        {
            Bmp = new BitmapWrap(Width, Height);
            foreach (Drawfigure f in figures)
            {
                if (df != f)
                    f.Draw(this);
            }
        }
        //===================================================== Попытка реализовать смещение вершин

        public int FindPointByPoint(Point p)
        {
            Bmp = new BitmapWrap(Width, Height);

            foreach (Drawfigure f in figures)
            {
                if (f.figure.dotlist.Contains(p))
                {
                    return f.figure.dotlist.IndexOf(p);
                }

            }
            return -1;
        }

        public Drawfigure FindFigureByPoint(Point p)
        {
            Bmp = new BitmapWrap(Width, Height);

            foreach (Drawfigure f in figures)
            {
                if (f.figure.dotlist.Contains(p))
                    return f;
            }

            return null;
        }

        public void PointChangeMode(PictureBox sheet)
        {
            SquareBrush brush = new SquareBrush(1, Color.Red);
            Square square = new Square();

            foreach (Drawfigure f in figures)
            {
                foreach (Point t in f.figure.dotlist)
                {
                    for (int i = -3; i <= 3; i++)
                    {
                        Point p1 = new Point(t.X - 3, t.Y + i);
                        Point p2 = new Point(t.X + 3, t.Y + i);
                        square.Createdotlist(p1.X, p1.Y, p2.X, p2.Y);
                        brush.DrawLine(Bmp, p1.X, p1.Y, p2.X, p2.Y, false);
                        WriteToPictureBox(sheet);

                    }
                }
            }
        }

        public void PointChangeModeofrectangle(PictureBox sheet, Drawfigure obj)
        {
            SquareBrush brush = new SquareBrush(1, Color.Blue);
            Square square = new Square();
            List<Point> rectanglelist = new List<Point>();
            rectanglelist.Add(obj.figure.cornerTopLeft);
            rectanglelist.Add(obj.figure.cornerBottomRight);
            rectanglelist.Add(obj.figure.cornerBottomLeft);
            rectanglelist.Add(obj.figure.cornerTopRight);
                                 

             foreach (Point t in rectanglelist)
                {
                    for (int i = -3; i <= 3; i++)
                    {
                        Point p1 = new Point(t.X - 3, t.Y + i);
                        Point p2 = new Point(t.X + 3, t.Y + i);
                        square.Createdotlist(p1.X, p1.Y, p2.X, p2.Y);
                        //WriteToPictureBox(sheet);
                        brush.DrawLine(Bmp, p1.X, p1.Y, p2.X, p2.Y, false);
                        WriteToPictureBox(sheet);

                    }
                }
            
        }



       
        

    }
}
