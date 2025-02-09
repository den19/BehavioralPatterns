namespace Logging
{
    /*
    Часто бывает необходимо осуществлять логирование в системе. Однако, в некоторых случаях логирование может быть отключено.
    Вместо того чтобы проверять наличие логгера перед каждым вызовом метода логирования, можно использовать Null Logger.

    Заключение
Паттерн Null Object позволяет избежать проверок на null, делая код более чистым и безопасным.
Вместо того чтобы возвращать null, возвращается объект-заместитель, который выполняет минимальное
количество действий или вообще ничего не делает. Это особенно полезно в ситуациях, когда отсутствие объекта не должно
приводить к исключениям или ошибкам, а должно обрабатываться корректным способом.
    */
    internal class Program
    {
        static void Main(string[] args)
        {
            LoggingService loggingService = new LoggingService(null);

            loggingService.LogInfo("This is an info message."); // Ничего не делаем
            loggingService.LogError("This is an info message."); // Ничего не делаем
        }
    }

    interface ILogger
    {
        void Info(string message);
        void Error(string message);
    }

    class FileLogger : ILogger
    {
        public void Error(string message)
        {
            Console.WriteLine($"Error: {message}");
        }

        public void Info(string message)
        {
            Console.WriteLine($"Info: {message}");
        }
    }

    class NullLogger : ILogger
    {
        public void Error(string message)
        {
            // Ничего не делаем
        }

        public void Info(string message)
        {
            // Ничего не делаем
        }
    }

    class LoggingService
    {
        private ILogger logger;

        public LoggingService(ILogger logger)
        {
            this.logger = logger ?? new NullLogger();
        }

        public void LogInfo(string message)
        {
            logger.Info(message);
        }

        public void LogError(string message)
        {
            logger.Error(message);
        }
    }
}
