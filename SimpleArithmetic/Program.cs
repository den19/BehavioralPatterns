namespace SimpleArithmetic
{
    /*
    Поведенческий шаблон проектирования Интерпретатор используется для создания грамматик языков и интерпретации выражений этих языков. Он позволяет легко добавлять новые выражения в язык без изменения уже существующего кода. Давайте рассмотрим этот паттерн подробнее и приведем пять примеров на языке C# с использованием функции Main.
    Основная идея шаблона Интерпретатор
    Шаблон Интерпретатор состоит из трех основных компонентов:
    1.	Абстрактный класс Expression: Определяет интерфейс для всех выражений в языке.
    2.	Конкретные реализации Expression: Представляют различные типы выражений, такие как числа, операции, условия и т.п.
    3.	Контекст: Содержит информацию о состоянии системы, которая может использоваться при интерпретации выражений.
    */
    internal class Program
    {
        static void Main(string[] args)
        {
            // Создаем контекст
            Context context = new Context("10+(20-30)");

            // Создаем выражение
            Expression expression = new AdditionExpression(
                new NumberExpression(10),
                new SubtractionExpression(new NumberExpression(20), new NumberExpression(30)));

            // Интерпретируем выражение
            int result = expression.Interpret(context);

            Console.WriteLine(result); // Выведет 0

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

    // Конкретная реализация для вычитания
    class SubtractionExpression : Expression
    {
        private Expression _left;
        private Expression _right;

        public SubtractionExpression(Expression left, Expression right)
        {
            _left = left;
            _right = right;
        }

        public override int Interpret(Context context)
        {
            return _left.Interpret(context) - _right.Interpret(context);
        }
    }

}
