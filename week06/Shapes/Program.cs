using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        List<Shape> shapes = new List<Shape>();
        Square square = new Square("Red", 5);
        Rectangle rectangle = new Rectangle("Blue", 4, 6);
        Circle circle = new Circle("Green", 3);

        shapes.Add(square);
        shapes.Add(rectangle);
        shapes.Add(circle);  

        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"Shape Color: {shape.Color}");
            Console.WriteLine($"Area: {shape.GetArea() :F2}\n");
        }
    }
}