using System.IO.Abstractions;
using Mmu.Dt.Domain.Areas.DeeplManagement.Services;
using Mmu.Dt.Domain.Areas.DeeplManagement.Services.Implementation;
using Mmu.Dt.Domain.Areas.JsonTranslation.Orchestration.Services;
using Mmu.Dt.Domain.Areas.JsonTranslation.Orchestration.Services.Implementation;
using Mmu.Dt.Domain.Areas.JsonTranslation.Orchestration.Services.Servants;
using Mmu.Dt.Domain.Areas.JsonTranslation.Orchestration.Services.Servants.Implementation;
using Mmu.Dt.Domain.Areas.JsonTranslation.SubAreas.Json.JsonAlignment.Services;
using Mmu.Dt.Domain.Areas.JsonTranslation.SubAreas.Json.JsonAlignment.Services.Implementation;
using Mmu.Dt.Domain.Areas.JsonTranslation.SubAreas.Json.JsonComparison.Services;
using Mmu.Dt.Domain.Areas.JsonTranslation.SubAreas.Json.JsonComparison.Services.Implementation;
using Mmu.Dt.Domain.Areas.JsonTranslation.SubAreas.Json.JsonParsing.Services;
using Mmu.Dt.Domain.Areas.JsonTranslation.SubAreas.Json.JsonParsing.Services.Implementation;
using Mmu.Dt.Domain.Areas.JsonTranslation.SubAreas.Json.JsonWriting.Services;
using Mmu.Dt.Domain.Areas.JsonTranslation.SubAreas.Json.JsonWriting.Services.Implementation;
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

            // Common
            For<IFileSystem>().Use<FileSystem>().Singleton();

            // DeeplManagement
            For<IDeeplTranslationLanguageFactory>().Use<DeeplTranslationLanguageFactory>().Singleton();

            // JsonTranslation - Orchestration
            For<IJsonTranslationService>().Use<JsonTranslationService>().Singleton();
            For<IJsonTranslationSendingServant>().Use<JsonTranslationSendingServant>().Singleton();

            // JsonTranslation - SubArea Json
            For<IJsonParsingService>().Use<JsonParsingService>().Singleton();
            For<IJsonComparisonService>().Use<JsonComparisonService>().Singleton();
            For<IJsonWritingService>().Use<JsonWritingService>().Singleton();
            For<IJsonAlignmentService>().Use<JsonAlignmentService>().Singleton();
        }
    }
}