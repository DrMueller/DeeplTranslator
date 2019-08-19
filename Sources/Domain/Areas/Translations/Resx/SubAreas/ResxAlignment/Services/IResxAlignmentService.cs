using System.Collections.Generic;
using Mmu.Dt.Domain.Areas.Translations.Common.Models;
using Mmu.Dt.Domain.Areas.Translations.Resx.SubAreas.ResxParsing.Models;

namespace Mmu.Dt.Domain.Areas.Translations.Resx.SubAreas.ResxAlignment.Services
{
    internal interface IResxAlignmentService
    {
        IReadOnlyCollection<DataElement> AlignElements(
            string filePath,
            string targetFilePath,
            IReadOnlyCollection<TranslationElement> elements);
    }
}