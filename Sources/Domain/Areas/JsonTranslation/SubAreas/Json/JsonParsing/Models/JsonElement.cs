using System.Collections.Generic;
using Mmu.Mlh.LanguageExtensions.Areas.Types.FunctionsResults;

namespace Mmu.Dt.Domain.Areas.JsonTranslation.SubAreas.Json.JsonParsing.Models
{
    internal abstract class JsonElement
    {
        public string Key
        {
            get
            {
                if (string.IsNullOrEmpty(Parent?.Key))
                {
                    return Name;
                }

                return $"{Parent.Key}_{Name}";
            }
        }

        public string Name { get; }
        public JsonElement Parent { get; }

        public JsonElement(string name, JsonElement parent)
        {
            Name = name;
            Parent = parent;
        }

        public abstract FunctionResult<JsonElement> FindDeepestElement(string objectElementKey);

        public abstract IReadOnlyCollection<JsonValueElement> GetFlatValueElements();
    }
}