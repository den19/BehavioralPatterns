namespace Notification
{
    internal class Program
    {
        static void Main(string[] args)
        {
            NotificationSystem system = new NotificationSystem();

            LoggerModule logger = new LoggerModule(system);
            DatabaseModule database = new DatabaseModule(system);

            system.Register(logger);
            system.Register(database);

            logger.SendNotification("Server error");
            database.SendNotification("New transaction");
        }
    }

    // Коллега
    abstract class Module
    {
        protected NotificationMediator mediator;

        public Module(NotificationMediator mediator)
        {
            this.mediator = mediator;
        }

        public abstract void SendNotification(string notification);
        public abstract void ReceiveNotification(string notification);
    }

    // Посредник
    interface NotificationMediator
    {
        void Register(Module module);
        void Broadcast(string notification, Module sender);
    }

    // Конкретный коллега
    class LoggerModule : Module
    {
        public LoggerModule(NotificationMediator mediator) : base(mediator)
        {
        }

        public override void ReceiveNotification(string notification)
        {
            Console.WriteLine($"Logger: Received new record - {notification}");
        }

        public override void SendNotification(string notification)
        {
            mediator.Broadcast(notification, this);
        }
    }

    // Конкретный коллега
    class DatabaseModule : Module
    {
        public DatabaseModule(NotificationMediator mediator) : base(mediator)
        {
        }

        public override void ReceiveNotification(string notification)
        {
            Console.WriteLine($"Database: Saved event - {notification}");
        }

        public override void SendNotification(string notification)
        {
            mediator.Broadcast(notification, this);
        }
    }

    // Конкретный посредник
    class NotificationSystem : NotificationMediator
    {
        private List<Module> modules = new List<Module>();

        public void Broadcast(string notification, Module sender)
        {
            foreach (Module module in modules)
            {
                if (module != sender)
                {
                    module.ReceiveNotification(notification);
                }
            }
        }

        public void Register(Module module)
        {
            modules.Add(module);
        }
    }
}
