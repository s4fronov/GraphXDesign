using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace GraphXDesign
{
    public class BitmapWrap:ICloneable
    {
        public Bitmap Bmp { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        bool isLocked;
        public BitmapWrap() { isLocked = false; }
        public BitmapWrap(int width, int height)
        {
            Bmp = new Bitmap(width, height);
            Width = width;
            Height = height;
            isLocked = false;
        }

        BitmapData bmpData;
        public void Lock()
        {
            if (!isLocked)
                bmpData = Bmp.LockBits(new System.Drawing.Rectangle(0, 0, Width, Height), ImageLockMode.ReadWrite, Bmp.PixelFormat);
            isLocked = true;
        }
        public void Unlock()
        {
            if (isLocked)
                Bmp.UnlockBits(bmpData);
            isLocked = false;
        }

        public Color GetPixel(int x, int y)
        {
            if (x >= 0 && x < Bmp.Width)
                if (y >= 0 && y < Bmp.Height)
                    if (!isLocked)
                        return Bmp.GetPixel(x, y);
                    else
                    {
                        unsafe
                        {
                            byte* currentPixel = (byte*)bmpData.Scan0 + (y * bmpData.Stride) + x * 4;
                            byte B = currentPixel[0];
                            byte G = currentPixel[1];
                            byte R = currentPixel[2];
                            byte A = currentPixel[3];
                            return Color.FromArgb(A,R,G,B);
                        }
                    }
            return Color.Transparent;
        }

        public void SetPixel(int x, int y, Color color)
        {
            if (x >= 0 && x < Bmp.Width)
                if (y >= 0 && y < Bmp.Height)
                    if (!isLocked)
                        Bmp.SetPixel(x, y, color);
                    else
                    {
                        unsafe
                        {
                            byte* currentPixel = (byte*)bmpData.Scan0 + (y * bmpData.Stride) + x * 4;
                            currentPixel[0] = color.B ;
                            currentPixel[1] = color.G ;
                            currentPixel[2] = color.R ;
                            currentPixel[3] = color.A ;
                        }
                    }
        }

        public object Clone()
        {
            BitmapWrap bitmapWrap = new BitmapWrap();
            bitmapWrap.Bmp = (Bitmap)Bmp.Clone();
            bitmapWrap.Width = Bmp.Width;
            bitmapWrap.Height = Bmp.Height;
            bitmapWrap.isLocked = false;

            return bitmapWrap;
        }
    }
}
