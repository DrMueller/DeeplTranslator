using System.Threading.Tasks;
using Mmu.Dt.DeeplProxy.Areas.TextTranslations.Models;

namespace Mmu.Dt.DeeplProxy.Areas.TextTranslations.Services
{
    public interface ITextTranslationService
    {
        Task<TextTranslationResult> TranslateAsync(TextTranslationRequest request);
    }
}