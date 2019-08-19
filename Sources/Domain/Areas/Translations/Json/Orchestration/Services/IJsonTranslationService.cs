using System.Threading.Tasks;
using Mmu.Dt.Domain.Areas.Translations.Common.Models;

namespace Mmu.Dt.Domain.Areas.Translations.Json.Orchestration.Services
{
    public interface IJsonTranslationService
    {
        Task TranslateAsync(TranslationRequest request);
    }
}