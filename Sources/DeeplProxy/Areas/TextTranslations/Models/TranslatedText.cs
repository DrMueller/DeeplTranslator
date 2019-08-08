using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Dt.DeeplProxy.Areas.TextTranslations.Models
{
    public class TranslatedText
    {
        public TranslationLanguage DetectedSourceLanguage { get; }
        public IdentifiableText Text { get; }

        public TranslatedText(TranslationLanguage detectedSourceLanguage, IdentifiableText text)
        {
            Guard.ObjectNotNull(() => detectedSourceLanguage);
            Guard.ObjectNotNull(() => text);

            DetectedSourceLanguage = detectedSourceLanguage;
            Text = text;
        }
    }
}