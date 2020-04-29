using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace GraphXDesign
{
    public abstract class AbstractCanvas
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public BitmapWrap Bmp { get; set; }
        protected BitmapWrap Cache { get; set; }

        public void WriteToPictureBox(PictureBox pb)
        {
            pb.Image = Bmp.Bmp;
        }

        public void SaveToCache()
        {
            Cache = (BitmapWrap)Bmp.Clone();
            //Graphics g = Graphics.FromImage(Cache.Bmp);
            //g.DrawImage(Bmp.Bmp, new System.Drawing.Rectangle(0, 0, Width, Height));
        }

        public void LoadFromCache()
        {
            Bmp = (BitmapWrap)Cache.Clone();
            //Graphics g = Graphics.FromImage(Bmp.Bmp);
            //g.DrawImage(Cache.Bmp, new System.Drawing.Rectangle(0, 0, Width, Height));
        }
        public void PointChangeMode(PictureBox sheet)
        { }
    }
}
