using Common.Interfaces;

namespace DataAccessLayer.Implementation
{
    public class AccountRepository : IAccountRepository
    {
        public AccountRepository(ILoginRepository logins, IRegisterRepository registers)
        {
            Login = logins;
            Register = registers;
        }

        public ILoginRepository Login { get; set; }

        public IRegisterRepository Register { get; set; }
    }
}
