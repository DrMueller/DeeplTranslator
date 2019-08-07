using System;
using System.Collections.Generic;
using System.Linq;
using Mmu.Mlh.LanguageExtensions.Areas.Types.FunctionsResults;

namespace Mmu.Dt.Domain.Areas.JsonTranslation.SubAreas.Json.JsonParsing.Models
{
    public class JsonObjectElement : JsonElement
    {
        private List<JsonElement> _children = new List<JsonElement>();
        public IReadOnlyCollection<JsonElement> Children => _children;

        public JsonObjectElement(string name, JsonElement parent)
            : base(name, parent)
        {
        }

        public JsonObjectElement AddObjectElement(string name)
        {
            var objElement = new JsonObjectElement(name, this);
            _children.Add(objElement);
            return objElement;
        }

        public void AddValueElement(string name, object value)
        {
            _children.Add(new JsonValueElement(name, this, value));
        }

        public override FunctionResult<JsonElement> FindDeepestElement(string objectElementKey)
        {
            if (objectElementKey.StartsWith(Key, StringComparison.OrdinalIgnoreCase))
            {
                var deeperChild = _children.Select(f => f.FindDeepestElement(objectElementKey)).FirstOrDefault(f => f.IsSuccess);
                if (deeperChild != null)
                {
                    return deeperChild;
                }
                else
                {
                    return FunctionResult.CreateSuccess<JsonElement>(this);
                }
            }
            else
            {
                return FunctionResult.CreateFailure<JsonElement>();
            }
        }

        public IReadOnlyCollection<JsonValueElement> GetFlatValueElements()
        {
            return Children.SelectMany(f => f.GetValueElements()).ToList();
        }

        public override IReadOnlyCollection<JsonValueElement> GetValueElements()
        {
            return _children.SelectMany(f => f.GetValueElements()).ToList();
        }
    }
}