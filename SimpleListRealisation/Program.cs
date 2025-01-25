namespace SimpleListRealisation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyList myList = new MyList();
            myList.Add("Apple");
            myList.Add("Banana");
            myList.Add("Cherry");

            IIterator iterator = myList.CreateIterator();

            while (iterator.HasNext())
            {
                Console.WriteLine(iterator.Current());
                iterator.Next();
            }

            Console.ReadLine();
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

        public void Add(string item)
        {
            items.Add(item);
        }

        public IIterator CreateIterator()
        {
            return new ListIterator(this);
        }

        private class ListIterator : IIterator
        {
            private MyList list;
            private int index;
            public ListIterator(MyList list)
            {
                this.list = list;
                index = 0;
            }

            public bool HasNext()
            {
                return index < list.items.Count;
            }

            public object Current()
            {
                return list.items[index];
            }

            public void Next()
            {
                index++;
            }
        }
    }
}
