using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace GraphXDesign
{
    public class Canvas
    {
        //singleton pattern
        private static Canvas instance;
        List<BitmapWrap> bitmapList;
        int m;
        private Canvas() { }
        public static Canvas GetCanvas
        {
            get
            {
                if (instance == null)
                {
                    instance = new Canvas();
                }
                return instance;
            }
        }

        public void Init(int width, int height)
        {
            bitmapList = new List<BitmapWrap>();
            Bmp = new BitmapWrap(width, height);
            Cache = new BitmapWrap(width, height);
            bitmapList.Add((BitmapWrap)Bmp.Clone());
            m = bitmapList.Count - 1;
            Width = width;
            Height = height;
        }


        public BitmapWrap Bmp { get; set; }
        private BitmapWrap Cache { get; set; }

        public int Width { get; set; }
        public int Height { get; set; }

        public void SaveToCache()
        {
            //Cache = (BitmapWrap)Bmp.Clone();
            Graphics g = Graphics.FromImage(Cache.Bmp);
            g.DrawImage(Bmp.Bmp, new System.Drawing.Rectangle(0, 0, Width, Height));
        }

        public void LoadFromCache()
        {
            //Bmp = (BitmapWrap)Cache.Clone();
            Graphics g = Graphics.FromImage(Bmp.Bmp);
            g.DrawImage(Cache.Bmp, new System.Drawing.Rectangle(0, 0, Width, Height));
        }
        public void AddToBmpList()
        {
            BitmapWrap bmp = (BitmapWrap)Bmp.Clone();
            bitmapList.Add(bmp);
            m++;
        }
        public void Undo(PictureBox a)
        {
            if (m>0)
            {
                m--;
                Bmp = bitmapList[m];
                WriteToPictureBox(a);
            }
        }
        public void Redo(PictureBox a)
        {
            if (m < bitmapList.Count-1)
            {
                m++;
                Bmp = bitmapList[m];
                WriteToPictureBox(a);
            }
        }

        public Color GetPixel(int x, int y)
        {
            if (x >= 0 && x < Width)
                if (y >= 0 && y < Height)
                    return Bmp.GetPixel(x, y);
            return Color.Transparent;
        }

        //в основной битмап
        public void SetPixel(int x, int y, Color color)
        {
            if (x >= 0 && x < Width)
                if (y >= 0 && y < Height)
                    Bmp.SetPixel(x, y, color);
        }

        public void WriteToPictureBox(PictureBox pb)
        {
            pb.Image = Bmp.Bmp;
        }

        public void Fill(int x, int y, Color fillColor)
        {
            Color startingColor = GetPixel(x, y);
            if (startingColor.ToArgb() == fillColor.ToArgb())
                return;

            Point point = new Point(x, y);

            Queue<Point> pointsToCheck = new Queue<Point>();
            pointsToCheck.Enqueue(point);

            while (pointsToCheck.Count > 0)
            {
                point = new Point(pointsToCheck.Peek().X, pointsToCheck.Peek().Y);
                pointsToCheck.Dequeue();
                if (GetPixel(point.X - 1, point.Y).ToArgb() == startingColor.ToArgb())
                {
                    SetPixel(point.X - 1, point.Y, fillColor);
                    pointsToCheck.Enqueue(new Point(point.X - 1, point.Y));
                }
                if (GetPixel(point.X + 1, point.Y).ToArgb() == startingColor.ToArgb())
                {
                    SetPixel(point.X + 1, point.Y, fillColor);
                    pointsToCheck.Enqueue(new Point(point.X + 1, point.Y));
                }
                if (GetPixel(point.X, point.Y - 1).ToArgb() == startingColor.ToArgb())
                {
                    SetPixel(point.X, point.Y - 1, fillColor);
                    pointsToCheck.Enqueue(new Point(point.X, point.Y - 1));
                }
                if (GetPixel(point.X, point.Y + 1).ToArgb() == startingColor.ToArgb())
                {
                    SetPixel(point.X, point.Y + 1, fillColor);
                    pointsToCheck.Enqueue(new Point(point.X, point.Y + 1));
                }
            }

            return;
        }
    }
}
