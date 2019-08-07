using System.IO.Abstractions;
using Mmu.Dt.Domain.Areas.JsonTranslation.SubAreas.Json.JsonParsing.Models;
using Newtonsoft.Json.Linq;

namespace Mmu.Dt.Domain.Areas.JsonTranslation.SubAreas.Json.JsonParsing.Services.Implementation
{
    public class JsonParsingService : IJsonParsingService
    {
        private readonly IFileSystem _fileSystem;

        public JsonParsingService(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;
        }

        public JsonObjectElement Parse(string filePath)
        {
            var jsonText = _fileSystem.File.ReadAllText(filePath);
            var rootObjectElement = new JsonObjectElement(string.Empty, null);

            if (string.IsNullOrEmpty(jsonText))
            {
                return rootObjectElement;
            }

            var jObject = JObject.Parse(jsonText);
            CreateRecursive(jObject, rootObjectElement);
            return rootObjectElement;
        }

        private void CreateRecursive(JObject jobj, JsonObjectElement objectElement)
        {
            foreach (var property in jobj.Properties())
            {
                if (property.Value.Type == JTokenType.Object)
                {
                    var newObjectElement = objectElement.AddObjectElement(property.Name);
                    CreateRecursive((JObject)property.Value, newObjectElement);
                }
                else
                {
                    objectElement.AddValueElement(property.Name, property.Value);
                }
            }
        }
    }
}