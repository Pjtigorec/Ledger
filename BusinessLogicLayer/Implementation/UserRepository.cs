using Common.Core;
using Common.Interfaces;
using DataAccessLayer.Interfaces;
using System.Collections.Generic;

namespace BusinessLogicLayer.Implementation
{
    public class UserRepository : IUserRepository
    {
        IDataAccess _db;

        public UserRepository(IDataAccess db)
        {
            _db = db;
        }

        public List<User> GetUsers()
        {
            return _db.Users.GetUsers();
        }

        public User GetUserById(int id)
        {
            return _db.Users.GetUserById(id);
        }

        public void Create(User user)
        {
            _db.Users.Create(user);
        }

        public void Update(User user)
        {
            _db.Users.Update(user);
        }

        public void Delete(int id)
        {
            _db.Users.Delete(id);
        }
    }
}
