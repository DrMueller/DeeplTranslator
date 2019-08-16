using Mmu.Dt.Common.Areas.Settings.Dtos;
using Mmu.Dt.Common.Areas.Settings.Models;
using Mmu.Mlh.SettingsProvisioning.Areas.Factories;
using Mmu.Mlh.SettingsProvisioning.Areas.Models;

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
            var settingsConfig = new SettingsConfiguration(
                AppSettings.SectionKey,
                string.Empty,
                settingsPath,
                 @"Apps\DeeplTranslator\");

            var settingsDto = _settingsFactory.CreateSettings<AppSettingsDto>(settingsConfig);
            _appSettings = new AppSettings(settingsDto.DeeplApiKey);
        }

        public AppSettings ProvideSettings()
        {
            return _appSettings;
        }
    }
}