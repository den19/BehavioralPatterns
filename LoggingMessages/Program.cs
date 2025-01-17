namespace LoggingMessages
{
    /*
    Допустим, ваше приложение должно поддерживать различные способы логирования сообщений: консоль, файл и базу данных.
    Используя паттерн Стратегия, вы сможете легко менять стратегию логирования.
    */
    internal class Program
    {
        static void Main(string[] args)
        {
            string logMessage = "Test message";

            // Логирование в консоль
            var consoleLogger = new LoggerService(new ConsoleLogger());
            consoleLogger.WriteLog(logMessage);

            // Логирование в файл
            var fileLogger = new LoggerService(new FileLogger("log.txt"));
            fileLogger.WriteLog(logMessage);
        }
    }

    // Интерфейс стратегии
    public interface ILogger
    {
        void Log(string message);
    }

    // Контекст
    public class LoggerService
    {
        private readonly ILogger _logger;

        public LoggerService(ILogger logger)
        {
            _logger = logger;
        }

        public void WriteLog(string message)
        {
            _logger.Log(message);
        }
    }

    // Конкретная стратегия: Логирование в консоль
    public class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }

    // Конкретная стратегия: Логирование в файл
    public class FileLogger : ILogger
    {
        private string _filePath;

        public FileLogger(string filePath)
        {
            _filePath = filePath;
        }

        public void Log(string message)
        {
            using StreamWriter writer = File.AppendText(_filePath);
            writer.WriteLine(message);
        }
    }
}
