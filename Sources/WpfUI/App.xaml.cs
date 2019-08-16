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
            var settingsProvider = ServiceLocatorSingleton.Instance.GetService<ISettingsProvider>();
            settingsProvider.Initialize(GetCodeBasePath());
        }

        private static string GetCodeBasePath()
        {
            var codeBase = typeof(App).Assembly.CodeBase;
            var uri = new UriBuilder(codeBase);
            var result = Uri.UnescapeDataString(uri.Path);
            result = Path.GetDirectoryName(result);
            return result;
        }
    }
}