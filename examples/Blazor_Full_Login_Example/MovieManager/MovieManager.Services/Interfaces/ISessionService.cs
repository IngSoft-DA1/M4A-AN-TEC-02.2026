using MovieManager.Services.Models;

namespace MovieManager.Services.Interfaces;

public interface ISessionService
{
    LoggedUserDTO GetLoggedUser();
    void Login(string username, string password);
    void Logout();
}