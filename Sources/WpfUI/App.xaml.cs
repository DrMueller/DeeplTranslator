using System.Windows;
using Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.Orchestration.Models;
using Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.Orchestration.Services;

namespace Mmu.Dt.WpfUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override async void OnStartup(StartupEventArgs e)
        {
            var assembly = typeof(App).Assembly;
            var appConfig = WpfAppConfig.CreateWithDefaultIcon(assembly, "Deepl Translator");
            await AppStartService.StartAppAsync(appConfig);
        }
    }
}