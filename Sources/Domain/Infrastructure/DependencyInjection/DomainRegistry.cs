using System.IO.Abstractions;
using Mmu.Dt.Domain.Areas.DeeplManagement.Services;
using Mmu.Dt.Domain.Areas.DeeplManagement.Services.Implementation;
using Mmu.Dt.Domain.Areas.Translations.Common.Services;
using Mmu.Dt.Domain.Areas.Translations.Common.Services.Implementation;
using Mmu.Dt.Domain.Areas.Translations.Json.Orchestration.Services;
using Mmu.Dt.Domain.Areas.Translations.Json.Orchestration.Services.Implementation;
using Mmu.Dt.Domain.Areas.Translations.Json.SubAreas.JsonAlignment.Services;
using Mmu.Dt.Domain.Areas.Translations.Json.SubAreas.JsonAlignment.Services.Implementation;
using Mmu.Dt.Domain.Areas.Translations.Json.SubAreas.JsonComparison.Services;
using Mmu.Dt.Domain.Areas.Translations.Json.SubAreas.JsonComparison.Services.Implementation;
using Mmu.Dt.Domain.Areas.Translations.Json.SubAreas.JsonParsing.Services;
using Mmu.Dt.Domain.Areas.Translations.Json.SubAreas.JsonParsing.Services.Implementation;
using Mmu.Dt.Domain.Areas.Translations.Json.SubAreas.JsonWriting.Services;
using Mmu.Dt.Domain.Areas.Translations.Json.SubAreas.JsonWriting.Services.Implementation;
using Mmu.Dt.Domain.Areas.Translations.Resx.Orchestration.Services;
using Mmu.Dt.Domain.Areas.Translations.Resx.Orchestration.Services.Implementation;
using Mmu.Dt.Domain.Areas.Translations.Resx.SubAreas.ResxAlignment.Services;
using Mmu.Dt.Domain.Areas.Translations.Resx.SubAreas.ResxAlignment.Services.Implementation;
using Mmu.Dt.Domain.Areas.Translations.Resx.SubAreas.ResxComparison.Services;
using Mmu.Dt.Domain.Areas.Translations.Resx.SubAreas.ResxComparison.Services.Implementation;
using Mmu.Dt.Domain.Areas.Translations.Resx.SubAreas.ResxParsing.Services;
using Mmu.Dt.Domain.Areas.Translations.Resx.SubAreas.ResxParsing.Services.Implementation;
using Mmu.Dt.Domain.Areas.Translations.Resx.SubAreas.ResxWriting.Services;
using Mmu.Dt.Domain.Areas.Translations.Resx.SubAreas.ResxWriting.Services.Implementation;
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

            // Translations

            // Common
            For<ITranslationSender>().Use<TranslationSender>().Singleton();

            // Json - Orchestration
            For<IJsonTranslationService>().Use<JsonTranslationService>().Singleton();

            // Json - SubAreas
            For<IJsonParsingService>().Use<JsonParsingService>().Singleton();
            For<IJsonComparisonService>().Use<JsonComparisonService>().Singleton();
            For<IJsonWritingService>().Use<JsonWritingService>().Singleton();
            For<IJsonAlignmentService>().Use<JsonAlignmentService>().Singleton();

            // Resx - Orchestration
            For<IResxTranslationService>().Use<ResxTranslationService>().Singleton();

            // Resx - SubAreas
            For<IResxAlignmentService>().Use<ResxAlignmentService>().Singleton();
            For<IResxComparisonService>().Use<ResxComparisonService>().Singleton();
            For<IResxParsingService>().Use<ResxParsingService>().Singleton();
            For<IResxWritingService>().Use<ResxWritingService>().Singleton();
        }
    }
}