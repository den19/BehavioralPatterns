namespace AnonymousUser
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UserService userService = new UserService();
            IUser currentUser = userService.GetCurrentUser();

            Console.WriteLine(currentUser.Name); // Guest
            currentUser.Logout(); // Ничего не происходит
        }
    }

    interface IUser
    {
        string Name { get; }
        void Logout();
    }

    class AuthenticatedUser : IUser
    {
        public string Name { get; }

        public AuthenticatedUser(string name)
        {
            Name = name;
        }

        public void Logout()
        {
            Console.WriteLine($"{Name} logged out.");
        }
    }

    class AnonymousUser : IUser
    {
        public string Name => "Guest";

        public void Logout()
        {
            // Ничего не делаем, так как анонимный пользователь не может выйти из системы.
        }
    }

    class UserService
    {
        public IUser GetCurrentUser()
        {
            // Предположим, что пользователь не аутентифицировался.
            return new AnonymousUser();
        }
    }
}
