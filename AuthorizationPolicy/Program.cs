namespace AuthorizationPolicy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IAuthorizationPolicy policy = new RoleBasedAuthorizationPolicy();
            AuthorizationService service = new AuthorizationService(policy);

            string role = "User";
            string resource = "WriteResource";
            bool authorized = service.Authorize(role, resource);

            Console.WriteLine(authorized ? "Доступ разрешен" : "Доступ запрещён");
        }
    }

    public interface IAuthorizationPolicy
    {
        bool IsAuthorized(string role, string resource);
    }

    public class RoleBasedAuthorizationPolicy : IAuthorizationPolicy
    {
        public bool IsAuthorized(string role, string resource)
        {
            switch (role)
            {
                case "Admin":
                    return true;
                case "User":
                    return resource == "ReadOnlyResource";
                default:
                    return false;
            }
        }
    }

    public class AuthorizationService
    {
        private readonly IAuthorizationPolicy _authorizationPolicy;

        public AuthorizationService(IAuthorizationPolicy authorizationPolicy)
        {
            _authorizationPolicy = authorizationPolicy;
        }

        public bool Authorize(string role, string resource)
        {
            return _authorizationPolicy.IsAuthorized(role, resource);
        }
    }
}
