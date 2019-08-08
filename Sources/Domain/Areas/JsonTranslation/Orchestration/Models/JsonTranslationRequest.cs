using Mmu.Mlh.LanguageExtensions.Areas.Invariance;
using Mmu.Mlh.LanguageExtensions.Areas.Types.Maybes;

namespace Mmu.Dt.Domain.Areas.JsonTranslation.Orchestration.Models
{
    public class JsonTranslationRequest
    {
        public string SourceFilePath { get; }
        public Maybe<string> SourceLanguageCode { get; }
        public string TargetFilePath { get; }
        public string TargetLanguageCode { get; }

        public JsonTranslationRequest(string sourceFilePath, Maybe<string> sourceLanguageCode, string targetFilePath, string targetLanguageCode)
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