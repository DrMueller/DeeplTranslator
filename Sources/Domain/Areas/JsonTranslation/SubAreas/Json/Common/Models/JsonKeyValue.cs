namespace Mmu.Dt.Domain.Areas.JsonTranslation.SubAreas.Json.Common.Models
{
    internal class JsonKeyValue
    {
        public string Key { get; }
        public string Value { get; }

        public JsonKeyValue(string key, string value)
        {
            Key = key;
            Value = value;
        }
    }
}