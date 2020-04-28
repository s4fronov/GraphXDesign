using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace GraphXDesign
{
    public class VectorCanvas:AbstractCanvas
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

        List<Drawfigure> figures;

        public void Init(int width, int height)
        {
            Bmp = new BitmapWrap(width, height);
            Cache = new BitmapWrap(width, height);
            Width = width;
            Height = height;
            figures = new List<Drawfigure>();
        }

        public void Render()
        {
            foreach(Drawfigure f in figures)
            {
                f.Draw(this);
            }
        }

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

        public Color GetPixel(int x, int y)
        {
            if (x >= 0 && x < Width)
                if (y >= 0 && y < Height)
                    return Bmp.GetPixel(x, y);
            return Color.Transparent;
        }

        public void WriteToPictureBox(PictureBox pb)
        {
            pb.Image = Bmp.Bmp;
        }
    }
}
