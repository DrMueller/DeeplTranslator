using System.Collections.Generic;
using System.Linq;
using Mmu.Dt.Domain.Areas.Translations.Common.Models;
using Mmu.Dt.Domain.Areas.Translations.Json.SubAreas.JsonParsing.Models;

namespace Mmu.Dt.Domain.Areas.Translations.Json.SubAreas.JsonComparison.Services.Implementation
{
    internal class JsonComparisonService : IJsonComparisonService
    {
        public IReadOnlyCollection<TranslationElement> CreateElementsToTranslate(
            JsonObjectElement source,
            JsonObjectElement target)
        {
            var sourceValueElements = source.GetFlatValueElements();
            var targetValueElements = target.GetFlatValueElements();

            var missingElements = sourceValueElements.Except(targetValueElements).ToList();
            var result = missingElements.Select(f => new TranslationElement(f.Key, f.Value.ToString())).ToList();
            return result;
        }
    }
}