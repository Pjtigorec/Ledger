using Common.Interfaces;

namespace BusinessLogicLayer.Interfaces
{
    public interface IBusinessLogic
    {
        ISubjectRepository Subjects { get; set; }

        ILocationRepository Locations { get; set; }

        IUserRepository Users { get; set; }

        IAccountRepository Accounts { get; set; }
    }
}
