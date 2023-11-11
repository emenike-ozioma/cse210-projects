using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapesList = new List<Shape>();

        Square s1 = new Square("Blue", 10);
        shapesList.Add(s1);

        Rectangle s2 = new Rectangle("Black", 5, 5);
        shapesList.Add(s2);

        Circle s3 = new Circle("Blue", 2);
        shapesList.Add(s3);

        foreach (Shape shape in shapesList)
        {
            string color = shape.GetColor();

            double area = shape.GetArea();

            Console.WriteLine($"The {color} shape has an area of {area}.");
        }
    }
}