using NUnit.Framework;
using GraphXDesign;
using System.Collections.Generic;
using System.Drawing;
using System;
using System.Linq.Expressions;
using NUnit.Framework.Constraints;
using System.Numerics;

namespace GraphXDesignTestMath
{
    public class Tests
    {
        public int[] ReturnArray(List<Point> dotlist)
        {
            int[] array = new int[dotlist.Count * 2];
            for (int i = 0, j = 0; (i < dotlist.Count * 2 && j < dotlist.Count); i += 2, j++)
            {
                array[i] = dotlist[j].X;
                array[i + 1] = dotlist[j].Y;
            }
            return array;
        }

        [TestCase(1, 1, 4, 2, ExpectedResult = new int[] { 1, 1, 4, 1, 4, 2, 1, 2 })]
        [TestCase(0, 0, 0, 0, ExpectedResult = new int[] { 0, 0, 0, 0, 0, 0, 0, 0 })]
        [TestCase(-1, -1, 0, 0, ExpectedResult = new int[] { -1, -1, 0, -1, 0, 0, -1, 0 })]
        public int[] RectangleTest(int x1, int y1, int x2, int y2)
        {
            GraphXDesign.Rectangle a = new GraphXDesign.Rectangle();
            a.Createdotlist(x1, y1, x2, y2);
            List<Point> actual = a.dotlist;
            return ReturnArray(actual);
        }

        [TestCase(1, 1, 4, 2, ExpectedResult = new int[] { 1, 1, 2, 1, 2, 2, 1, 2 })]
        [TestCase(0, 0, 0, 0, ExpectedResult = new int[] { 0, 0, 0, 0, 0, 0, 0, 0 })]
        [TestCase(-1, -1, 0, 0, ExpectedResult = new int[] { -1, -1, 0, -1, 0, 0, -1, 0 })]
        public int[] SquareTest(int x1, int y1, int x2, int y2)
        {
            GraphXDesign.Square a = new GraphXDesign.Square();
            a.Createdotlist(x1, y1, x2, y2);
            List<Point> actual = a.dotlist;
            return ReturnArray(actual);
        }

        [TestCase(1, 1, 2, 2, ExpectedResult = new int[] { 1, 1, 2, 2, 1, 2 })]
        [TestCase(0, 0, 0, 0, ExpectedResult = new int[] { 0, 0, 0, 0, 0, 0 })]
        [TestCase(-1, -1, 0, 0, ExpectedResult = new int[] { -1, -1, 0, 0, -1, 0 })]
        public int[] TriangleRectangularTest(int x1, int y1, int x2, int y2)
        {
            TriangleRectangular a = new TriangleRectangular();
            a.Createdotlist(x1, y1, x2, y2);
            List<Point> actual = a.dotlist;
            return ReturnArray(actual);
        }

        [TestCase(5, 5, 7, 8, ExpectedResult = new int[] { 5, 5, 7, 8, 3, 8 })]
        [TestCase(0, 0, 0, 0, ExpectedResult = new int[] { 0, 0, 0, 0, 0, 0 })]
        [TestCase(-1, -1, 0, 0, ExpectedResult = new int[] { -1, -1, 0, 0, -2, 0 })]
        public int[] TrianglesamesizesTest(int x1, int y1, int x2, int y2)
        {
            Trianglesamesizes a = new Trianglesamesizes();
            a.Createdotlist(x1, y1, x2, y2);
            List<Point> actual = a.dotlist;
            return ReturnArray(actual);
        }

        [TestCase(3, 5, 2, 7, ExpectedResult = true)]
        [TestCase(2, 2, 2, 7, ExpectedResult = false)]
        public bool EllipsTest(int x1, int y1, int x2, int y2)
        {
            Ellips a = new Ellips();
            a.Createdotlist(x1, y1, x2, y2);
            List<Point> tmp = a.dotlist;
            bool actual = false;
            if (tmp.Contains(new Point(2, 4)) && tmp.Contains(new Point(3, 7)) && tmp.Contains(new Point(4, 5)) && tmp.Contains(new Point(2, 6)))
            { actual = true; }
            return actual;
        }

        [TestCase(4, 4, 6, 4, ExpectedResult = true)]
        [TestCase(0, 0, 0, 0, ExpectedResult = false)]
        public bool CircleTest(int x1, int y1, int x2, int y2)
        {
            Circle a = new Circle();
            a.Createdotlist(x1, y1, x2, y2);
            List<Point> tmp = a.dotlist;
            bool actual = false;
            if (tmp.Contains(new Point(4, 2)) && tmp.Contains(new Point(6, 4)) && tmp.Contains(new Point(2, 4)) && tmp.Contains(new Point(4, 6)) && tmp.Contains(new Point(5, 2)) && tmp.Contains(new Point(3, 3)))
            { actual = true; }
            return actual;
        }
        [TestCase(4, 4, 6, 4, ExpectedResult = true)]
        [TestCase(0, 0, 0, 0, ExpectedResult = false)]
        public bool N_gonTest(int x1, int y1, int x2, int y2)
        {
            N_gon a = new N_gon(8);
            a.Createdotlist(x1, y1, x2, y2);
            List<Point> tmp = a.dotlist;
            bool actual = false;
            if (tmp.Contains(new Point(4, 6)) && tmp.Contains(new Point(3, 5)) && tmp.Contains(new Point(2, 4)) && tmp.Contains(new Point(3, 3)) && tmp.Contains(new Point(4, 2)) && tmp.Contains(new Point(5, 3)) && tmp.Contains(new Point(6, 4)) && tmp.Contains(new Point(5, 5)))
            { actual = true; }
            return actual;
        }

        [TestCase(0, 0, 2, 3, ExpectedResult = 13)]
        [TestCase(-4, -4, -1, -1, ExpectedResult = 18)]
        [TestCase(-3, 2, 1, -3, ExpectedResult = 41)]
        [TestCase(0, 0, 0, 0, ExpectedResult = 0)]
        public double DistanceSquaredTest(int x1, int y1, int x2, int y2)
        {
            double actual;
            Point a, b;
            IFigure figure = new Square();
            a = new Point(x1, y1);
            b = new Point(x2, y2);
            actual = figure.distanceSquared(a, b);
            return actual;
        }

        [TestCase(0, 0, 5, 0, 1, 3, ExpectedResult = new double[] { 1, 0 })]
        [TestCase(0, 0, 6, 6, 6, 0, ExpectedResult = new double[] { 3, 3 })]
        [TestCase(2, 2, 2, 10, 3, 12, ExpectedResult = new double[] { 2, 12 })]
        public double[] PerpendicularIntersectionTest(int ax, int ay, int bx, int by, int px, int py)
        {
            Point actual;
            Point a, b, p;
            IFigure figure = new Square();
            a = new Point(ax, ay);
            b = new Point(bx, by);
            p = new Point(px, py);
            actual = figure.PerpendicularIntersection(a, b, p);
            return new double[] { actual.X, actual.Y };
        }

        [TestCase(0, 0, 5, 0, 2, 0, ExpectedResult = true)]
        [TestCase(0, 0, 5, 0, 5, 0, ExpectedResult = true)]
        [TestCase(0, 0, 5, 0, 6, 0, ExpectedResult = false)]
        [TestCase(2, 2, 6, 10, 3, 4, ExpectedResult = true)]
        [TestCase(2, 2, 6, 10, 1, 0, ExpectedResult = false)]
        public bool IsInsideLineSegmentTest(int ax, int ay, int bx, int by, int px, int py)
        {
            bool actual;
            Point a, b, p;
            IFigure figure = new Square();
            a = new Point(ax, ay);
            b = new Point(bx, by);
            p = new Point(px, py);
            actual = figure.IsInsideLineSegment(a, b, p);
            return actual;
        }
    }
}