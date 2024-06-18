using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace Variant_2
{
    public class Task1
    {
        private Point[] _points;

        public Task1(Point[] points)
        {
            _points = points;
        }

        public Point[] Points { get { return _points; } }

        public override string ToString()
        {
            string result = "";
            foreach (Point point in _points)
            {
                result += point.ToString() + "\n";
            }
            return result;
        }

        public void Sorting()
        {
            Array.Sort(_points, (p1, p2) => p1.DistanceFromOrigin().CompareTo(p2.DistanceFromOrigin()));
        }

        public static string GetPointsInfo(Point point1, Point point2)
        {
            return $"Точка 1: {point1}\n" +
                   $"Точка 2: {point2}\n" +
                   $"Расстояние между точками: {point1.Length(point2):F}";
        }

        public struct Point
        {
            private double _x;
            private double _y;

            public Point(double[] coordinates)
            {
                _x = coordinates[0];
                _y = coordinates[1];
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
    }

    
}

