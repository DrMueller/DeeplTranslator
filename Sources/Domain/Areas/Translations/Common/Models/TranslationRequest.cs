using Mmu.Dt.DeeplProxy.Areas.TextTranslations.Models;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;
using Mmu.Mlh.LanguageExtensions.Areas.Types.Maybes;

namespace Mmu.Dt.Domain.Areas.Translations.Common.Models
{
    public class TranslationRequest
    {
        public string SourceFilePath { get; }
        public Maybe<string> SourceLanguageCode { get; }
        public string TargetFilePath { get; }
        public string TargetLanguageCode { get; }

        public TranslationRequest(
            string sourceFilePath,
            Maybe<string> sourceLanguageCode,
            string targetFilePath,
            string targetLanguageCode)
        {
            Guard.StringNotNullOrEmpty(() => sourceFilePath);
            Guard.ObjectNotNull(() => sourceLanguageCode);
            Guard.StringNotNullOrEmpty(() => targetFilePath);
            Guard.StringNotNullOrEmpty(() => targetLanguageCode);

            SourceFilePath = sourceFilePath;
            SourceLanguageCode = sourceLanguageCode;
            TargetFilePath = targetFilePath;
            TargetLanguageCode = targetLanguageCode;
        }
    }
}