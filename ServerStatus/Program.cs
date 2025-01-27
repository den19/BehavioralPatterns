namespace ServerStatus
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Server server = new Server();

            Client client1 = new Client();
            Client client2 = new Client();
            
            server.RegisterObserver(client1);
            server.RegisterObserver(client2);

            server.ChangeServerStatus(Status.Reboot);
            server.NotifyObservers();

            Console.ReadLine();
        }
    }

    
    enum Status
    {
        Running,
        Reboot,
        Shutdown
    }

    // Интерфейс наблюдателя
    interface IObserver
    {
        void Update(Status status);
    }

    // Субъект - сервер
    class Server
    {
        private List<IObserver> observers;
        private Status serverStatus;

        public Server()
        {
            observers = new List<IObserver>();
        }

        public void RegisterObserver(IObserver observer)
        {
            observers.Add(observer);
        }

        public void UnregisterObserver(IObserver observer)
        {
            observers.Remove(observer);
        }

        public void NotifyObservers()
        {
            foreach (var observer in observers)
            {
                observer.Update(serverStatus);
            }
        }

        public void ChangeServerStatus(Status newStatus)
        {
            serverStatus = newStatus;
            NotifyObservers();
        }

        public Status GetServerStatus()
        {
            return serverStatus;
        }
    }

    class Client : IObserver
    {
        public void Update(Status status)
        {
            Console.WriteLine($"Server status changed: new status: {status.ToString()}");
        }
    }
}
