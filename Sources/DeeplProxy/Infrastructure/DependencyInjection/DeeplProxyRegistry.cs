using StructureMap;

namespace Mmu.Dt.DeeplProxy.Infrastructure.DependencyInjection
{
    public class DeeplProxyRegistry : Registry
    {
        public DeeplProxyRegistry()
        {
            Scan(scanner =>
            {
                scanner.AssemblyContainingType<DeeplProxyRegistry>();
                scanner.WithDefaultConventions();
            });
        }
    }
}