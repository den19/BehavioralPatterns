/*
    Паттерн Команда (Command) — это поведенческий паттерн проектирования, который инкапсулирует запрос как объект, 
    позволяя параметризовать клиенты с различными запросами, ставить запросы в очередь или протоколировать их, 
    а также поддерживать отмену операций.

    Основная идея заключается в том, чтобы отделить инициатора команды от исполнителя. Команды позволяют сохранять историю действий и выполнять откат (undo).

    Основные элементы паттерна:
    ICommand — интерфейс команды, определяющий методы выполнения и отмены.
    ConcreteCommand — конкретная реализация интерфейса команды, содержащая ссылку на объект-получателя и вызывающая его методы.
    Receiver — объект, выполняющий действия, требуемые командой.
    Invoker — объект, инициирующий выполнение команд.
    Client — создаёт команды и назначает их исполнителям. 
 */
namespace Command
{
    internal class Client
    {
        static void Main(string[] args)
        {
            var receiver = new Receiver();
            var command = new ConcreteCommand(receiver);
            var invoker = new Invoker();

            invoker.SetCommand(command);
            invoker.Invoke(); // Do command
            invoker.Cancel(); // Cancel command
        }
    }

    public interface ICommand
    {
        void Execute();
        void Undo();
    }

    public class Receiver
    {
        public void Action()
        {
            Console.WriteLine("Doing an action");
        }
    }

    public class ConcreteCommand : ICommand
    {
        private readonly Receiver _receiver;

        public ConcreteCommand(Receiver receiver)
        {
            _receiver = receiver;
        }

        public void Execute()
        {
            _receiver.Action();
        }

        public void Undo()
        {
            Console.WriteLine("Undoing an action");
        }
    }

    public class Invoker
    {
        private ICommand _command;

        public void SetCommand(ICommand command)
        {
            _command = command;
        }

        public void Invoke()
        {
            _command.Execute();
        }

        public void Cancel()
        {
            _command.Undo();
        }
    }
}
