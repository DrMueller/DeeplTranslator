using System.Threading.Tasks;
using Mmu.Dt.DeeplProxy.Areas.TextTranslations.Models;
using Mmu.Dt.Domain.Areas.Translations.Common.Models;
using Mmu.Dt.Domain.Areas.Translations.Common.Services;
using Mmu.Dt.Domain.Areas.Translations.Json.SubAreas.JsonAlignment.Services;
using Mmu.Dt.Domain.Areas.Translations.Json.SubAreas.JsonComparison.Services;
using Mmu.Dt.Domain.Areas.Translations.Json.SubAreas.JsonParsing.Services;
using Mmu.Dt.Domain.Areas.Translations.Json.SubAreas.JsonWriting.Services;

namespace Mmu.Dt.Domain.Areas.Translations.Json.Orchestration.Services.Implementation
{
    internal class JsonTranslationService : IJsonTranslationService
    {
        private readonly IJsonAlignmentService _jsonAligner;
        private readonly IJsonComparisonService _jsonComparer;
        private readonly IJsonParsingService _jsonParser;
        private readonly IJsonWritingService _jsonWriter;
        private readonly ITranslationSender _sender;

        public JsonTranslationService(
            IJsonParsingService jsonParser,
            IJsonComparisonService jsonComparer,
            IJsonWritingService jsonWriter,
            IJsonAlignmentService jsonAligner,
            ITranslationSender sender)
        {
            _jsonParser = jsonParser;
            _jsonComparer = jsonComparer;
            _jsonWriter = jsonWriter;
            _jsonAligner = jsonAligner;
            _sender = sender;
        }

        public async Task TranslateAsync(TranslationRequest request)
        {
            var sourceJson = _jsonParser.Parse(request.SourceFilePath);
            var targetJson = _jsonParser.Parse(request.TargetFilePath);
            var elementsToTranslate = _jsonComparer.CreateElementsToTranslate(sourceJson, targetJson);

            if (elementsToTranslate.Count > 0)
            {
                var ignoreMarkup = new IgnoreForTranslationMarkup("{{", "}}");
                var translatedElements = await _sender.SendElementsAsync(
                    request,
                    ignoreMarkup,
                    elementsToTranslate);

                _jsonAligner.AlignRootElement(targetJson, translatedElements);
                _jsonWriter.WriteJson(targetJson, request.TargetFilePath);
            }
        }
    }
}