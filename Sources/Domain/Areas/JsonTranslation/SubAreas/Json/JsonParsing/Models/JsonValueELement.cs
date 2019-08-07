using System;
using System.Collections.Generic;
using Mmu.Mlh.LanguageExtensions.Areas.Types.FunctionsResults;

namespace Mmu.Dt.Domain.Areas.JsonTranslation.SubAreas.Json.JsonParsing.Models
{
    public class JsonValueElement : JsonElement, IEquatable<JsonValueElement>
    {
        public object Value { get; private set; }

        public JsonValueElement(string name, JsonElement parent, object value)
            : base(name, parent)
        {
            Value = value;
        }

        public static bool operator !=(JsonValueElement a, JsonValueElement b)
        {
            return !(a == b);
        }

        public static bool operator ==(JsonValueElement a, JsonValueElement b)
        {
            if (ReferenceEquals(null, a) && ReferenceEquals(null, b))
            {
                return true;
            }

            if (!ReferenceEquals(null, a) && a.Equals(b))
            {
                return true;
            }

            return false;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj.GetType() == GetType() && Equals((JsonValueElement)obj);
        }

        public bool Equals(JsonValueElement other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            return other.Key == Key;
        }

        public override FunctionResult<JsonElement> FindDeepestElement(string key)
        {
            if (key == Key)
            {
                FunctionResult.CreateSuccess(this);
            }

            return FunctionResult.CreateFailure<JsonElement>();
        }

        public override int GetHashCode()
        {
            return Key.GetHashCode(StringComparison.Ordinal);
        }

        public override IReadOnlyCollection<JsonValueElement> GetValueElements()
        {
            return new List<JsonValueElement> { this };
        }

        public void ReplaceValue(object newValue)
        {
            Value = newValue;
        }
    }
}