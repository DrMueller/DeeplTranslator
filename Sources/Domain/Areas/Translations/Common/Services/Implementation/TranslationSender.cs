using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mmu.Dt.DeeplProxy.Areas.TextTranslations.Models;
using Mmu.Dt.DeeplProxy.Areas.TextTranslations.Services;
using Mmu.Dt.Domain.Areas.Translations.Common.Models;

namespace Mmu.Dt.Domain.Areas.Translations.Common.Services.Implementation
{
    internal class TranslationSender : ITranslationSender
    {
        private readonly ITextTranslationRequestFactory _textrequestFactory;
        private readonly ITextTranslationService _textTranslator;

        public TranslationSender(
            ITextTranslationRequestFactory requestFactory,
            ITextTranslationService translationService)
        {
            _textrequestFactory = requestFactory;
            _textTranslator = translationService;
        }

        public async Task<IReadOnlyCollection<TranslationElement>> SendElementsAsync(
            TranslationRequest request,
            IgnoreForTranslationMarkup ignoreMarkup,
            IReadOnlyCollection<TranslationElement> elementsToTranslate)
        {
            var translationRequests = CreateRequests(request, ignoreMarkup, elementsToTranslate);
            var translationTasks = translationRequests.Select(req => _textTranslator.TranslateAsync(req));
            var translationResults = await Task.WhenAll(translationTasks);

            var allTranslatedTexts = translationResults.SelectMany(res => res.TranslatedTexts);
            var result = allTranslatedTexts.Select(trans => new TranslationElement(trans.Text.Key, trans.Text.Text)).ToList();
            return result;
        }

        private IReadOnlyCollection<TextTranslationRequest> CreateRequests(
            TranslationRequest request,
            IgnoreForTranslationMarkup ignoreMarkup,
            IReadOnlyCollection<TranslationElement> elementsToTranslate)
        {
            var textParts = elementsToTranslate.Select(ele => new IdentifiableText(ele.Key, ele.Value)).ToArray();
            var translationRequests = _textrequestFactory.CreateRequests(
                request.TargetLanguageCode,
                request.SourceLanguageCode,
                ignoreMarkup,
                textParts);

            return translationRequests;
        }
    }
}