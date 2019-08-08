using System.Collections.ObjectModel;
using Mmu.Dt.WpfUI.Areas.JsonTranslation.ViewData;

namespace Mmu.Dt.WpfUI.Areas.JsonTranslation.ViewServices
{
    public interface ITranslationLanguageFactory
    {
        ObservableCollection<TranslationLanguageViewData> CreateForSourceLanguage();

        ObservableCollection<TranslationLanguageViewData> CreateForTargetLanguage();
    }
}