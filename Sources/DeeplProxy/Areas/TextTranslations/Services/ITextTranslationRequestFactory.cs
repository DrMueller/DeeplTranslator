using System.Collections.Generic;
using Mmu.Dt.DeeplProxy.Areas.TextTranslations.Models;
using Mmu.Mlh.LanguageExtensions.Areas.Types.Maybes;

namespace Mmu.Dt.DeeplProxy.Areas.TextTranslations.Services
{
    public interface ITextTranslationRequestFactory
    {
        public IReadOnlyCollection<TextTranslationRequest> CreateRequests(
            string targetLanguageCode,
            Maybe<string> sourceLanguageCode,
            Maybe<IgnoreForTranslationMarkup> ignoreMarkup,
            params IdentifiableText[] textParts);
    }
}