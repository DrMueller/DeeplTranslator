using System.Collections.Generic;
using Mmu.Dt.Domain.Areas.JsonTranslation.SubAreas.Json.Common.Models;
using Mmu.Dt.Domain.Areas.JsonTranslation.SubAreas.Json.JsonParsing.Models;

namespace Mmu.Dt.Domain.Areas.JsonTranslation.SubAreas.Json.JsonComparison.Services
{
    public interface IJsonComparisonService
    {
        IReadOnlyCollection<JsonKeyValue> CreateElementsToTranslate(JsonObjectElement source, JsonObjectElement target);
    }
}