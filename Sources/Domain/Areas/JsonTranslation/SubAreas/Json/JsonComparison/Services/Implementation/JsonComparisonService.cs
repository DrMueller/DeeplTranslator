using System.Collections.Generic;
using System.Linq;
using Mmu.Dt.Domain.Areas.JsonTranslation.SubAreas.Json.Common.Models;
using Mmu.Dt.Domain.Areas.JsonTranslation.SubAreas.Json.JsonParsing.Models;

namespace Mmu.Dt.Domain.Areas.JsonTranslation.SubAreas.Json.JsonComparison.Services.Implementation
{
    internal class JsonComparisonService : IJsonComparisonService
    {
        public IReadOnlyCollection<JsonKeyValue> CreateElementsToTranslate(JsonObjectElement source, JsonObjectElement target)
        {
            var sourceValueElements = source.GetFlatValueElements();
            var targetValueElements = target.GetFlatValueElements();

            var missingElements = sourceValueElements.Except(targetValueElements).ToList();
            var result = missingElements.Select(f => new JsonKeyValue(f.Key, f.Value.ToString())).ToList();
            return result;
        }
    }
}