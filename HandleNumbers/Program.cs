/*
    Паттерн Chain of Responsibility (цепочка обязанностей) представляет собой поведенческий шаблон проектирования, который позволяет передавать запросы через цепочку обработчиков. Каждый обработчик решает, может ли он обработать запрос, и либо обрабатывает его, либо передает следующему обработчику в цепи.

    Основные элементы:
    Handler – абстрактный класс или интерфейс для всех обработчиков.
    ConcreteHandlers – конкретные классы-обработчики, реализующие метод обработки запросов.
    Client – клиентский код, который создает цепь обработчиков и отправляет запрос.
*/
namespace HandleNumbers
{
    // Абстрактный класс Handler
    abstract class Handler
    {
        protected Handler successor;

        public void SetSuccessor(Handler successor)
        {
            this.successor = successor;
        }

        public abstract void HandleRequest(int request);
    }

    // Конкретные обработчики
    class HandlerA : Handler
    {
        public override void HandleRequest(int request)
        {
            if (request >= 0 && request < 10)
            {
                Console.WriteLine($"Обработал запрос {request}: HandlerA");
            }
            else if (successor != null)
            {
                successor.HandleRequest(request);
            }
        }
    }

    class HandlerB : Handler
    {
        public override void HandleRequest(int request)
        {
            if (request >= 10 && request < 20)
            {
                Console.WriteLine($"Обработал запрос {request}: HandlerB");
            }
            else if (successor != null)
            {
                successor.HandleRequest(request);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var handlerA = new HandlerA();
            var handlerB = new HandlerB();

            handlerA.SetSuccessor(handlerB);

            int[] requests = { 6, 14 };

            foreach (var request in requests)
            {
                handlerA.HandleRequest(request);
            }
        }
    }    
}
