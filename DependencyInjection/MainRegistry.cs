using BusinessLogicLayer;
using DataAccessLayer;
using StructureMap;

namespace DependencyInjection
{
    public class MainRegistry : Registry
    {
        public MainRegistry()
        {
            Scan(
                scan => {
                    scan.WithDefaultConventions();
                    scan.AssemblyContainingType<BusinessLogic>();
                    scan.AssemblyContainingType<DataAccess>();
                    scan.LookForRegistries();
                });
        }
    }
}
