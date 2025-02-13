namespace AgePolicy
{
    /*
    Паттерн проектирования Simple Policy (Простая Политика) представляет собой способ отделения бизнес-правил от основной логики приложения. 
    Этот паттерн часто используется для инкапсуляции сложных условий принятия решений, что улучшает читаемость и поддерживаемость кода.
    Политики определяют правила, которым должны следовать объекты, и позволяют изменять эти правила без изменения основного кода. 

    Как работает Simple Policy?
    1.	Определение политик: Каждая политика определяет конкретное правило или условие, которое должно быть выполнено.
    2.	Инъекция зависимостей: Политики внедряются в объекты, которые используют их для принятия решений.
    3.	Применение политик: Объекты вызывают методы политик для оценки условий и принятия соответствующих решений.
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            IAgePolicy policy = new AdultAgePolicy();
            ContentService service = new ContentService(policy);

            int age = 25;
            bool canAccess = service.CheckAccess(age);

            Console.WriteLine(canAccess ? "Доступ разрешен" : "Доступ запрещён");
        }
    }

    public interface IAgePolicy
    {
        bool CanAccessContent(int age);
    }

    public class AdultAgePolicy : IAgePolicy
    {
        public bool CanAccessContent(int age)
        {
            return age >= 18;
        }
    }

    public class ContentService
    {
        private readonly IAgePolicy _agePolicy;
        public ContentService(IAgePolicy agePolicy)
        {
            _agePolicy = agePolicy;
        }
        public bool CheckAccess(int age)
        {
            return _agePolicy.CanAccessContent(age);
        }
    }
}
