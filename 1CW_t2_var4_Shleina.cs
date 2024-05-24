using System;

public abstract class Shape
{
    public abstract double CalculateArea();
    public abstract double CalculatePerimeter();
}

public class Round : Shape
{
    private double Radius;

    public Round(double radius)
    {
        Radius = radius;
    }

    public override double CalculateArea()
    {
        return Math.PI * Radius * Radius;
    }

    public override double CalculatePerimeter()
    {
        return 2 * Math.PI * Radius;
    }
}

public class Square : Shape
{
    private double Side;

    public Square(double side)
    {
        Side = side;
    }

    public override double CalculateArea()
    {
        return Side * Side;
    }

    public override double CalculatePerimeter()
    {
        return 4 * Side;
    }
}

public class Triangle : Shape
{
    private double SideA;
    private double SideB;
    private double SideC;

    public Triangle(double sideA, double sideB, double sideC)
    {
        SideA = sideA;
        SideB = sideB;
        SideC = sideC;
    }

    public override double CalculateArea()
    {
        double p = (SideA + SideB + SideC) / 2;
        return Math.Sqrt(p * (p - SideA) * (p - SideB) * (p - SideC));
    }

    public override double CalculatePerimeter()
    {
        return SideA + SideB + SideC;
    }
}

class Program
{
    static void Main(string[] args)
    {
       
        Round[] rounds = new Round[]
        {
            new Round(5),
            new Round(3),
            new Round(7),
            new Round(2),
            new Round(8)
        };

        Square[] squares = new Square[]
        {
            new Square(4),
            new Square(2),
            new Square(6),
            new Square(1),
            new Square(9)
        };

        Triangle[] triangles = new Triangle[]
        {
            new Triangle(3, 4, 5),
            new Triangle(5, 5, 5),
            new Triangle(7, 8, 9),
            new Triangle(2, 2, 3),
            new Triangle(10, 10, 15)
        };

        Array.Sort(rounds, (r1, r2) => r2.CalculateArea().CompareTo(r1.CalculateArea()));
        Array.Sort(squares, (s1, s2) => s2.CalculateArea().CompareTo(s1.CalculateArea()));
        Array.Sort(triangles, (t1, t2) => t2.CalculateArea().CompareTo(t1.CalculateArea()));

        Console.WriteLine("Таблица кругов:");
        PrintShapeTable(rounds);
        Console.WriteLine("Таблица квадратов:");
        PrintShapeTable(squares);
        Console.WriteLine("Таблица треугольников:");
        PrintShapeTable(triangles);

        Shape[] allShapes = new Shape[rounds.Length + squares.Length + triangles.Length];
        Array.Copy(rounds, 0, allShapes, 0, rounds.Length);
        Array.Copy(squares, 0, allShapes, rounds.Length, squares.Length);
        Array.Copy(triangles, 0, allShapes, rounds.Length + squares.Length, triangles.Length);

        Array.Sort(allShapes, (s1, s2) => s2.CalculateArea().CompareTo(s1.CalculateArea()));

    
        Console.WriteLine("Таблица всех фигур:");
        PrintShapeTable(allShapes);
    }

    static void PrintShapeTable(Shape[] shapes)
    {
        Console.WriteLine("------------------------");
        Console.WriteLine("Тип | Периметр | Площадь");
        Console.WriteLine("------------------------");
        for (int i = 0; i < shapes.Length; i++)
        {
            Console.WriteLine("{0} | {1:F2} | {2:F2}",
                shapes[i].GetType().Name, shapes[i].CalculatePerimeter(), shapes[i].CalculateArea());
        }
        Console.WriteLine();
    }
}
