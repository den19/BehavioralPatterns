namespace AnonymousUser
{
    /*
    Паттерн проектирования Null Object используется для замены проверки на null в коде, предоставляя вместо этого
    объект-заменитель, который ничего не делает или выполняет минимальные действия.
    Это упрощает обработку ситуаций, когда объект может отсутствовать, избегая необходимости проверять каждый раз
    наличие объекта перед выполнением каких-то действий.

    Как работает Null Object?
    Основная идея заключается в том, чтобы создать специальный объект, который реализует тот же интерфейс, что и обычный объект,
    но при этом либо ничего не делает, либо выполняет безопасную пустую операцию. Таким образом, вместо того
    чтобы возвращать null, метод возвращает экземпляр этого объекта, и клиентский код может безопасно вызывать методы
    этого объекта, не беспокоясь о проверке на null.

    Пример 1: Пользовательская система
    Предположим, у нас есть система управления пользователями, где пользователь может быть аутентифицирован или нет.
    Вместо возвращения null при отсутствии пользователя, мы можем вернуть объект AnonymousUser, который является реализацией
    интерфейса IUser, но имеет ограниченные возможности. 
     */
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
