using System.IO.Abstractions;
using Mmu.Dt.Domain.Areas.Translations.Json.SubAreas.JsonParsing.Models;
using Mmu.Mlh.LanguageExtensions.Areas.Collections;
using Newtonsoft.Json.Linq;

namespace Mmu.Dt.Domain.Areas.Translations.Json.SubAreas.JsonWriting.Services.Implementation
{
    internal class JsonWritingService : IJsonWritingService
    {
        private readonly IFileSystem _fileSystem;

        public JsonWritingService(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;
        }

        public void WriteJson(JsonObjectElement rootElement, string filePath)
        {
            var rootObj = new JObject();
            rootElement.Children.ForEach(child => AppendRecursive(rootObj, child));
            _fileSystem.File.WriteAllText(filePath, rootObj.ToString());
        }

        private void AppendRecursive(JObject jobj, JsonElement element)
        {
            var valueElement = element as JsonValueElement;
            if (valueElement != null)
            {
                jobj.Add(new JProperty(valueElement.Name, valueElement.Value));
            }
            else
            {
                var objectElement = element as JsonObjectElement;
                var subObj = new JObject();
                jobj.Add(new JProperty(element.Name, subObj));
                objectElement.Children.ForEach(child => AppendRecursive(subObj, child));
            }
        }
    }
}