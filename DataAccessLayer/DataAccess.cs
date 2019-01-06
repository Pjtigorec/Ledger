using Common.Interfaces;
using DataAccessLayer.Interfaces;

namespace DataAccessLayer
{
    public class DataAccess : IDataAccess
    {
        public DataAccess(ISubjectRepository subjects, ILocationRepository locations, IUserRepository users, IAccountRepository accounts)
        {
            Subjects = subjects;
            Locations = locations;
            Users = users;
            Accounts = accounts;
        }

        public ISubjectRepository Subjects { get; set; }

        public ILocationRepository Locations { get; set; }

        public IUserRepository Users { get; set; }

        public IAccountRepository Accounts { get; set; }
    }
}
