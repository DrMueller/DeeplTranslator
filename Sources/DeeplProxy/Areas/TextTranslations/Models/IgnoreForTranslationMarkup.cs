using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Dt.DeeplProxy.Areas.TextTranslations.Models
{
    public class IgnoreForTranslationMarkup
    {
        public const string IgnoreTag = "x";
        public static readonly string IgnoreBeginTag = $"<{IgnoreTag}>";
        public static readonly string IgnoreEndTag = $"</{IgnoreTag}>";
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