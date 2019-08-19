using System.Collections.Generic;
using System.Linq;
using Mmu.Dt.Domain.Areas.Translations.Common.Models;
using Mmu.Dt.Domain.Areas.Translations.Resx.SubAreas.ResxParsing.Models;
using Mmu.Dt.Domain.Areas.Translations.Resx.SubAreas.ResxParsing.Services;

namespace Mmu.Dt.Domain.Areas.Translations.Resx.SubAreas.ResxAlignment.Services.Implementation
{
    internal class ResxAlignmentService : IResxAlignmentService
    {
        private readonly IResxParsingService _resxParser;

        public ResxAlignmentService(IResxParsingService resxParser)
        {
            _resxParser = resxParser;
        }

        public IReadOnlyCollection<DataElement> AlignElements(
            string sourceFilePath,
            string targetFilePath,
            IReadOnlyCollection<TranslationElement> elements)
        {
            var sourceElements = _resxParser.Parse(sourceFilePath).ToList();
            var targetElements = _resxParser.Parse(targetFilePath).ToList();
            var newList = new List<DataElement>();

            for (var i = 0; i < sourceElements.Count; i++)
            {
                var sourceElement = sourceElements.ElementAt(i);
                newList.Insert(i, FindElement(sourceElement.Name, sourceElement, targetElements, elements));
            }

            return newList;
        }

        private static DataElement FindElement(
            string elementName,
            DataElement sourceElement,
            IEnumerable<DataElement> targetElements,
            IEnumerable<TranslationElement> translatedElements)
        {
            var element = targetElements.FirstOrDefault(f => f.Name == elementName);
            if (element != null)
            {
                return element;
            }

            var translation = translatedElements.Single(f => f.Key == elementName);
            return new DataElement(translation.Key, translation.Value, sourceElement.Comment);
        }
    }
}