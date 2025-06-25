namespace BojLeave.Application.Auth
{
    public interface ILoginService
    {
        bool ValidateUser(string username, string password);
    }

    public class LoginService : ILoginService
    {
        public bool ValidateUser(string username, string password)
        {
            // ตัวอย่าง: username == password
            return !string.IsNullOrEmpty(username) && username == password;
        }
    }
}
