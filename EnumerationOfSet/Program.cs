namespace EnumerationOfSet
{
    /*
    Пример паттерна Итератор
    Поведенческий паттерн Iterator позволяет последовательно проходить элементы коллекции без раскрытия её внутренней структуры.Этот паттерн предоставляет единый интерфейс для обхода различных коллекций, независимо от их реализации.
    Основные участники паттерна:
    Iterator — определяет интерфейс для доступа и перебора элементов коллекции.
    ConcreteIterator — реализует интерфейс итератора и хранит текущее положение в коллекции.
    Aggregate — определяет интерфейс для создания итератора.
    ConcreteAggregate — реализует интерфейс агрегата и возвращает конкретный итератор.
    */
    internal class Program
    {
        static void Main(string[] args)
        {
            var set = new HashSet<int> { 10, 20, 30 };
            var collection = new SetCollection(set);
            var iterator = collection.CreateIterator();

            while (iterator.HasNext())
            {
                Console.WriteLine(iterator.Next());
            }

            Console.ReadLine();
        }
    }

    public interface IIterator
    {
        bool HasNext();
        int Next();
    }

    public interface IAggregate
    {
        IIterator CreateIterator();
    }

    public class SetCollection : IAggregate
    {
        private readonly HashSet<int> _set;

        public SetCollection(HashSet<int> set)
        {
            _set = set;
        }

        public IIterator CreateIterator()
        {
            return new SetIterator(_set);
        }
    }

    public class SetIterator : IIterator
    {
        private readonly HashSet<int> _set;
        private IEnumerator<int> _enumerator;

        public SetIterator(HashSet<int> set)
        {
            _set = set;
            _enumerator = _set.GetEnumerator();
        }

        public bool HasNext()
        {
            return _enumerator.MoveNext();
        }

        public int Next()
        {
            return _enumerator.Current;
        }
    }
}
