namespace Mmu.Dt.Domain.Areas.Translations.Common.Models
{
    internal class TranslationElement
    {
        public string Key { get; }
        public string Value { get; }

        public TranslationElement(string key, string value)
        {
            Key = key;
            Value = value;
        }
    }
}