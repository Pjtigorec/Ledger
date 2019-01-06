using BusinessLogicLayer.Implementation;
using BusinessLogicLayer.Interfaces;
using Common.Interfaces;
using DataAccessLayer;
using DataAccessLayer.Interfaces;
using StructureMap;

namespace BusinessLogicLayer
{
    public class BARegistry : Registry
    {
        public BARegistry()
        {
            For<IBusinessLogic>().Use<BusinessLogic>();
            For<ISubjectRepository>().Use<SubjectRepository>();
            For<ILocationRepository>().Use<LocationRepository>();
            For<IUserRepository>().Use<UserRepository>();
            For<ILoginRepository>().Use<LoginRepository>();
            For<IRegisterRepository>().Use<RegisterRepository>();
            For<IAccountRepository>().Use<AccountRepository>();

            Forward<IDataAccess, DataAccess>();
            Forward<ISubjectRepository, SubjectRepository>();
            Forward<ILocationRepository, LocationRepository>();
            Forward<IUserRepository, UserRepository>();
            Forward<ILoginRepository, LoginRepository>();
            Forward<IRegisterRepository, RegisterRepository>();
            Forward<IAccountRepository, AccountRepository>();
        }
    }
}
