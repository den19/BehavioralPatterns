using System.Reflection.Metadata;

namespace ChatRoom
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ChatRoom chatRoom = new ChatRoom();

            User alice = new User(chatRoom, "Alice");
            User bob = new User(chatRoom, "Bob");
            User charlie = new User(chatRoom, "Charlie");

            chatRoom.AddUser(alice);
            chatRoom.AddUser(bob);
            chatRoom.AddUser(charlie);

            alice.Send("Hi all!");
            bob.Send("Hi, Alice!");
            charlie.Send("Hello, collegues!");
        }
    }

    // Коллега
    abstract class Colleague
    {
        protected Mediator mediator;

        protected Colleague(Mediator mediator)
        {
            this.mediator = mediator;
        }

        public abstract void Send(string message);
        public abstract void Receive(string message);
    }

    // Конкретный коллега
    class User : Colleague
    {
        public string name;

        public User(Mediator mediator, string name): base(mediator)
        {
            this.name = name;
        }

        public override void Receive(string message)
        {
            Console.WriteLine($"{name}: Received message '{message}'");
        }

        public override void Send(string message)
        {
            Console.WriteLine($"{name}: Send message '{message}'");
            mediator.Send(message, this);
        }
    }

    // Посредник
    interface Mediator
    {
        void AddUser(User user);
        void Send(string message, User sender);
    }

    // Конкретный посредник
    class ChatRoom : Mediator
    {
        private Dictionary<string, User> users = new Dictionary<string, User>();

        public void AddUser(User user)
        {
            users[user.name] = user;
        }

        public void Send(string message, User sender)
        {
            foreach (KeyValuePair<string, User> pair in users)
            {
                if (pair.Value != sender)
                    pair.Value.Receive(message);
            }
        }
    }
}
