/*
    Паттерн Chain of Responsibility (цепочка обязанностей) представляет собой поведенческий шаблон проектирования, который позволяет передавать запросы через цепочку обработчиков. Каждый обработчик решает, может ли он обработать запрос, и либо обрабатывает его, либо передает следующему обработчику в цепи.

    Основные элементы:
    Handler – абстрактный класс или интерфейс для всех обработчиков.
    ConcreteHandlers – конкретные классы-обработчики, реализующие метод обработки запросов.
    Client – клиентский код, который создает цепь обработчиков и отправляет запрос.
*/
namespace CoRLoggingMessages
{
    // Абстрактный класс Handler
    abstract class Logger
    {
        protected Logger nextLogger;

        public void SetNextLogger(Logger nextLogger)
        {
            this.nextLogger = nextLogger;
        }

        public abstract void LogMessage(LogLevel level, string message);
    }

    // Конкретные обработчики
    class InfoLogger : Logger
    {
        public override void LogMessage(LogLevel level, string message)
        {
            if (level == LogLevel.INFO)
            {
                Console.WriteLine($"INFO: {message}");
            }
            else if (nextLogger != null)
            {
                nextLogger.LogMessage(level, message);
            }
        }
    }

    class WarningLogger : Logger
    {
        public override void LogMessage(LogLevel level, string message)
        {
            if (level == LogLevel.WARNING)
            {
                Console.WriteLine($"WARNING: {message}");
            }
            else if (nextLogger != null)
            {
                nextLogger.LogMessage(level, message);
            }
        }
    }

    class ErrorLogger : Logger
    {
        public override void LogMessage(LogLevel level, string message)
        {
            if (level == LogLevel.ERROR)
            {
                Console.WriteLine($"ERROR: {message}");
            }
            else if (nextLogger != null)
            {
                nextLogger.LogMessage(level, message);
            }
        }
    }

    enum LogLevel
    {
        INFO,
        WARNING,
        ERROR
    }

    class Program
    {
        static void Main(string[] args)
        {
            var infoLogger = new InfoLogger();
            var warningLogger = new WarningLogger();
            var errorLogger = new ErrorLogger();

            infoLogger.SetNextLogger(warningLogger);
            warningLogger.SetNextLogger(errorLogger);

            infoLogger.LogMessage(LogLevel.INFO, "Это информационное сообщение.");
            infoLogger.LogMessage(LogLevel.WARNING, "Предупреждение!");
            infoLogger.LogMessage(LogLevel.ERROR, "Ошибка произошла.");
        }
    }
}
