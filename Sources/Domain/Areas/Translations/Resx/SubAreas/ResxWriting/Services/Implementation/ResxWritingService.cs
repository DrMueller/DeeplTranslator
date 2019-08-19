using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Mmu.Dt.Domain.Areas.Translations.Resx.SubAreas.ResxParsing.Models;
using Mmu.Mlh.LanguageExtensions.Areas.Collections;

namespace Mmu.Dt.Domain.Areas.Translations.Resx.SubAreas.ResxWriting.Services.Implementation
{
    internal class ResxWritingService : IResxWritingService
    {
        public void WriteResx(
            IReadOnlyCollection<DataElement> elements,
            string filePath)
        {
            var doc = XDocument.Load(filePath);
            doc.Descendants("data").Remove();
            var rootElement = doc.Descendants("root").Single();
            elements.ForEach(element => AppendElement(rootElement, element));
            doc.Save(filePath);
        }

        private static void AppendElement(XElement root, DataElement element)
        {
            var valueElement = new XElement("value", element.Value);
            var dataElement = new XElement("data", valueElement);
            dataElement.Add(new XAttribute("name", element.Name));
            dataElement.Add(new XAttribute(XNamespace.Xml + "space", "preserve"));

            element.Comment.Evaluate(comment =>
            {
                dataElement.Add(new XElement("comment", comment));
            });

            root.Add(dataElement);
        }
    }
}