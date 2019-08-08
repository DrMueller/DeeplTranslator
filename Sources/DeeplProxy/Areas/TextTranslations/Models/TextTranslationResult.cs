using System.Collections.Generic;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Dt.DeeplProxy.Areas.TextTranslations.Models
{
    public class TextTranslationResult
    {
        public IReadOnlyCollection<TranslatedText> TranslatedTexts { get; }

        public TextTranslationResult(IReadOnlyCollection<TranslatedText> translatedTexts)
        {
            Guard.ObjectNotNull(() => translatedTexts);

            TranslatedTexts = translatedTexts;
        }
    }
}