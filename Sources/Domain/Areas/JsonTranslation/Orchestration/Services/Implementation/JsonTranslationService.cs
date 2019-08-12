using System.Threading.Tasks;
using Mmu.Dt.Domain.Areas.JsonTranslation.Orchestration.Models;
using Mmu.Dt.Domain.Areas.JsonTranslation.Orchestration.Services.Servants;
using Mmu.Dt.Domain.Areas.JsonTranslation.SubAreas.Json.JsonAlignment.Services;
using Mmu.Dt.Domain.Areas.JsonTranslation.SubAreas.Json.JsonComparison.Services;
using Mmu.Dt.Domain.Areas.JsonTranslation.SubAreas.Json.JsonParsing.Services;
using Mmu.Dt.Domain.Areas.JsonTranslation.SubAreas.Json.JsonWriting.Services;

namespace Mmu.Dt.Domain.Areas.JsonTranslation.Orchestration.Services.Implementation
{
    internal class JsonTranslationService : IJsonTranslationService
    {
        private readonly IJsonAlignmentService _jsonAligner;
        private readonly IJsonComparisonService _jsonComparer;
        private readonly IJsonParsingService _jsonParser;
        private readonly IJsonWritingService _jsonWriter;
        private readonly IJsonTranslationSendingServant _sender;

        public JsonTranslationService(
            IJsonParsingService jsonParser,
            IJsonComparisonService jsonComparer,
            IJsonWritingService jsonWriter,
            IJsonAlignmentService jsonAligner,
            IJsonTranslationSendingServant sender)
        {
            _jsonParser = jsonParser;
            _jsonComparer = jsonComparer;
            _jsonWriter = jsonWriter;
            _jsonAligner = jsonAligner;
            _sender = sender;
        }

        public async Task TranslateAsync(JsonTranslationRequest request)
        {
            var sourceJson = _jsonParser.Parse(request.SourceFilePath);
            var targetJson = _jsonParser.Parse(request.TargetFilePath);
            var elementsToTranslate = _jsonComparer.CreateElementsToTranslate(sourceJson, targetJson);

            if (elementsToTranslate.Count > 0)
            {
                var translatedElements = await _sender.SendElementsAsync(request, elementsToTranslate);
                _jsonAligner.AlignRootElement(targetJson, elementsToTranslate);
                _jsonWriter.WriteJson(targetJson, request.TargetFilePath);
            }
        }
    }
}