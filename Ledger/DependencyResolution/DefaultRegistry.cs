namespace Ledger.DependencyResolution
{
    using StructureMap;

    public class DefaultRegistry : Registry {
        #region Constructors and Destructors

        public DefaultRegistry() {
            Scan( scan => {
                scan.TheCallingAssembly();
                scan.WithDefaultConventions();
            });
        }

        #endregion
    }
}