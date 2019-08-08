using System;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Dt.DeeplProxy.Areas.TextTranslations.Models
{
    public class IdentifiableText
    {
        public string Key { get; }
        public string Text { get; private set; }

        public IdentifiableText(string key, string text)
        {
            Guard.StringNotNullOrEmpty(() => text);

            Key = key;
            Text = text;
        }

        internal void ReplaceTextmarks(string from, string to)
        {
            Text = Text.Replace(from, to, StringComparison.Ordinal);
        }
    }
}