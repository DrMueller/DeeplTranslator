using System.Collections.Generic;
using System.Linq;
using Mmu.Dt.DeeplProxy.Areas.TextTranslations.Models;
using Mmu.Mlh.LanguageExtensions.Areas.Collections;
using Mmu.Mlh.LanguageExtensions.Areas.Types.Maybes;

namespace Mmu.Dt.DeeplProxy.Areas.TextTranslations.Services.Implementation
{
    internal class TextTranslationRequestFactory : ITextTranslationRequestFactory
    {
        public IReadOnlyCollection<TextTranslationRequest> CreateRequests(
            string targetLanguageCode,
            Maybe<string> sourceLanguageCode,
            Maybe<IgnoreForTranslationMarkup> ignoreMarkup,
            params IdentifiableText[] textParts)
        {
            var targetLanguage = TranslationLanguage.CreateByCode(targetLanguageCode);
            var sourceLanguage = sourceLanguageCode.Evaluate(
                code => Maybe.CreateSome(TranslationLanguage.CreateByCode(code)),
                () => Maybe.CreateNone<TranslationLanguage>());

            var textPartChunks = textParts.Chunk(TextTranslationRequest.MaxTextParts);
            var result = textPartChunks
                .Select(chunk => new TextTranslationRequest(targetLanguage, sourceLanguage, ignoreMarkup, chunk.ToList()))
                .ToList();

            return result;
        }
    }
}