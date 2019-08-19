using System.Threading.Tasks;
using Mmu.Dt.Domain.Areas.Translations.Common.Models;
using Mmu.Dt.Domain.Areas.Translations.Resx.Orchestration.Services;
using Mmu.Mlh.LanguageExtensions.Areas.Types.Maybes;
using Mmu.Mlh.WpfCoreExtensions.Areas.Aspects.InformationHandling.Models;
using Mmu.Mlh.WpfCoreExtensions.Areas.Aspects.InformationHandling.Services;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.Commands;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.Components.CommandBars.ViewData;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.ViewModelCommands;

namespace Mmu.Dt.WpfUI.Areas.ResxTranslation.ViewModels
{
    public class CommandContainer : IViewModelCommandContainer<TranslateResxViewModel>
    {
        private readonly IInformationPublisher _informationPublisher;
        private readonly IResxTranslationService _translationService;
        private TranslateResxViewModel _context;
        private bool _translationRunning;

        public CommandsViewData Commands { get; private set; }

        private bool CanTranslateResx
        {
            get
            {
                return !_translationRunning
                    && !string.IsNullOrEmpty(_context.SourceFilePath)
                    && _context.SelectedSourceLanguage != null
                    && !string.IsNullOrEmpty(_context.TargetFilePath)
                    && _context.SelectedTargetLanguage != null;
            }
        }

        private IViewModelCommand TranslateResx
        {
            get
            {
                return new ViewModelCommand("Translate", new RelayCommand(async () =>
                {
                    try
                    {
                        _translationRunning = true;
                        _informationPublisher.Publish(InformationEntry.CreateInfo("Translating..", true));

                        var sourceLanguageCode = string.IsNullOrEmpty(_context.SelectedSourceLanguage.Code) ?
                            Maybe.CreateNone<string>() :
                            Maybe.CreateSome(_context.SelectedSourceLanguage.Code);

                        var request = new TranslationRequest(
                            _context.SourceFilePath,
                            sourceLanguageCode,
                            _context.TargetFilePath,
                            _context.SelectedTargetLanguage.Code);

                        await _translationService.TranslateAsync(request);
                        _informationPublisher.Publish(InformationEntry.CreateSuccess("Translation finished!", false, 5));
                    }
                    finally
                    {
                        _translationRunning = false;
                    }
                }, () => CanTranslateResx));
            }
        }

        public CommandContainer(
            IResxTranslationService translationService,
            IInformationPublisher informationPublisher)
        {
            _translationService = translationService;
            _informationPublisher = informationPublisher;
        }

        public Task InitializeAsync(TranslateResxViewModel context)
        {
            _context = context;
            _context.SourceFilePath = @"C:\MyGit\Personal\MobileLearningSystem3\Backend\Sources\Translations\WebApi\Areas\Web\Controllers\HelloController\HelloController.resx";
            _context.TargetFilePath = @"C:\MyGit\Personal\MobileLearningSystem3\Backend\Sources\Translations\WebApi\Areas\Web\Controllers\HelloController\HelloController.de.resx";
            Commands = new CommandsViewData(TranslateResx);

            return Task.CompletedTask;
        }
    }
}