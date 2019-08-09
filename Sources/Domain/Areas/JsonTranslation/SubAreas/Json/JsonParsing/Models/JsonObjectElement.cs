using System;
using System.Collections.Generic;
using System.Linq;
using Mmu.Mlh.LanguageExtensions.Areas.Types.FunctionsResults;

namespace Mmu.Dt.Domain.Areas.JsonTranslation.SubAreas.Json.JsonParsing.Models
{
    internal class JsonObjectElement : JsonElement
    {
        private SortedList<string, JsonElement> _children = new SortedList<string, JsonElement>();
        public IReadOnlyCollection<JsonElement> Children => _children.Select(f => f.Value).ToList();

        public JsonObjectElement(string name, JsonElement parent)
            : base(name, parent)
        {
        }

        public JsonObjectElement AddObjectElement(string name)
        {
            var objElement = new JsonObjectElement(name, this);
            _children.Add(name, objElement);
            return objElement;
        }

        public void AddValueElement(string name, object value)
        {
            _children.Add(name, new JsonValueElement(name, this, value));
        }

        public override FunctionResult<JsonElement> FindDeepestElement(string objectElementKey)
        {
            if (objectElementKey.StartsWith(Key, StringComparison.OrdinalIgnoreCase))
            {
                var deeperChild = _children.Select(child => child.Value.FindDeepestElement(objectElementKey)).FirstOrDefault(f => f.IsSuccess);
                return deeperChild ?? FunctionResult.CreateSuccess<JsonElement>(this);
            }
            else
            {
                return FunctionResult.CreateFailure<JsonElement>();
            }
        }

        public override IReadOnlyCollection<JsonValueElement> GetFlatValueElements()
        {
            return _children.SelectMany(child => child.Value.GetFlatValueElements()).ToList();
        }
    }
}