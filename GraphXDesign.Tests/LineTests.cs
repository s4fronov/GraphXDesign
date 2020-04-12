using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Drawing;

namespace GraphXDesign.Tests
{
    [TestFixture]
    class LineTests
    {
        static bool Equals(Bitmap bmp1, Bitmap bmp2)
        {
            if (!bmp1.Size.Equals(bmp2.Size))
            {
                return false;
            }
            for (int x = 0; x < bmp1.Width; x++)
            {
                for (int y = 0; y < bmp1.Height; y++)
                {
                    if (bmp1.GetPixel(x, y) != bmp2.GetPixel(x, y))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        [Test]
        public void DrawTest()
        {
            Bitmap expected = new Bitmap(10, 5);
            expected.SetPixel(2, 1, Color.Blue);
            expected.SetPixel(3, 1, Color.Blue);
            expected.SetPixel(4, 2, Color.Blue);
            expected.SetPixel(5, 2, Color.Blue);
            expected.SetPixel(6, 3, Color.Blue);
            expected.SetPixel(7, 3, Color.Blue);
            expected.SetPixel(8, 4, Color.Blue);
            expected.SetPixel(9, 4, Color.Blue);
            

            Bitmap actual = new Bitmap(10, 5);
            Line line = new Line(2, 1, 9, 4, 1, Color.Blue);

            IBrush dotDrawer = new SquareBrush();
            line.Draw(actual, dotDrawer);

            Assert.IsTrue(Equals(expected, actual));
        }

        [Test]
        public void DrawTest2()
        {
            Bitmap expected = new Bitmap(10, 5);
            expected.SetPixel(2, 4, Color.Blue);
            expected.SetPixel(3, 4, Color.Blue);
            expected.SetPixel(4, 3, Color.Blue);
            expected.SetPixel(5, 3, Color.Blue);
            expected.SetPixel(6, 2, Color.Blue);
            expected.SetPixel(7, 2, Color.Blue);
            expected.SetPixel(8, 1, Color.Blue);
            expected.SetPixel(9, 1, Color.Blue);


            Bitmap actual = new Bitmap(10, 5);
            Line line = new Line(9, 1, 2, 4, 1, Color.Blue);

            IBrush dotDrawer = new SquareBrush();
            line.Draw(actual, dotDrawer);

            Assert.IsTrue(Equals(expected, actual));
        }

        [Test]
        public void DrawTest3()
        {
            Bitmap expected = new Bitmap(5, 10);
            expected.SetPixel(1, 2, Color.Blue);
            expected.SetPixel(1, 3, Color.Blue);
            expected.SetPixel(2, 4, Color.Blue);
            expected.SetPixel(2, 5, Color.Blue);
            expected.SetPixel(3, 6, Color.Blue);
            expected.SetPixel(3, 7, Color.Blue);
            expected.SetPixel(4, 8, Color.Blue);
            expected.SetPixel(4, 9, Color.Blue);


            Bitmap actual = new Bitmap(5, 10);
            Line line = new Line(4, 9, 1, 2, 1, Color.Blue);

            IBrush dotDrawer = new SquareBrush();
            line.Draw(actual, dotDrawer);

            Assert.IsTrue(Equals(expected, actual));
        }

        [Test]
        public void DrawTest4()
        {
            Bitmap expected = new Bitmap(3, 3);
            expected.SetPixel(1, 2, Color.Blue);

            Bitmap actual = new Bitmap(3, 3);
            Line line = new Line(1, 2, 1, 2, 1, Color.Blue);

            IBrush dotDrawer = new SquareBrush();
            line.Draw(actual, dotDrawer);

            Assert.IsTrue(Equals(expected, actual));
        }
    }
}
