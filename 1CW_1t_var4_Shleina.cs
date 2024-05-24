

using System;
using System.Collections.Generic;
using System.Linq;

class Triangle
{
    private double[] sides;
    private double area;

    public Triangle(double[] sides)
    {
        if (sides.Length != 3)
            Console.WriteLine("Треугольник должен иметь 3 стороны.");
        this.sides = sides;
    }

    public string GetType()
    {
        if (sides[0] == sides[1] && sides[1] == sides[2])
            return "Равносторонний";
        if (sides[0] == sides[1] || sides[1] == sides[2] || sides[2] == sides[0])
            return "Равнобедренный";
        return "Разносторонний";
    }

    public double GetArea()
    {
        if (area == 0)
        {
            double p = (sides[0] + sides[1] + sides[2]) / 2;
            area = Math.Sqrt(p * (p - sides[0]) * (p - sides[1]) * (p - sides[2]));
        }
        return area;
    }

    public override string ToString()
    {
        return $"Стороны: {string.Join(", ", sides)}\n" +
               $"Площадь: {GetArea():F2}\n" +
               $"Тип: {GetType()}";
    }
}

class Program
{
    private static void Swap(ref Triangle a, ref Triangle b)
    {
        Triangle temp = a;
        a = b;
        b = temp;
    }

    private static void BubbleSort(Triangle[] triangles, int n)
    {
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (triangles[j].GetArea() < triangles[j + 1].GetArea())
                    Swap(ref triangles[j], ref triangles[j + 1]);
            }
        }
    }

    static void Main()
    {
        Triangle[] triangles = new Triangle[]
        {
            new Triangle(new double[] { 3, 4, 5 }),
            new Triangle(new double[] { 8, 8, 10 }),
            new Triangle(new double[] { 5, 12, 13 }),
            new Triangle(new double[] { 15, 20, 25 }),
            new Triangle(new double[] { 7, 7, 9 })
        };

        BubbleSort(triangles, triangles.Length);

        Console.WriteLine("Треугольники, отсортированные по площади (по убыванию):");
        Console.WriteLine("---------------------------------------------------");
        Console.WriteLine("{0,-15}{1,-15}{2,-15}", "Стороны", "Площадь", "Тип");
        Console.WriteLine("---------------------------------------------------");
        foreach (var triangle in triangles)
        {
            Console.WriteLine(triangle);
            Console.WriteLine("---------------------------------------------------");
        }
    }
}