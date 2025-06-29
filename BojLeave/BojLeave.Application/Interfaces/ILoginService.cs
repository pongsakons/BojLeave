namespace BojLeave.Application.Interfaces
{
    public interface ILoginService
    {
        bool ValidateUser(string username, string password);
    }
}
