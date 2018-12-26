using Common.Interfaces;

namespace DataAccessLayer.Interfaces
{
    public interface IDataAccess
    {
        ISubjectRepository Subjects { get; set; }

        IUserRepository Users { get; set; }

        IAccountRepository Accounts { get; set; }
    }
}
