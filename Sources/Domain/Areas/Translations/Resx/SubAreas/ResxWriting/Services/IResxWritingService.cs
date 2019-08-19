using System.Collections.Generic;
using Mmu.Dt.Domain.Areas.Translations.Resx.SubAreas.ResxParsing.Models;

namespace Mmu.Dt.Domain.Areas.Translations.Resx.SubAreas.ResxWriting.Services
{
    internal interface IResxWritingService
    {
        void WriteResx(IReadOnlyCollection<DataElement> elements, string filePath);
    }
}