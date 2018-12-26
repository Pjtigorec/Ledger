using BusinessLogicLayer.Interfaces;
using Common.Interfaces;

namespace BusinessLogicLayer
{
    public class BusinessLogic : IBusinessLogic
    {
        public BusinessLogic(ISubjectRepository subjects, IUserRepository users, IAccountRepository accounts)
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
