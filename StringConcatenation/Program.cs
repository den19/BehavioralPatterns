namespace StringConcatenation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Создаем контекст
            Context context = new Context("\"Hello\" + \" World!\"");

            // Создаем выражение
            Expression expression = new ConcatenationExpression(
                new StringExpression("Hello"),
                new StringExpression(" World!"));

            // Интерпретируем выражение
            string result = expression.Interpret(context);

            Console.WriteLine(result); // Выведет Hello World!
        }
    }

    // Контекст
    public class Context
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
        public abstract string Interpret(Context context);
    }

    // Конкретная реализация для строковых данных
    class StringExpression : Expression
    {
        private string _value;

        public StringExpression(string value)
        {
            _value = value;
        }

        public override string Interpret(Context context)
        {
            return _value;
        }
    }

    // Конкретная реализация для конкатенации строк
    class ConcatenationExpression : Expression
    {
        private Expression _left;
        private Expression _right;

        public ConcatenationExpression(Expression left, Expression right)
        {
            _left = left;
            _right = right;
        }

        public override string Interpret(Context context)
        {
            return _left.Interpret(context) + _right.Interpret(context);
        }
    }


}
