using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Mmu.Dt.Domain.Areas.JsonTranslation.SubAreas.Json.Common.Models;
using Mmu.Dt.Domain.Areas.JsonTranslation.SubAreas.Json.JsonAlignment.Models;
using Mmu.Dt.Domain.Areas.JsonTranslation.SubAreas.Json.JsonParsing.Models;
using Mmu.Mlh.LanguageExtensions.Areas.Collections;

namespace Mmu.Dt.Domain.Areas.JsonTranslation.SubAreas.Json.JsonAlignment.Services.Implementation
{
    internal class JsonAlignmentService : IJsonAlignmentService
    {
        public void AlignRootElement(JsonObjectElement root, IReadOnlyCollection<JsonKeyValue> keyValues)
        {
            keyValues.ForEach(f => AlignKeyValue(root, f));
        }

        private static void AlignKeyValue(JsonObjectElement root, JsonKeyValue keyValue)
        {
            var jsonKey = JsonKey.Create(keyValue.Key);
            var depeestElementResult = root.Children.Select(f => f.FindDeepestElement(jsonKey.FullKey)).FirstOrDefault(f => f.IsSuccess)?.Value ?? root;

            if (depeestElementResult is JsonObjectElement objectElement)
            {
                var missingKeyParts = jsonKey.FetchMissingObjectElementKeyParts(objectElement.Key);
                Debug.WriteLine(objectElement.Key);

                if (objectElement.Key == "areas_home_welcome_components_welcome")
                {
                    Debugger.Break();
                }

                objectElement = AlignObjectStructure(objectElement, missingKeyParts);
                objectElement.AddValueElement(jsonKey.ValueElementKey, keyValue.Value);
            }
            else
            {
                var valueElement = depeestElementResult as JsonValueElement;
                if (valueElement != null)
                {
                    valueElement.ReplaceValue(keyValue.Value);
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