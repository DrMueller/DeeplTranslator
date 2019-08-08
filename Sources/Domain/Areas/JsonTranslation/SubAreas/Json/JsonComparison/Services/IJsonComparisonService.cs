using System.Collections.Generic;
using Mmu.Dt.Domain.Areas.JsonTranslation.SubAreas.Json.Common.Models;
using Mmu.Dt.Domain.Areas.JsonTranslation.SubAreas.Json.JsonParsing.Models;

namespace Mmu.Dt.Domain.Areas.JsonTranslation.SubAreas.Json.JsonComparison.Services
{
    internal interface IJsonComparisonService
    {
        IReadOnlyCollection<JsonKeyValue> CreateElementsToTranslate(JsonObjectElement sourceFilePath, JsonObjectElement targetFilePath);
    }
}