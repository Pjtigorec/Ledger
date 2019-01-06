using Common.AccountModels;
using Common.Core;
using Common.Interfaces;
using DataAccessLayer.Interfaces;

namespace BusinessLogicLayer.Implementation
{
    public class LoginRepository : ILoginRepository
    {
        IDataAccess _db;

        public LoginRepository(IDataAccess db)
        {
            _db = db;
        }

        public User LoginUser(LoginModel model)
        {
            return _db.Accounts.Login.LoginUser(model);
        }
    }
}
