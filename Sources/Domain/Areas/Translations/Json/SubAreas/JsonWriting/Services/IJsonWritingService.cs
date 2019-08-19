using Mmu.Dt.Domain.Areas.Translations.Json.SubAreas.JsonParsing.Models;

namespace Mmu.Dt.Domain.Areas.Translations.Json.SubAreas.JsonWriting.Services
{
    internal interface IJsonWritingService
    {
        void WriteJson(JsonObjectElement root, string filePath);
    }
}