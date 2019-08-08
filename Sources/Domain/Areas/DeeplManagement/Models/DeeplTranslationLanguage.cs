namespace Mmu.Dt.Domain.Areas.DeeplManagement.Models
{
    public class DeeplTranslationLanguage
    {
        public string Code { get; }
        public string Description { get; }

        public DeeplTranslationLanguage(string code, string description)
        {
            Code = code;
            Description = description;
        }
    }
}