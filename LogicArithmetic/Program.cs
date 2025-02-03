namespace LogicArithmetic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Создаем контекст
            Context context = new Context("true && false");

            // Создаем выражение
            Expression expression = new AndExpression(
                                        new BooleanExpression(true),
                                        new BooleanExpression(false));

            // Интерпретируем выражение
            bool result = expression.Interpret(context);

            Console.WriteLine(result);
        }
    }

    public abstract class  Expression
    {
        public abstract bool Interpret(Context context);
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

    // Конкретная реализация для булевых значений
    public class BooleanExpression : Expression
    {
        private bool _value;

        public BooleanExpression(bool value)
        {
            _value = value;
        }

        public override bool Interpret(Context context)
        {
            return _value;
        }
    }

    // Конкретная реализация для оператора AND
    public class AndExpression : Expression
    {
        private Expression _left;
        private Expression _right;

        public AndExpression(Expression left, Expression right)
        {
            _left = left;
            _right = right;
        }

        public override bool Interpret(Context context)
        {
            return _left.Interpret(context) && _right.Interpret(context);
        }
    }


}
