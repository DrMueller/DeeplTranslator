using System.IO;
using System.Threading.Tasks;
using Mmu.Dt.DeeplProxy.Areas.Services;
using Mmu.Dt.Domain.Areas.JsonTranslation.Orchestration.Models;
using Mmu.Dt.Domain.Areas.JsonTranslation.SubAreas.Json.JsonAlignment.Services;
using Mmu.Dt.Domain.Areas.JsonTranslation.SubAreas.Json.JsonComparison.Services;
using Mmu.Dt.Domain.Areas.JsonTranslation.SubAreas.Json.JsonParsing.Services;
using Mmu.Dt.Domain.Areas.JsonTranslation.SubAreas.Json.JsonWriting.Services;

namespace Mmu.Dt.Domain.Areas.JsonTranslation.Orchestration.Services.Implementation
{
    public class JsonTranslationService : IJsonTranslationService
    {
        private readonly IJsonAlignmentService _jsonAligner;
        private readonly IJsonComparisonService _jsonComparer;
        private readonly IJsonParsingService _jsonParser;
        private readonly IJsonWritingService _jsonWriter;
        private readonly ITestService _testService;

        public JsonTranslationService(
            ITestService testService,
            IJsonParsingService jsonParser,
            IJsonComparisonService jsonComparer,
            IJsonWritingService jsonWriter,
            IJsonAlignmentService jsonAligner)
        {
            _testService = testService;
            _jsonParser = jsonParser;
            _jsonComparer = jsonComparer;
            _jsonWriter = jsonWriter;
            _jsonAligner = jsonAligner;
        }

        public async Task TranslateAsync(JsonTranslationRequest request)
        {
            var sourceJson = _jsonParser.Parse(request.SourceFilePath);
            var targetJson = _jsonParser.Parse(request.TargetFilePath);

            var elementsToTranslate = _jsonComparer.CreateElementsToTranslate(sourceJson, targetJson);

            // TODO, how to handle variable names? try to escape them for Deepl kindahow
            // await _testService.TestAsync();

            _jsonAligner.AlignRootElement(targetJson, elementsToTranslate);
            var newPath = Path.GetDirectoryName(request.SourceFilePath) + "\\tra.json";

            _jsonWriter.WriteJson(targetJson, newPath);
        }
    }
}