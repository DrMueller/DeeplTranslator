using System.Threading.Tasks;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.Components.CommandBars.ViewData;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.ViewModelCommands;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Behaviors;

namespace Mmu.Dt.WpfUI.Areas.JsonTranslation.ViewModels
{
    public class TranslateJsonViewModel : ViewModelBase, INavigatableViewModel, IInitializableViewModel
    {
        private readonly CommandContainer _commandContainer;

        private string _sourceFile;
        private string _sourceLanguageCode;
        private string _targetFile;
        private string _targetLanguageCode;
        public CommandsViewData Commands => _commandContainer.Commands;
        public string HeadingDescription => "Translate JSON";
        public string NavigationDescription => "Translate JSON";
        public int NavigationSequence => 1;

        public IViewModelCommand SelectTargetFile => _commandContainer.SelectTargetFile;
        public IViewModelCommand SelectSourceFile => _commandContainer.SelectSourceFile;

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

        public string SourceLanguageCode
        {
            get => _sourceLanguageCode;
            set
            {
                if (_sourceLanguageCode != value)
                {
                    _sourceLanguageCode = value;
                    OnPropertyChanged();
                }
            }
        }

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

        public string TargetLanguageCode
        {
            get => _targetLanguageCode;
            set
            {
                if (_targetLanguageCode != value)
                {
                    _targetLanguageCode = value;
                    OnPropertyChanged();
                }
            }
        }

        public TranslateJsonViewModel(CommandContainer commandContainer)
        {
            _commandContainer = commandContainer;
        }

        public async Task InitializeAsync(params object[] initParams)
        {
            await _commandContainer.InitializeAsync(this);
        }
    }
}