using System.Collections.Generic;
using Mmu.Dt.Domain.Areas.Translations.Common.Models;
using Mmu.Dt.Domain.Areas.Translations.Json.SubAreas.JsonParsing.Models;

namespace Mmu.Dt.Domain.Areas.Translations.Json.SubAreas.JsonComparison.Services
{
    internal interface IJsonComparisonService
    {
        IReadOnlyCollection<TranslationElement> CreateElementsToTranslate(
            JsonObjectElement source,
            JsonObjectElement target);
    }
}