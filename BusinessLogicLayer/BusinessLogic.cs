using BusinessLogicLayer.Interfaces;
using Common.Interfaces;

namespace BusinessLogicLayer
{
    public class BusinessLogic : IBusinessLogic
    {
        public BusinessLogic(ISubjectRepository subjects, ILocationRepository locations, IUserRepository users, IAccountRepository accounts)
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
