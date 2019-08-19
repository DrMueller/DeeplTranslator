using System.Collections.Generic;
using System.Linq;
using Mmu.Dt.Domain.Areas.Translations.Common.Models;
using Mmu.Dt.Domain.Areas.Translations.Resx.SubAreas.ResxComparison.Services.Servants;
using Mmu.Dt.Domain.Areas.Translations.Resx.SubAreas.ResxParsing.Services;

namespace Mmu.Dt.Domain.Areas.Translations.Resx.SubAreas.ResxComparison.Services.Implementation
{
    internal class ResxComparisonService : IResxComparisonService
    {
        private readonly IResxParsingService _resxParser;

        public ResxComparisonService(IResxParsingService resxParser)
        {
            _resxParser = resxParser;
        }

        public IReadOnlyCollection<TranslationElement> CreateElementsToTranslate(
            string sourceFilePath,
            string targetFilePath)
        {
            var sourceDataElements = _resxParser.Parse(sourceFilePath);
            var targetDataElements = _resxParser.Parse(targetFilePath);

            var missingElements =
                sourceDataElements
                .Except(targetDataElements, new DataElementEqualityComparer())
                .Select(f => new TranslationElement(f.Name, f.Value))
                .ToList();

            return missingElements;
        }
    }
}