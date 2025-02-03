namespace SimpleArithmetic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Создаем контекст
            Context context = new Context("10+20");

            // Создаем выражение
            Expression expression = new AdditionExpression(
                new NumberExpression(10),
                new NumberExpression(20));

            // Интерпретируем выражение
            int result = expression.Interpret(context);

            Console.WriteLine(result); // Выведет 30

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
        public abstract int Interpret(Context context);
    }

    // Конкреная реализация для чисел
    class NumberExpression : Expression
    {
        private int _value;

        public NumberExpression(int value)
        {
            _value = value;
        }

        public override int Interpret(Context context)
        {
            return _value;
        }
    }

    // Конкретная реализация для сложения
    class AdditionExpression : Expression
    {
        private Expression _left;
        private Expression _right;

        public AdditionExpression(Expression left, Expression right)
        {
            _left = left;
            _right = right;
        }

        public override int Interpret(Context context)
        {
            return _left.Interpret(context) + _right.Interpret(context);
        }
    }
}
