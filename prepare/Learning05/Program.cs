using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create individual shapes
        Square square = new Square("Red", 5f);
        Rectangle rectangle = new Rectangle("Blue", 4f, 6f);
        Circle circle = new Circle("Green", 3f);

        // Display individual test results
        Console.WriteLine($"Square Color: {square.GetColor()}, Area: {square.GetArea()}");
        Console.WriteLine($"Rectangle Color: {rectangle.GetColor()}, Area: {rectangle.GetArea()}");
        Console.WriteLine($"Circle Color: {circle.GetColor()}, Area: {circle.GetArea()}");

        // Create a list of shapes
        List<Shape> shapes = new List<Shape>();
        shapes.Add(square);
        shapes.Add(rectangle);
        shapes.Add(circle);

        Console.WriteLine();
        Console.WriteLine("Iterating through list of shapes:");

        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"Shape Color: {shape.GetColor()}, Area: {shape.GetArea()}");
        }
    }
}
