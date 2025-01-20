using System.Reflection;

namespace VisitorReflection
{
    /*
    Применение рефлексии
    Можно использовать рефлексию для автоматического вызова соответствующих методов посетителей.
    Это избавит от необходимости вручную прописывать методы для каждого типа элемента. 
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
        void Visit(Element element);
    }

    public class Element
    {
        public virtual void Accept(IVisitor visitor)
        {
            MethodInfo method = visitor.GetType().GetMethod("Visit",
                BindingFlags.Instance | BindingFlags.Public,
                null,
                new Type[] { this.GetType() },
                null);

            if (method != null)
            {
                method.Invoke(visitor, new object[] { this });
            }
        }
    }

    public class ConcreteElement : Element
    {

    }

    public class ConcreteVisitor : IVisitor
    {
        public void Visit(Element element)
        {
            // Реализация логики посещения
        }
    }
}
