using System.Collections.Generic;
using Mmu.Dt.Domain.Areas.Translations.Common.Models;

namespace Mmu.Dt.Domain.Areas.Translations.Resx.SubAreas.ResxComparison.Services
{
    internal interface IResxComparisonService
    {
        IReadOnlyCollection<TranslationElement> CreateElementsToTranslate(
            string sourceFilePath,
            string targetFilePath);
    }
}