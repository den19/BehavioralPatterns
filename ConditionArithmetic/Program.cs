namespace ConditionArithmetic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Создаём контекст
            Context context = new Context("if true then 100 else 200");

            // Создаём выражение
            Expression expression = new IfExpression(
                                        new BooleanExpression(true),
                                        new NumberExpression(100),
                                        new NumberExpression(200));

            // Интерпертируем выражение
            object result = expression.Interpret(context);

            Console.WriteLine(result);
        }

        public abstract class Expression
        {
            public abstract object Interpret(Context context);
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

        // Конкретная реализация для чисел
        public class NumberExpression : Expression
        {
            private int _value;
            public NumberExpression(int value)
            {
                _value = value;
            }

            public override object Interpret(Context context)
            {
                return _value;
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

            public override object Interpret(Context context)
            {
                return _value;
            }
        }

        // Конкретная реализация для условных операторов
        class IfExpression : Expression
        {
            private Expression _condition;
            private Expression _thenPart;
            private Expression _elsePart;

            public IfExpression(Expression condition, Expression thenPart, Expression elsePart)
            {
                _condition = condition;
                _thenPart = thenPart;
                _elsePart = elsePart;
            }

            public override object Interpret(Context context)
            {
                if ((bool)_condition.Interpret(context))
                {
                    return _thenPart.Interpret(context);
                }
                else
                {
                    return _elsePart.Interpret(context);
                }
            }
        }
    }
}
