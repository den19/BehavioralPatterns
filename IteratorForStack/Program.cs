namespace IteratorForStack
{
    // Итератор для стека
    internal class Program
    {
        static void Main(string[] args)
        {
            MyStack myStack = new MyStack();
            myStack.Push(1);
            myStack.Push(2);
            myStack.Push(3);

            IIterator iterator = myStack.CreateIterator();

            while (iterator.HasNext())
            {
                Console.WriteLine(iterator.Current());
                iterator.Next();
            }
        }
    }

    interface IIterator
    {
        bool HasNext();
        object Current();
        void Next();
    }

    // Агрегат (стек)
    class MyStack
    {
        private Stack<int> stack = new Stack<int>();

        public void Push(int value)
        {
            stack.Push(value);
        }

        public IIterator CreateIterator()
        {
            return new StackIterator(stack);
        }

        private class StackIterator : IIterator
        {
            private Stack<int> stack;
            private Stack<int> tempStack;

            public StackIterator(Stack<int> stack)
            {
                this.stack = stack;
                tempStack = new Stack<int>(new Stack<int>(stack));
            }

            public object Current()
            {
                return tempStack.Peek();
            }

            public bool HasNext()
            {
                return tempStack.Count > 0;
            }

            public void Next()
            {
                tempStack.Pop();
            }
        }
    }
}
