using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Mmu.Dt.Domain.Areas.DeeplManagement.Services;
using Mmu.Dt.WpfUI.Areas.JsonTranslation.ViewData;

namespace Mmu.Dt.WpfUI.Areas.DeeplManagement.ViewServices.Implementation
{
    public class TranslationLanguageFactory : ITranslationLanguageFactory
    {
        private readonly IDeeplTranslationLanguageFactory _deeplTranslationLanguageFactory;

        public TranslationLanguageFactory(IDeeplTranslationLanguageFactory deeplTranslationLanguageFactory)
        {
            _deeplTranslationLanguageFactory = deeplTranslationLanguageFactory;
        }

        public ObservableCollection<TranslationLanguageViewData> CreateForSourceLanguage()
        {
            var allLanguages = CreateAll();
            allLanguages.Insert(0, new TranslationLanguageViewData
            {
                Code = string.Empty,
                Description = "-Auto Detect-"
            });

            return new ObservableCollection<TranslationLanguageViewData>(allLanguages);
        }

        public ObservableCollection<TranslationLanguageViewData> CreateForTargetLanguage()
        {
            var allLanguages = CreateAll();
            return new ObservableCollection<TranslationLanguageViewData>(allLanguages);
        }

        private List<TranslationLanguageViewData> CreateAll()
        {
            return _deeplTranslationLanguageFactory
                .CreateSupportedLanguages()
                .OrderBy(f => f.Description)
                .Select(lang => new TranslationLanguageViewData
                {
                    Code = lang.Code,
                    Description = lang.Description
                }).ToList();
        }
    }
}