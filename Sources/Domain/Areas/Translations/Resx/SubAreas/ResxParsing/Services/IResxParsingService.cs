using System.Collections.Generic;
using Mmu.Dt.Domain.Areas.Translations.Resx.SubAreas.ResxParsing.Models;

namespace Mmu.Dt.Domain.Areas.Translations.Resx.SubAreas.ResxParsing.Services
{
    internal interface IResxParsingService
    {
        IReadOnlyCollection<DataElement> Parse(string filePath);
    }
}