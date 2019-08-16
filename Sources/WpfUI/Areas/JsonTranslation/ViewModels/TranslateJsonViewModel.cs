using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Mmu.Dt.WpfUI.Areas.JsonTranslation.ViewData;
using Mmu.Dt.WpfUI.Areas.JsonTranslation.ViewServices;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.Components.CommandBars.ViewData;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Behaviors;

namespace Mmu.Dt.WpfUI.Areas.JsonTranslation.ViewModels
{
    public class TranslateJsonViewModel : ViewModelBase, INavigatableViewModel, IInitializableViewModel
    {
        private readonly CommandContainer _commandContainer;
        private readonly ITranslationLanguageFactory _translationLanguageFactory;
        private TranslationLanguageViewData _selectedSourceLanguage;
        private TranslationLanguageViewData _selectedTargetLanguage;
        private string _sourceFile;
        private string _targetFile;
        public CommandsViewData Commands => _commandContainer.Commands;
        public string HeadingDescription => "Translate JSON";
        public string NavigationDescription => "Translate JSON";
        public int NavigationSequence => 1;

        public TranslationLanguageViewData SelectedSourceLanguage
        {
            get => _selectedSourceLanguage;
            set
            {
                if (_selectedSourceLanguage != value)
                {
                    _selectedSourceLanguage = value;
                    OnPropertyChanged();
                }
            }
        }

        public TranslationLanguageViewData SelectedTargetLanguage
        {
            get => _selectedTargetLanguage;
            set
            {
                if (_selectedTargetLanguage != value)
                {
                    _selectedTargetLanguage = value;
                    OnPropertyChanged();
                }
            }
        }

        public string SourceFilePath
        {
            get => _sourceFile;
            set
            {
                if (_sourceFile != value)
                {
                    _sourceFile = value;
                    OnPropertyChanged();
                }
            }
        }

        public ObservableCollection<TranslationLanguageViewData> SourceLanguages { get; private set; }

        public string TargetFilePath
        {
            get => _targetFile;
            set
            {
                if (_targetFile != value)
                {
                    _targetFile = value;
                    OnPropertyChanged();
                }
            }
        }

        public ObservableCollection<TranslationLanguageViewData> TargetLanguages { get; private set; }

        public TranslateJsonViewModel(CommandContainer commandContainer, ITranslationLanguageFactory translationLanguageFactory)
        {
            _commandContainer = commandContainer;
            _translationLanguageFactory = translationLanguageFactory;
        }

        public async Task InitializeAsync(params object[] initParams)
        {
            SourceLanguages = _translationLanguageFactory.CreateForSourceLanguage();
            TargetLanguages = _translationLanguageFactory.CreateForTargetLanguage();
            SelectedSourceLanguage = SourceLanguages.First();
            SelectedTargetLanguage = TargetLanguages.First();

            await _commandContainer.InitializeAsync(this);
        }
    }
}