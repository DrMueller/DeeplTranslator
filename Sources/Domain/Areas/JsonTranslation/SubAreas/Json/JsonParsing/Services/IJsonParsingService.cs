using Mmu.Dt.Domain.Areas.JsonTranslation.SubAreas.Json.JsonParsing.Models;

namespace Mmu.Dt.Domain.Areas.JsonTranslation.SubAreas.Json.JsonParsing.Services
{
    internal interface IJsonParsingService
    {
        JsonObjectElement Parse(string filePath);
    }
}