using System.Threading.Tasks;
using Mmu.Dt.Domain.Areas.Translations.Common.Models;

namespace Mmu.Dt.Domain.Areas.Translations.Resx.Orchestration.Services
{
    public interface IResxTranslationService
    {
        Task TranslateAsync(TranslationRequest request);
    }
}