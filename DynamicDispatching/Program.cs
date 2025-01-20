namespace DynamicDispatching
{
    /*
    C# поддерживает динамическую диспетчеризацию, которая позволяет автоматически выбирать нужный метод
    на этапе выполнения программы. Это уменьшает необходимость в явной реализации методов для каждого типа элемента.
    */

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }

    public interface IVisitor
    {
        void Visit(dynamic element);
    }

    public abstract class Element
    {
        public virtual void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
    public class ConcreteElement : Element
    {
    }

    public class ConcreteVisitor : IVisitor
    {
        public void Visit(dynamic element)
        {
            // Реализация логики посещения
        }
    }


}
