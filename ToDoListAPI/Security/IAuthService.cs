using ToDoListAPI.Model;

namespace ToDoListAPI.Security
{
    public interface IAuthService
    {
        Task<UserLogin?> Autenticar(UserLogin userLogin);
    }
}
