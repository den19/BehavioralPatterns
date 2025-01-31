/*
    Паттерн Chain of Responsibility (цепочка обязанностей) представляет собой поведенческий шаблон проектирования, который позволяет передавать запросы через цепочку обработчиков. Каждый обработчик решает, может ли он обработать запрос, и либо обрабатывает его, либо передает следующему обработчику в цепи.

    Основные элементы:
    Handler – абстрактный класс или интерфейс для всех обработчиков.
    ConcreteHandlers – конкретные классы-обработчики, реализующие метод обработки запросов.
    Client – клиентский код, который создает цепь обработчиков и отправляет запрос.
*/
namespace EventHandling
{
    // Абстрактный класс Handler
    abstract class EventHandler
    {
        protected EventHandler nextHandler;

        public void SetNext(EventHandler nextHandler)
        {
            this.nextHandler = nextHandler;
        }

        public abstract void HandleEvent(EventType eventType);
    }

    // Конкретные обработчики
    class MouseClickHandler : EventHandler
    {
        public override void HandleEvent(EventType eventType)
        {
            if (eventType == EventType.MouseClick)
            {
                Console.WriteLine("Обрабатывается событие MouseClick.");
            }
            else if (nextHandler != null)
            {
                nextHandler.HandleEvent(eventType);
            }
        }
    }

    class KeyPressHandler : EventHandler
    {
        public override void HandleEvent(EventType eventType)
        {
            if (eventType == EventType.KeyPress)
            {
                Console.WriteLine("Обрабатывается событие KeyPress.");
            }
            else if (nextHandler != null)
            {
                nextHandler.HandleEvent(eventType);
            }
        }
    }

    class ResizeWindowHandler : EventHandler
    {
        public override void HandleEvent(EventType eventType)
        {
            if (eventType == EventType.ResizeWindow)
            {
                Console.WriteLine("Обрабатывается событие ResizeWindow.");
            }
            else if (nextHandler != null)
            {
                nextHandler.HandleEvent(eventType);
            }
        }
    }

    enum EventType
    {
        MouseClick,
        KeyPress,
        ResizeWindow
    }

    class Program
    {
        static void Main(string[] args)
        {
            var mouseClickHandler = new MouseClickHandler();
            var keyPressHandler = new KeyPressHandler();
            var resizeWindowHandler = new ResizeWindowHandler();

            mouseClickHandler.SetNext(keyPressHandler);
            keyPressHandler.SetNext(resizeWindowHandler);

            mouseClickHandler.HandleEvent(EventType.MouseClick);
            mouseClickHandler.HandleEvent(EventType.KeyPress);
            mouseClickHandler.HandleEvent(EventType.ResizeWindow);
        }
    }
}
