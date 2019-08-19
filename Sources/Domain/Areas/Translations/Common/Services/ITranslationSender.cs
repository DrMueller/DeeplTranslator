using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.Dt.DeeplProxy.Areas.TextTranslations.Models;
using Mmu.Dt.Domain.Areas.Translations.Common.Models;
using Mmu.Mlh.LanguageExtensions.Areas.Types.Maybes;

namespace Mmu.Dt.Domain.Areas.Translations.Common.Services
{
    internal interface ITranslationSender
    {
        Task<IReadOnlyCollection<TranslationElement>> SendElementsAsync(
            TranslationRequest request,
            IgnoreForTranslationMarkup ignoreMarkup,
            IReadOnlyCollection<TranslationElement> elementsToTranslate);
    }
}