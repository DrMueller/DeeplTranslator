using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Dt.DeeplProxy.Areas.TextTranslations.Models
{
    public class IgnoreForTranslationMarkup
    {
        public const string IgnoreBeginTag = "<x>";
        public const string IgnoreEndTag = "</x>";

        public string BeginTag { get; }
        public string EndTag { get; }

        public IgnoreForTranslationMarkup(string beginTag, string endTag)
        {
            Guard.StringNotNullOrEmpty(() => beginTag);
            Guard.StringNotNullOrEmpty(() => endTag);

            BeginTag = beginTag;
            EndTag = endTag;
        }
    }
}