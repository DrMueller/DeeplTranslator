using System;
using System.IO;
using System.Windows;
using Mmu.Dt.Common.Areas.Settings.Services;
using Mmu.Mlh.ServiceProvisioning.Areas.Provisioning.Services;
using Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.Orchestration.Models;
using Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.Orchestration.Services;

namespace Mmu.Dt.WpfUI
{
    public partial class App : Application
    {
        protected override async void OnStartup(StartupEventArgs e)
        {
            var assembly = typeof(App).Assembly;
            var appConfig = WpfAppConfig.CreateWithDefaultIcon(assembly, "Deepl Translator");
            await AppStartService.StartAppAsync(appConfig, AfterAppInitialized);
        }

        private static void AfterAppInitialized(IServiceLocator serviceLocator)
        {
            var infoPath = @"Dropbox\info.json";
            var jsonPath = Path.Combine(Environment.GetEnvironmentVariable("LocalAppData"), infoPath);
            if (!File.Exists(jsonPath))
            {
                jsonPath = Path.Combine(Environment.GetEnvironmentVariable("AppData"), infoPath);
            }

            var dropboxPath = File.ReadAllText(jsonPath).Split('\"')[5].Replace(@"\\", @"\", StringComparison.Ordinal);
            var settingsProvider = ServiceLocatorSingleton.Instance.GetService<ISettingsProvider>();

            var fullPath = Path.Combine(dropboxPath, @"Apps\DeeplTranslator\");
            settingsProvider.Initialize(fullPath);
        }
    }
}