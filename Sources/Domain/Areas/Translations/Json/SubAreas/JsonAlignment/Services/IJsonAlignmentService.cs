using System.Collections.Generic;
using Mmu.Dt.Domain.Areas.Translations.Common.Models;
using Mmu.Dt.Domain.Areas.Translations.Json.SubAreas.JsonParsing.Models;

namespace Mmu.Dt.Domain.Areas.Translations.Json.SubAreas.JsonAlignment.Services
{
    internal interface IJsonAlignmentService
    {
        void AlignRootElement(JsonObjectElement root, IReadOnlyCollection<TranslationElement> elements);
    }
}