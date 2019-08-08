using System;
using System.Collections.Generic;
using System.Linq;
using Mmu.Dt.DeeplProxy.Areas.TextTranslations.DeeplResponses;
using Mmu.Dt.DeeplProxy.Areas.TextTranslations.Models;

namespace Mmu.Dt.DeeplProxy.Areas.TextTranslations.Services.Servants.Implementation
{
    internal class TextTranslationResultAdapter : ITextTranslationResultAdapter
    {
        public TextTranslationResult Adapt(TextTranslationRequest request, TextTranslationResultDto resultDto)
        {
            var translations = new List<TranslatedText>();

            for (var i = 0; i < resultDto.Translations.Count; i++)
            {
                var translationDto = resultDto.Translations.ElementAt(i);
                var detectedSourceLanguage = TranslationLanguage.CreateByCode(translationDto.Detected_source_language);
                var textKey = request.TextParts.ElementAt(i).Key;
                var text = translationDto.Text;

                request.IgnoreMarkup.Evaluate(markup =>
                {
                    text = text.Replace(IgnoreForTranslationMarkup.IgnoreBeginTag, markup.BeginTag, StringComparison.Ordinal);
                    text = text.Replace(IgnoreForTranslationMarkup.IgnoreEndTag, markup.EndTag, StringComparison.Ordinal);
                });

                var identifiableText = new IdentifiableText(textKey, text);
                translations.Add(new TranslatedText(detectedSourceLanguage, identifiableText));
            }

            var result = new TextTranslationResult(translations);
            return result;
        }
    }
}