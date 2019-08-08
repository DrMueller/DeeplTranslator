using Mmu.Dt.Common.Areas.Settings.Models;

namespace Mmu.Dt.Common.Areas.Settings.Services
{
    public interface ISettingsProvider
    {
        public void Initialize(string settingsPath);

        AppSettings ProvideSettings();
    }
}