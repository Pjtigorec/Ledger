using Common.Interfaces;
using DataAccessLayer;
using DataAccessLayer.Interfaces;

namespace BusinessLogicLayer.Implementation
{
    public class RegisterRepository : IRegisterRepository
    {
        IDataAccess _db;

        public RegisterRepository(IDataAccess db)
        {
            _db = db as DataAccess;
        }
    }
}
