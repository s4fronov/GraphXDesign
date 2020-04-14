using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphXDesign
{
    public class Canvas
    {
        public Bitmap Bmp { get; set; }
        private Bitmap Cache { get; set; }

        public int Width { get; set; }
        public int Height { get; set; }

        public Canvas(int width, int height)
        {
            Bmp = new Bitmap(width, height);
            Width = width;
            Height = height;
        }

        public void SaveToCache()
        {
            Cache = new Bitmap(Bmp);
        }

        public void LoadFromCache()
        {
            Bmp = new Bitmap(Cache);
        }

        /*public Color GetPixel(int x, int y)
        {

        }*/

        public void SetPixel(int x, int y, Color color)
        {
            if (x >= 0 && x < Width)
                if (y >= 0 && y < Height)
                    Bmp.SetPixel(x, y, color);
        }  
    }
}
