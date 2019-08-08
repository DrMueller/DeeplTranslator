using Mmu.Dt.Domain.Areas.JsonTranslation.SubAreas.Json.JsonParsing.Models;

namespace Mmu.Dt.Domain.Areas.JsonTranslation.SubAreas.Json.JsonWriting.Services
{
    internal interface IJsonWritingService
    {
        void WriteJson(JsonObjectElement root, string filePath);
    }
}