/*
    Паттерн Chain of Responsibility (цепочка обязанностей) представляет собой поведенческий шаблон проектирования, который позволяет передавать запросы через цепочку обработчиков. Каждый обработчик решает, может ли он обработать запрос, и либо обрабатывает его, либо передает следующему обработчику в цепи.

    Основные элементы:
    Handler – абстрактный класс или интерфейс для всех обработчиков.
    ConcreteHandlers – конкретные классы-обработчики, реализующие метод обработки запросов.
    Client – клиентский код, который создает цепь обработчиков и отправляет запрос.
*/
namespace HandleExceptions
{
    // Абстрактный класс Handler
    abstract class ExceptionHandler
    {
        protected ExceptionHandler successor;

        public void SetSuccessor(ExceptionHandler successor)
        {
            this.successor = successor;
        }

        public abstract void HandleException(Exception ex);
    }

    // Конкретные обработчики
    class ArgumentNullExceptionHandler : ExceptionHandler
    {
        public override void HandleException(Exception ex)
        {
            if (ex is ArgumentNullException)
            {
                Console.WriteLine("Обработано исключение ArgumentNullException.");
            }
            else if (successor != null)
            {
                successor.HandleException(ex);
            }
        }
    }

    class FormatExceptionHandler : ExceptionHandler
    {
        public override void HandleException(Exception ex)
        {
            if (ex is FormatException)
            {
                Console.WriteLine("Обработано исключение FormatException.");
            }
            else if (successor != null)
            {
                successor.HandleException(ex);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var argNullHandler = new ArgumentNullExceptionHandler();
            var formatExHandler = new FormatExceptionHandler();

            argNullHandler.SetSuccessor(formatExHandler);

            try
            {
                throw new ArgumentNullException();
            }
            catch (Exception ex)
            {
                argNullHandler.HandleException(ex);
            }

            try
            {
                throw new FormatException();
            }
            catch (Exception ex)
            {
                argNullHandler.HandleException(ex);
            }
        }
    }
}
