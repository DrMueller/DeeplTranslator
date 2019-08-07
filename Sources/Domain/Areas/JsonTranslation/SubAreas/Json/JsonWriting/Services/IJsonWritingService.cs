using Mmu.Dt.Domain.Areas.JsonTranslation.SubAreas.Json.JsonParsing.Models;

namespace Mmu.Dt.Domain.Areas.JsonTranslation.SubAreas.Json.JsonWriting.Services
{
    public interface IJsonWritingService
    {
        void WriteJson(JsonObjectElement root, string filePath);
    }
}