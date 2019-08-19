using Mmu.Dt.Domain.Areas.Translations.Json.SubAreas.JsonParsing.Models;

namespace Mmu.Dt.Domain.Areas.Translations.Json.SubAreas.JsonParsing.Services
{
    internal interface IJsonParsingService
    {
        JsonObjectElement Parse(string filePath);
    }
}