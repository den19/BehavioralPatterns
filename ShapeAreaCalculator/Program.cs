namespace ShapeAreaCalculator
{
    /*
    Пример 1: Геометрические фигуры
    В этом примере мы реализуем вычисление площади для различных геометрических фигур (круг, квадрат). 
    */
    internal class Program
    {
        static void Main(string[] args)
        {
            var shapes = new Shape[]
            {
                new Circle { Radius = 5 },
                new Square { Side = 6 }
            };

            var areaCalculator = new AreaCalculator();

            foreach (var shape in shapes)
            {
                shape.Accept(areaCalculator);
                Console.WriteLine($"{shape.GetType().Name}: Square is = {areaCalculator.Area:F2}");
            }

            Console.ReadLine();
        }
    }

    // Интерфейс посетителя
    public interface IShapeVisitor
    {
        void Visit(Circle circle);
        void Visit(Square square);
    }

    // Абстрактный базовый класс для всех фигур
    public abstract class Shape
    {
        public abstract void Accept(IShapeVisitor visitor);
    }

    // Класс круга
    public class Circle : Shape
    {
        public double Radius { get; set; }
        public override void Accept(IShapeVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    // Класс квадрата
    public class Square : Shape
    {
        public double Side { get; set; }

        public override void Accept(IShapeVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    // Конкретный посетитель - Вычисляет площадь
    public class AreaCalculator : IShapeVisitor
    {
        public double Area { get; private set; }

        public void Visit(Circle circle)
        {
            Area = Math.PI * circle.Radius * circle.Radius;
        }

        public void Visit(Square square)
        {
            Area = square.Side * square.Side;
        }
    }
}
