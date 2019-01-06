using Common.AccountModels;
using Common.Core;
using Common.Interfaces;
using DataAccessLayer.Interfaces;

namespace BusinessLogicLayer.Implementation
{
    public class RegisterRepository : IRegisterRepository
    {
        IDataAccess _db;

        public RegisterRepository(IDataAccess db)
        {
            _db = db;
        }

        public bool CheckLoginForRegister(string login)
        {
            throw new System.NotImplementedException();
        }

        public User RegisterNewUser(RegisterModel model)
        {
            return _db.Accounts.Register.RegisterNewUser(model);
        }
    }
}
