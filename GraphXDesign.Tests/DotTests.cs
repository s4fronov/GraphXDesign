using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Drawing;
using GraphXDesign;

namespace GraphXDesign.Tests
{
    [TestFixture]
    class DotTests
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

        public void DrawTest()
        {
            Bitmap expected = new Bitmap(5, 5);
            expected.SetPixel(2, 2, Color.Blue);
            expected.SetPixel(2, 3, Color.Blue);
            expected.SetPixel(3, 2, Color.Blue);
            expected.SetPixel(3, 3, Color.Blue);

            Bitmap actual = new Bitmap(5, 5);
            Dot dot = new SquareDot(3, 3, 2, Color.Blue);
            dot.Draw(actual);

            Assert.IsTrue(Equals(expected, actual));
        }

        [Test]
        public void DrawTest2()
        {
            Bitmap expected = new Bitmap(5, 5);
            expected.SetPixel(0, 0, Color.Red);
            expected.SetPixel(0, 1, Color.Red);
            expected.SetPixel(0, 2, Color.Red);
            expected.SetPixel(1, 0, Color.Red);
            expected.SetPixel(1, 1, Color.Red);
            expected.SetPixel(1, 2, Color.Red);

            Bitmap actual = new Bitmap(5, 5);
            Dot dot = new SquareDot(0, 1, 3, Color.Red);
            dot.Draw(actual);

            Assert.IsTrue(Equals(expected, actual));
        }
    }
}
