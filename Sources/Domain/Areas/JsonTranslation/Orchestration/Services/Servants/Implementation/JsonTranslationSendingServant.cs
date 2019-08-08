using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mmu.Dt.DeeplProxy.Areas.TextTranslations.Models;
using Mmu.Dt.DeeplProxy.Areas.TextTranslations.Services;
using Mmu.Dt.Domain.Areas.JsonTranslation.Orchestration.Models;
using Mmu.Dt.Domain.Areas.JsonTranslation.SubAreas.Json.Common.Models;

namespace Mmu.Dt.Domain.Areas.JsonTranslation.Orchestration.Services.Servants.Implementation
{
    internal class JsonTranslationSendingServant : IJsonTranslationSendingServant
    {
        private readonly ITextTranslationRequestFactory _textrequestFactory;
        private readonly ITextTranslationService _textTranslator;

        public JsonTranslationSendingServant(
            ITextTranslationRequestFactory requestFactory,
            ITextTranslationService translationService)
        {
            _textrequestFactory = requestFactory;
            _textTranslator = translationService;
        }

        public async Task<IReadOnlyCollection<JsonKeyValue>> SendElementsAsync(
            JsonTranslationRequest jsonRequest,
            IReadOnlyCollection<JsonKeyValue> elementsToTranslate)
        {
            var translationRequests = CreateRequests(jsonRequest, elementsToTranslate);
            var translationTasks = translationRequests.Select(req => _textTranslator.TranslateAsync(req));
            var translationResults = await Task.WhenAll(translationTasks);

            var allTranslatedTexts = translationResults.SelectMany(res => res.TranslatedTexts);
            var result = allTranslatedTexts.Select(trans => new JsonKeyValue(trans.Text.Key, trans.Text.Text)).ToList();
            return result;
        }

        private IReadOnlyCollection<TextTranslationRequest> CreateRequests(
            JsonTranslationRequest jsonRequest,
            IReadOnlyCollection<JsonKeyValue> elementsToTranslate)
        {
            var textParts = elementsToTranslate.Select(ele => new IdentifiableText(ele.Key, ele.Value)).ToArray();
            var ignoreMarkup = new IgnoreForTranslationMarkup("{{", "}}");
            var translationRequests = _textrequestFactory.CreateRequests(
                jsonRequest.TargetLanguageCode,
                jsonRequest.SourceLanguageCode,
                ignoreMarkup,
                textParts);

            return translationRequests;
        }
    }
}