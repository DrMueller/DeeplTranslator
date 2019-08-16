using System.Collections.Generic;
using Mmu.Mlh.LanguageExtensions.Areas.Collections;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;
using Mmu.Mlh.LanguageExtensions.Areas.Types.Maybes;
using Mmu.Mlh.RestExtensions.Areas.RestCallBuilding;

namespace Mmu.Dt.DeeplProxy.Areas.TextTranslations.Models
{
    public class TextTranslationRequest
    {
        public const int MaxTextParts = 50;

        public Maybe<IgnoreForTranslationMarkup> IgnoreMarkup { get; }
        public Maybe<TranslationLanguage> SourceLanguage { get; }
        public TranslationLanguage TargetLanguage { get; }
        public IReadOnlyCollection<IdentifiableText> TextParts { get; }

        internal TextTranslationRequest(
            TranslationLanguage targetLanguage,
            Maybe<TranslationLanguage> sourceLanguage,
            Maybe<IgnoreForTranslationMarkup> ignoreMarkup,
            IReadOnlyCollection<IdentifiableText> textParts)
        {
            Guard.ObjectNotNull(() => targetLanguage);
            Guard.ObjectNotNull(() => sourceLanguage);
            Guard.ObjectNotNull(() => ignoreMarkup);
            Guard.ObjectNotNull(() => textParts);
            Guard.That(() => textParts.Count <= MaxTextParts, "Only to 50 text parameters can be submitted in one request.");

            TargetLanguage = targetLanguage;
            SourceLanguage = sourceLanguage;
            IgnoreMarkup = ignoreMarkup;
            TextParts = textParts;
        }

        internal void ApplyIgnoreMarkUp(IRestCallBuilder builder)
        {
            IgnoreMarkup.Evaluate(markup =>
            {
                TextParts.ForEach(part => part.ReplaceTextmarks(markup.BeginTag, IgnoreForTranslationMarkup.IgnoreBeginTag));
                TextParts.ForEach(part => part.ReplaceTextmarks(markup.EndTag, IgnoreForTranslationMarkup.IgnoreEndTag));

                builder
                    .WithQueryParameter("tag_handling", "xml")
                    .WithQueryParameter("ignore_tags", IgnoreForTranslationMarkup.IgnoreTag);
            });
        }
    }
}