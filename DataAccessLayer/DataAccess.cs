using Common.Interfaces;
using DataAccessLayer.Interfaces;

namespace DataAccessLayer
{
    public class DataAccess : IDataAccess
    {
        public DataAccess(ISubjectRepository subjects, IUserRepository users, IAccountRepository accounts)
        {
            Subjects = subjects;
            Users = users;
            Accounts = accounts;
        }

        public ISubjectRepository Subjects { get; set; }

        public IUserRepository Users { get; set; }

        public IAccountRepository Accounts { get; set; }
    }
}
