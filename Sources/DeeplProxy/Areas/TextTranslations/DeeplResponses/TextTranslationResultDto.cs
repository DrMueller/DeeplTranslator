using System.Collections.Generic;

namespace Mmu.Dt.DeeplProxy.Areas.TextTranslations.DeeplResponses
{
    internal class TextTranslationResultDto
    {
        public List<TranslatedTextDto> Translations { get; set; }
    }
}