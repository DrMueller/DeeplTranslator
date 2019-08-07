using Mmu.Dt.Domain.Areas.JsonTranslation.SubAreas.Json.JsonParsing.Models;

namespace Mmu.Dt.Domain.Areas.JsonTranslation.SubAreas.Json.JsonParsing.Services
{
    public interface IJsonParsingService
    {
        JsonObjectElement Parse(string filePath);
    }
}