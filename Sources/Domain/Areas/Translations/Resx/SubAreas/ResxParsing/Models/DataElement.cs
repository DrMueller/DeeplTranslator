using Mmu.Mlh.LanguageExtensions.Areas.Invariance;
using Mmu.Mlh.LanguageExtensions.Areas.Types.Maybes;

namespace Mmu.Dt.Domain.Areas.Translations.Resx.SubAreas.ResxParsing.Models
{
    internal class DataElement
    {
        public Maybe<string> Comment { get; }
        public string Name { get; }
        public string Value { get; }

        public DataElement(
            string name,
            string value,
            Maybe<string> comment)
        {
            Guard.StringNotNullOrEmpty(() => name);
            Guard.ObjectNotNull(() => value);
            Guard.ObjectNotNull(() => comment);

            Name = name;
            Value = value;
            Comment = comment;
        }
    }
}