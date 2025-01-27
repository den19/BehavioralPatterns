namespace SocialNetwork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SocialNetwork socialNetwork = new SocialNetwork();

            User user1 = new User();
            AdminPanel adminPanel = new AdminPanel();
            MobileApp mobileApp = new MobileApp();

            socialNetwork.RegisterObserver(user1);
            socialNetwork.RegisterObserver(adminPanel);
            socialNetwork.RegisterObserver(mobileApp);

            socialNetwork.PostNews("Hot news: CODVID-19: bad prediction");
            socialNetwork.NotifyObservers();
        }
    }

    // Наблюдатель
    interface IObserver
    {
        void Update(string news);
    }

    // Субъект
    class SocialNetwork
    {
        private List<IObserver> observers;
        private string news;

        public SocialNetwork()
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
                observer.Update(news);
            }
        }

        public void PostNews(string news)
        {
            this.news = news;
            NotifyObservers();
        }

        public string GetNews() => news;
    }

    class User : IObserver
    {
        public void Update(string news)
        {
            Console.WriteLine($"Новости: {news}");
        }
    }
    class AdminPanel : IObserver
    {
        public void Update(string news)
        {
            Console.WriteLine($"Admin panel: News: {news}");
        }
    }

    class MobileApp : IObserver
    {
        public void Update(string news)
        {
            Console.WriteLine($"Mobile app: News: {news}");
        }
    }
}
