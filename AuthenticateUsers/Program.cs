/*
    Паттерн Chain of Responsibility (цепочка обязанностей) представляет собой поведенческий шаблон проектирования, который позволяет передавать запросы через цепочку обработчиков. Каждый обработчик решает, может ли он обработать запрос, и либо обрабатывает его, либо передает следующему обработчику в цепи.

    Основные элементы:
    Handler – абстрактный класс или интерфейс для всех обработчиков.
    ConcreteHandlers – конкретные классы-обработчики, реализующие метод обработки запросов.
    Client – клиентский код, который создает цепь обработчиков и отправляет запрос.
*/
namespace AuthenticateUsers
{
    // Абстрактный класс Handler
    abstract class Authenticator
    {
        protected Authenticator nextAuthenticator;

        public void SetNext(Authenticator nextAuthenticator)
        {
            this.nextAuthenticator = nextAuthenticator;
        }

        public abstract bool Authenticate(User user);
    }

    // Конкретные обработчики
    class PasswordAuthenticator : Authenticator
    {
        public override bool Authenticate(User user)
        {
            if (user.Password == "password")
            {
                return true;
            }
            else if (nextAuthenticator != null)
            {
                return nextAuthenticator.Authenticate(user);
            }
            return false;
        }
    }

    class OTPAuthenticator : Authenticator
    {
        public override bool Authenticate(User user)
        {
            if (user.OTP == "123456")
            {
                return true;
            }
            else if (nextAuthenticator != null)
            {
                return nextAuthenticator.Authenticate(user);
            }
            return false;
        }
    }

    class BiometricAuthenticator : Authenticator
    {
        public override bool Authenticate(User user)
        {
            if (user.BiometricData == "fingerprint")
            {
                return true;
            }
            else if (nextAuthenticator != null)
            {
                return nextAuthenticator.Authenticate(user);
            }
            return false;
        }
    }

    class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string OTP { get; set; }
        public string BiometricData { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var passwordAuth = new PasswordAuthenticator();
            var otpAuth = new OTPAuthenticator();
            var biometricAuth = new BiometricAuthenticator();

            passwordAuth.SetNext(otpAuth);
            otpAuth.SetNext(biometricAuth);

            var user = new User
            {
                Username = "user",
                Password = "password",
                OTP = "123456",
                BiometricData = "fingerprint"
            };

            if (passwordAuth.Authenticate(user))
            {
                Console.WriteLine("Пользователь успешно аутентифицирован.");
            }
            else
            {
                Console.WriteLine("Не удалось аутентифицировать пользователя.");
            }
        }
    }
}
