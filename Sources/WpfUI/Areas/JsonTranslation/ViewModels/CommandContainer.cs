using System.Threading.Tasks;
using Mmu.Dt.Domain.Areas.JsonTranslation.Orchestration.Models;
using Mmu.Dt.Domain.Areas.JsonTranslation.Orchestration.Services;
using Mmu.Mlh.LanguageExtensions.Areas.Types.Maybes;
using Mmu.Mlh.WpfCoreExtensions.Areas.Aspects.InformationHandling.Models;
using Mmu.Mlh.WpfCoreExtensions.Areas.Aspects.InformationHandling.Services;
using Mmu.Mlh.WpfCoreExtensions.Areas.Dialogs.FileDialogs.Services;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.Commands;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.Components.CommandBars.ViewData;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.ViewModelCommands;

namespace Mmu.Dt.WpfUI.Areas.JsonTranslation.ViewModels
{
    public class CommandContainer : IViewModelCommandContainer<TranslateJsonViewModel>
    {
        private readonly IFileDialogService _fileDialogService;
        private readonly IInformationPublisher _informationPublisher;
        private readonly IJsonTranslationService _jsonTranslationService;
        private TranslateJsonViewModel _context;
        private bool _translationRunning;
        public CommandsViewData Commands { get; private set; }

        public IViewModelCommand SelectSourceFile
        {
            get
            {
                return new ViewModelCommand(
                    "...",
                     new RelayCommand(() =>
                     {
                         var rslt = _fileDialogService.SelectFile("All files (*.*)|*.*");

                         if (rslt.OkClicked)
                         {
                             _context.SourceFilePath = rslt.FilePath;
                         }
                         else
                         {
                             _context.SourceFilePath = string.Empty;
                         }
                     }));
            }
        }

        public IViewModelCommand SelectTargetFile
        {
            get
            {
                return new ViewModelCommand(
                    "...",
                     new RelayCommand(() =>
                     {
                         var rslt = _fileDialogService.SelectFile("All files (*.*)|*.*");

                         if (rslt.OkClicked)
                         {
                             _context.TargetFilePath = rslt.FilePath;
                         }
                         else
                         {
                             _context.TargetFilePath = string.Empty;
                         }
                     }));
            }
        }

        private bool CanTranslateJson
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

        private ViewModelCommand TranslateJson
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

                        var request = new JsonTranslationRequest(
                            _context.SourceFilePath,
                            sourceLanguageCode,
                            _context.TargetFilePath,
                            _context.SelectedTargetLanguage.Code);

                        await _jsonTranslationService.TranslateAsync(request);
                        _informationPublisher.Publish(InformationEntry.CreateSuccess("Translation finished!", false, 5));
                    }
                    finally
                    {
                        _translationRunning = false;
                    }
                }, () => CanTranslateJson));
            }
        }

        public CommandContainer(
            IJsonTranslationService jsonTranslationService,
            IFileDialogService fileDialogService,
            IInformationPublisher informationPublisher)
        {
            _jsonTranslationService = jsonTranslationService;
            _fileDialogService = fileDialogService;
            _informationPublisher = informationPublisher;
        }

        public Task InitializeAsync(TranslateJsonViewModel context)
        {
            _context = context;
            _context.SourceFilePath = @"C:\Users\mlm\Desktop\en.json";
            _context.TargetFilePath = @"C:\Users\mlm\Desktop\de.json";

            Commands = new CommandsViewData(TranslateJson);
            return Task.CompletedTask;
        }
    }
}