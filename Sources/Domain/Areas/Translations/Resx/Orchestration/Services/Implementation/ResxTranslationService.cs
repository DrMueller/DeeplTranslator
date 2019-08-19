using System.Linq;
using System.Threading.Tasks;
using Mmu.Dt.DeeplProxy.Areas.TextTranslations.Models;
using Mmu.Dt.Domain.Areas.Translations.Common.Models;
using Mmu.Dt.Domain.Areas.Translations.Common.Services;
using Mmu.Dt.Domain.Areas.Translations.Resx.SubAreas.ResxAlignment.Services;
using Mmu.Dt.Domain.Areas.Translations.Resx.SubAreas.ResxComparison.Services;
using Mmu.Dt.Domain.Areas.Translations.Resx.SubAreas.ResxWriting.Services;

namespace Mmu.Dt.Domain.Areas.Translations.Resx.Orchestration.Services.Implementation
{
    internal class ResxTranslationService : IResxTranslationService
    {
        private readonly IResxAlignmentService _resxAligner;
        private readonly IResxComparisonService _resxComparer;
        private readonly IResxWritingService _resxWriter;
        private readonly ITranslationSender _translationSender;

        public ResxTranslationService(
            IResxComparisonService resxComparer,
            IResxAlignmentService resxAligner,
            ITranslationSender translationSender,
            IResxWritingService resxWriter)
        {
            _resxComparer = resxComparer;
            _resxAligner = resxAligner;
            _translationSender = translationSender;
            _resxWriter = resxWriter;
        }

        public async Task TranslateAsync(TranslationRequest request)
        {
            var elementsToTranslate = _resxComparer.CreateElementsToTranslate(
                request.SourceFilePath,
                request.TargetFilePath);

            if (!elementsToTranslate.Any())
            {
                return;
            }

            var ignoreMarkup = new IgnoreForTranslationMarkup("{", "}");

            var translatedElements = await _translationSender.SendElementsAsync(
                request,
                ignoreMarkup,
                elementsToTranslate);

            var alignedElements = _resxAligner.AlignElements(
                request.SourceFilePath,
                request.TargetFilePath,
                translatedElements);

            _resxWriter.WriteResx(alignedElements, request.TargetFilePath);
        }
    }
}