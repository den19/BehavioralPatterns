namespace ArrayFiltrationPredicate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Создаем контекст
            Context context = new Context("[1, 2, 3, 4, 5]");

            // Создаем выражение
            Expression expression = new FilterExpression(
                new ArrayExpression(new List<int> { 1, 2, 3, 4, 5 }),
                x => x % 2 == 0);

            // Интерпретируем выражение
            List<int> result = expression.Interpret(context);

            foreach (var item in result)
            {
                Console.WriteLine(item); // Выведет 2 и 4
            }

        }
    }

    // Контекст
    class Context
    {
        public string Input { get; set; }

        public Context(string input)
        {
            Input = input;
        }
    }

    // Абстрактный класс Expression
    abstract class Expression
    {
        public abstract List<int> Interpret(Context context);
    }

    // Конкретная реализация для массива чисел
    class ArrayExpression : Expression
    {
        private List<int> _values;

        public ArrayExpression(List<int> values)
        {
            _values = values;
        }

        public override List<int> Interpret(Context context)
        {
            return _values;
        }
    }

    // Конкретная реализация для фильтрации элементов массива
    class FilterExpression : Expression
    {
        private Expression _array;
        private Func<int, bool> _predicate;

        public FilterExpression(Expression array, Func<int, bool> predicate)
        {
            _array = array;
            _predicate = predicate;
        }

        public override List<int> Interpret(Context context)
        {
            List<int> filteredList = new List<int>();
            foreach (int item in _array.Interpret(context))
            {
                if (_predicate(item))
                {
                    filteredList.Add(item);
                }
            }
            return filteredList;
        }
    }

}
