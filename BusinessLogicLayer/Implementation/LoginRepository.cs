using Common.Interfaces;
using DataAccessLayer;
using DataAccessLayer.Interfaces;

namespace BusinessLogicLayer.Implementation
{
    public class LoginRepository : ILoginRepository
    {
        IDataAccess _db;

        public LoginRepository(IDataAccess db)
        {
            _db = db as DataAccess;
        }
    }
}
