using System;
using System.IO;
using System.Reflection;
using System.Windows;
using Mmu.Dt.Common.Areas.Settings.Services;
using Mmu.Mlh.ServiceProvisioning.Areas.Provisioning.Services;
using Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.Orchestration.Models;
using Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.Orchestration.Services;

namespace Mmu.Dt.WpfUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnActivated(EventArgs e)
        {
            var settingsProvider = ServiceLocatorSingleton.Instance.GetService<ISettingsProvider>();
            settingsProvider.Initialize(@"C:\Users\mlm\Dropbox\appsettings.json");
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            var assembly = typeof(App).Assembly;
            var appConfig = WpfAppConfig.CreateWithDefaultIcon(assembly, "Deepl Translator");
            await AppStartService.StartAppAsync(appConfig);
        }
    }
}