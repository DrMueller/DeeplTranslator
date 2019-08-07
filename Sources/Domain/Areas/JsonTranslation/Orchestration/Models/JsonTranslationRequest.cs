using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Dt.Domain.Areas.JsonTranslation.Orchestration.Models
{
    public class JsonTranslationRequest
    {
        public string SourceFilePath { get; }
        public string SourceLanguageCode { get; }
        public string TargetFilePath { get; }
        public string TargetLanguageCode { get; }

        public JsonTranslationRequest(string sourceFilePath, string sourceLanguageCode, string targetFilePath, string targetLanguageCode)
        {
            Guard.StringNotNullOrEmpty(() => sourceFilePath);
            Guard.StringNotNullOrEmpty(() => sourceLanguageCode);
            Guard.StringNotNullOrEmpty(() => targetFilePath);
            Guard.StringNotNullOrEmpty(() => targetLanguageCode);

            SourceFilePath = sourceFilePath;
            SourceLanguageCode = sourceLanguageCode;
            TargetFilePath = targetFilePath;
            TargetLanguageCode = targetLanguageCode;
        }
    }
}