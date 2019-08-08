using System.Collections.Generic;
using Mmu.Dt.Domain.Areas.JsonTranslation.SubAreas.Json.Common.Models;
using Mmu.Dt.Domain.Areas.JsonTranslation.SubAreas.Json.JsonParsing.Models;

namespace Mmu.Dt.Domain.Areas.JsonTranslation.SubAreas.Json.JsonAlignment.Services
{
    internal interface IJsonAlignmentService
    {
        void AlignRootElement(JsonObjectElement root, IReadOnlyCollection<JsonKeyValue> keyValues);
    }
}