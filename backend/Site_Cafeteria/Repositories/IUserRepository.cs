using Site_Cafeteria.Entities;

namespace Site_Cafeteria.Repositories;

public interface IUserRepository
{
    Task Create(User user);
    Task<bool> Login(Login dto);
}
