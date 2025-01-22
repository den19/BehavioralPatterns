namespace SimpleListRealisation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }

    // Интерфейс итератора
    interface IIterator
    {
        bool HasNext();
        object Current();
        void Next();
    }

    // Агрегат (коллекция)
    class MyList
    {
        private List<string> items = new List<string>();
    }
}
