using Common.Interfaces;

namespace DataAccessLayer.Interfaces
{
    public interface IDataAccess
    {
        ISubjectRepository Subjects { get; set; }

        ILocationRepository Locations { get; set; }

        IUserRepository Users { get; set; }

        IAccountRepository Accounts { get; set; }
    }
}
