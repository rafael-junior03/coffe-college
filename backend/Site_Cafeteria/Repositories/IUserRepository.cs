using Site_Cafeteria.Entities;

namespace Site_Cafeteria.Repositories;

public interface IUserRepository
{
    Task Create(User user);
}
