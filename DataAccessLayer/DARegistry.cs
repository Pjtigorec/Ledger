using Common.Interfaces;
using DataAccessLayer.Implementation;
using DataAccessLayer.Interfaces;
using StructureMap;

namespace DataAccessLayer
{
    public class DARegistry : Registry
    {
        public DARegistry()
        {
            For<IDataAccess>().Use<DataAccess>();
            For<ISubjectRepository>().Use<SubjectRepository>();
            For<IUserRepository>().Use<UserRepository>();
            For<ILoginRepository>().Use<LoginRepository>();
            For<IRegisterRepository>().Use<RegisterRepository>();
            For<IAccountRepository>().Use<AccountRepository>();
        }
    }
}
