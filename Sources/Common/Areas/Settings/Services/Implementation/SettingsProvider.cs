using Mmu.Dt.Common.Areas.Settings.Dtos;
using Mmu.Dt.Common.Areas.Settings.Models;
using Mmu.Mlh.SettingsProvisioning.Areas.Factories;

namespace Mmu.Dt.Common.Areas.Settings.Services.Implementation
{
    internal class SettingsProvider : ISettingsProvider
    {
        private readonly ISettingsFactory _settingsFactory;
        private AppSettings _appSettings;

        public SettingsProvider(ISettingsFactory settingsFactory)
        {
            _settingsFactory = settingsFactory;
        }

        public void Initialize(string settingsPath)
        {
            var settingsDto = _settingsFactory.CreateSettings<AppSettingsDto>(AppSettings.SectionKey, string.Empty, settingsPath);
            _appSettings = new AppSettings(settingsDto.DeeplApiKey);
        }

        public AppSettings ProvideSettings()
        {
            return _appSettings;
        }
    }
}