using InfinionAPI.Models;

namespace InfinionAPI.Interface
{
    public interface IUserInterface
    {
        Task<List<Users>> GetUsersAsync();
        Task<Users> GetUsersById(int id);

        Task<Users> UpdateUSers( int id, Users User);

        Task<Users> CreateUsers(Users users);

        Task<Users> DeleteUsers(int id);
    }
}
