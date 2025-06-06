using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiPInterface
{
    public interface IShape
    {
        double Perimeter();
        double Area();
    }
    public class Shape
    {
        public string Name { get; set; }

        public Shape(string name)
        {
            Name = name;
        }
    }
    public class Circle : Shape, IShape
    {
        public double Radius { get; set; }
        public Circle(string name, double radius) : base(name)
        {
            Radius = radius;
        }
        public double Perimeter()
        {
            return 2 * Math.PI * Radius;
        }

        public double Area()
        {
            return Math.PI * Radius * Radius;
        }
    }
    public class Square : Shape, IShape
    {
        public double SideLength { get; set; }
        public Square(string name, double sideLength) : base(name)
        {
            SideLength = sideLength;
        }
        public double Perimeter()
        {
            return 4 * SideLength;
        }
        public double Area()
        {
            return SideLength * SideLength;
        }
    }
    public class Triangle : Shape, IShape
    {
        public double SideLength { get; set; }
        public Triangle(string name, double sideLength) : base(name)
        {
            SideLength = sideLength;
        }
        public double Perimeter()
        {
            return 3 * SideLength;
        }
        public double Area()
        {
            return (Math.Sqrt(3) / 4) * SideLength * SideLength;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int r, a, b;
            r = int.Parse(Console.ReadLine());
            a = int.Parse(Console.ReadLine());
            b = int.Parse(Console.ReadLine());
            Circle circle = new Circle("Круг", r);
            Square square = new Square("Квадрат", a);
            Triangle triangle = new Triangle("Треугольник", b);
            Console.WriteLine($"Периметр круга: {circle.Perimeter():F2}");
            Console.WriteLine($"Площадь круга: {circle.Area():F2}");
            Console.WriteLine($"Периметр квадрата: {square.Perimeter():F2}");
            Console.WriteLine($"Площадь квадрата: {square.Area():F2}");
            Console.WriteLine($"Периметр триугольника: {triangle.Perimeter():F2}");
            Console.WriteLine($"Площадь триугольника: {triangle.Area():F2}");
        }
    }
}
