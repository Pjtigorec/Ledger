namespace Ledger.DependencyResolution
{
    using DependencyInjection;
    using StructureMap;

    public static class IoC
    {
        public static IContainer Initialize()
        {
            return new Container(c => c.AddRegistry<MainRegistry>());
        }
    }
}