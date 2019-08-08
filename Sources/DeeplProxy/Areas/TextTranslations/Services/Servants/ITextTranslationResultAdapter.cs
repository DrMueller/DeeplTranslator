using Mmu.Dt.DeeplProxy.Areas.TextTranslations.DeeplResponses;
using Mmu.Dt.DeeplProxy.Areas.TextTranslations.Models;

namespace Mmu.Dt.DeeplProxy.Areas.TextTranslations.Services.Servants
{
    internal interface ITextTranslationResultAdapter
    {
        public TextTranslationResult Adapt(TextTranslationRequest request, TextTranslationResultDto resultDto);
    }
}