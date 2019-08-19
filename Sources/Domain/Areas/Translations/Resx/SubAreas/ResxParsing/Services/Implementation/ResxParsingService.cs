using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Mmu.Dt.Domain.Areas.Translations.Resx.SubAreas.ResxParsing.Models;
using Mmu.Mlh.LanguageExtensions.Areas.Types.Maybes;

namespace Mmu.Dt.Domain.Areas.Translations.Resx.SubAreas.ResxParsing.Services.Implementation
{
    internal class ResxParsingService : IResxParsingService
    {
        public IReadOnlyCollection<DataElement> Parse(string filePath)
        {
            return XDocument
                .Load(filePath)
                .Descendants()
                .Where(f => f.Name == "data")
                .Select(Adapt)
                .ToList();
        }

        private static DataElement Adapt(XElement dataXmlElement)
        {
            var name = dataXmlElement.Attribute("name").Value;
            var value = dataXmlElement.Element("value").Value;

            var commentElement = dataXmlElement.Element("comment");
            var comment =
                commentElement == null ?
                Maybe.CreateNone<string>() :
                Maybe.CreateSome(commentElement.Value);

            return new DataElement(name, value, comment);
        }
    }
}