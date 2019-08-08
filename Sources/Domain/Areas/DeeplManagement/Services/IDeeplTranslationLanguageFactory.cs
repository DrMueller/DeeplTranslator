using System.Collections.Generic;
using Mmu.Dt.Domain.Areas.DeeplManagement.Models;

namespace Mmu.Dt.Domain.Areas.DeeplManagement.Services
{
    public interface IDeeplTranslationLanguageFactory
    {
        IReadOnlyCollection<DeeplTranslationLanguage> CreateSupportedLanguages();
    }
}