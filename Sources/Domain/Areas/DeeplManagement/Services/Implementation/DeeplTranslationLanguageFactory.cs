using System.Collections.Generic;
using System.Linq;
using Mmu.Dt.DeeplProxy.Areas.TextTranslations.Models;
using Mmu.Dt.Domain.Areas.DeeplManagement.Models;

namespace Mmu.Dt.Domain.Areas.DeeplManagement.Services.Implementation
{
    internal class DeeplTranslationLanguageFactory : IDeeplTranslationLanguageFactory
    {
        public IReadOnlyCollection<DeeplTranslationLanguage> CreateSupportedLanguages()
        {
            var result = TranslationLanguage.All
                .Select(lang => new DeeplTranslationLanguage(lang.Code, lang.Description))
                .ToList();

            return result;
        }
    }
}