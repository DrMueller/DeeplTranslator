using System.Collections.Generic;
using System.Linq;
using Mmu.Dt.Domain.Areas.Translations.Common.Models;
using Mmu.Dt.Domain.Areas.Translations.Json.SubAreas.JsonAlignment.Models;
using Mmu.Dt.Domain.Areas.Translations.Json.SubAreas.JsonParsing.Models;
using Mmu.Mlh.LanguageExtensions.Areas.Collections;

namespace Mmu.Dt.Domain.Areas.Translations.Json.SubAreas.JsonAlignment.Services.Implementation
{
    internal class JsonAlignmentService : IJsonAlignmentService
    {
        public void AlignRootElement(JsonObjectElement root, IReadOnlyCollection<TranslationElement> elements)
        {
            elements.ForEach(f => AlignKeyValue(root, f));
        }

        private static void AlignKeyValue(JsonObjectElement root, TranslationElement element)
        {
            var jsonKey = JsonKey.Create(element.Key);

            var depeestElementResult = root.Children
                .Select(f => f.FindDeepestElement(jsonKey.FullKey))
                .FirstOrDefault(f => f.IsSuccess)?.Value ?? root;

            if (depeestElementResult is JsonObjectElement objectElement)
            {
                var missingKeyParts = jsonKey.FetchMissingObjectElementKeyParts(objectElement.Key);
                objectElement = AlignObjectStructure(objectElement, missingKeyParts);
                objectElement.AddValueElement(jsonKey.ValueElementKey, element.Value);
            }
            else
            {
                var valueElement = depeestElementResult as JsonValueElement;
                if (valueElement != null)
                {
                    valueElement.ReplaceValue(element.Value);
                }
            }
        }

        private static JsonObjectElement AlignObjectStructure(JsonObjectElement element, IReadOnlyCollection<string> missingKeyParts)
        {
            foreach (var keyPart in missingKeyParts)
            {
                element = element.AddObjectElement(keyPart);
            }

            return element;
        }
    }
}