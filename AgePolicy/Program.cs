namespace AgePolicy
{
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
