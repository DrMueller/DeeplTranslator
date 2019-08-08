using Mmu.Dt.Common.Areas.Settings.Services;
using Mmu.Dt.Common.Areas.Settings.Services.Implementation;
using StructureMap;

namespace Mmu.Dt.Common.Infrastructure.DependencyInjection
{
    public class CommonRegistry : Registry
    {
        public CommonRegistry()
        {
            Scan(scanner =>
            {
                scanner.AssemblyContainingType<CommonRegistry>();
                scanner.WithDefaultConventions();
            });

            For<ISettingsProvider>().Use<SettingsProvider>().Singleton();
        }
    }
}