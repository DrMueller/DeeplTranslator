using System.Threading.Tasks;
using Mmu.Dt.Domain.Areas.JsonTranslation.Orchestration.Models;

namespace Mmu.Dt.Domain.Areas.JsonTranslation.Orchestration.Services
{
    public interface IJsonTranslationService
    {
        Task TranslateAsync(JsonTranslationRequest request);
    }
}