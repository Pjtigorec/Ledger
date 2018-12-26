using Common.Core;
using System.Collections.Generic;

namespace Common.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        List<User> GetUsers();

        User GetUserById(int id);
    }
}
