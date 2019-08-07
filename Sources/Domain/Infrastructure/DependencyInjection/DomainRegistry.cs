using System.IO.Abstractions;
using StructureMap;

namespace Mmu.Dt.Domain.Infrastructure.DependencyInjection
{
    public class DomainRegistry : Registry
    {
        public DomainRegistry()
        {
            Scan(scanner =>
            {
                scanner.AssemblyContainingType<DomainRegistry>();
                scanner.WithDefaultConventions();
            });

            For<IFileSystem>().Use<FileSystem>().Singleton();
        }
    }
}