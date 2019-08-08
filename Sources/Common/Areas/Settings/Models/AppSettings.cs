namespace Mmu.Dt.Common.Areas.Settings.Models
{
    public class AppSettings
    {
        public const string SectionKey = "AppSettings";

        public string DeeplApiKey { get; }

        public AppSettings(string deeplApiKey)
        {
            DeeplApiKey = deeplApiKey;
        }
    }
}