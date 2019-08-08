using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.Dt.Domain.Areas.JsonTranslation.Orchestration.Models;
using Mmu.Dt.Domain.Areas.JsonTranslation.SubAreas.Json.Common.Models;

namespace Mmu.Dt.Domain.Areas.JsonTranslation.Orchestration.Services.Servants
{
    internal interface IJsonTranslationSendingServant
    {
        Task<IReadOnlyCollection<JsonKeyValue>> SendElementsAsync(
            JsonTranslationRequest jsonRequest,
            IReadOnlyCollection<JsonKeyValue> elementsToTranslate);
    }
}