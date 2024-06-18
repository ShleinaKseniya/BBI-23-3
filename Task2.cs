using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Variant_2
{
    public class Task2
    {
        private Fourangle[] _fourangles;

        public Task2(Fourangle[] fourangles)
        {
            _fourangles = fourangles;
        }

        public Fourangle[] Fourangles { get { return _fourangles; } }

        public void Sorting()
        {
            Array.Sort(_fourangles, (f1, f2) => f2.Area().CompareTo(f1.Area()));
        }

        public override string ToString()
        {
            string result = "";
            foreach (Fourangle fourangle in _fourangles)
            {
                result += fourangle.ToString() + "\n";
            }
            return result;
        }

      

        public struct Point
        {
            private double _x;
            private double _y;

            public Point(double[] coordinates)
            {
                if (coordinates.Length == 2)
                {
                    _x = coordinates[0];
                    _y = coordinates[1];
                }
            }

            public double X { get { return _x; } }
            public double Y { get { return _y; } }

            public double Length(Point other)
            {
                return Math.Round(Math.Sqrt(Math.Pow(other._x - _x, 2) + Math.Pow(other._y - _y, 2)), 3);
            }

            public double DistanceFromOrigin()
            {
                return Math.Sqrt(_x * _x + _y * _y);
            }

            public override string ToString()
            {
                return $"x = {_x}, y = {_y}";
            }
        }

        public abstract class Fourangle
        {
            protected Point[] _points;

            public Fourangle(Point[] points)
            {
                if (points.Length != 4)
                {
                    _points = new Point[4];
                }
                else
                {
                    _points = points;
                }
            }

            public abstract double Length();
            public abstract double Area();

            public override string ToString()
            {
                return $"{GetType().Name} with P = {Length():F3}, S = {Area():F3}";
            }
        }

        public class Square : Fourangle
        {
            public Square(Point[] points) : base(points) { }

            public override double Length()
            {
                double side = _points[0].Length(_points[1]);
                return side * 4;
            }

            public override double Area()
            {
                double side = _points[0].Length(_points[1]);
                return side * side;
            }
        }

        public class Rectangle : Fourangle
        {
            public Rectangle(Point[] points) : base(points) { }

            public override double Length()
            {
                double side1 = _points[0].Length(_points[1]);
                double side2 = _points[1].Length(_points[2]);
                return (side1 + side2) * 2;
            }

            public override double Area()
            {
                double side1 = _points[0].Length(_points[1]);
                double side2 = _points[1].Length(_points[2]);
                return side1 * side2;
            }
        }
    }


}

