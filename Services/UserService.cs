using InfinionAPI.Data;
using InfinionAPI.Interface;
using InfinionAPI.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace InfinionAPI.Services
{
    public class UserService : IUserInterface
    {
        private readonly InfinionDbContext _dbContext;


        public UserService(InfinionDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Users> CreateUsers(Users users)
        {
          await _dbContext.Set<Users>().AddAsync(users);
          _dbContext.SaveChanges();

        return users;
        }


        public async Task<Users> DeleteUsers(int id)
        {
           var usersId= await _dbContext.Set<Users>().FirstOrDefaultAsync(i=>i.Id==id);

            if (usersId == null)
            {
                return null;
            }

            _dbContext.Remove(usersId);
          await  _dbContext.SaveChangesAsync();

            return usersId;

        }

        public async Task<List<Users>> GetUsersAsync()
        {
            return await _dbContext.Set<Users>().ToListAsync();

        }

        public async Task<Users> GetUsersById(int id)
        {
            var usersId = await _dbContext.Set<Users>().FirstOrDefaultAsync(i => i.Id == id);

            if (usersId == null)
            {
                return null;
            }
            return usersId;
        }

        public async Task<Users> UpdateUSers(int id, Users User)
        {
            var usersId = await _dbContext.Set<Users>().FirstOrDefaultAsync(i => i.Id == id);

            if (usersId == null)
            {
                return null;
            }

            usersId.FirstName= User.FirstName;
            usersId.LastName= User.LastName;
            usersId.EmailAddress= User.EmailAddress;

           await _dbContext.SaveChangesAsync();

            return usersId;
        }

       
    }
}
