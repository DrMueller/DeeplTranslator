using Mmu.Dt.DeeplProxy.Areas.TextTranslations.Services;
using Mmu.Dt.DeeplProxy.Areas.TextTranslations.Services.Implementation;
using Mmu.Dt.DeeplProxy.Areas.TextTranslations.Services.Servants;
using Mmu.Dt.DeeplProxy.Areas.TextTranslations.Services.Servants.Implementation;
using StructureMap;

namespace Mmu.Dt.DeeplProxy.Infrastructure.DependencyInjection
{
    public class DeeplProxyRegistry : Registry
    {
        public DeeplProxyRegistry()
        {
            Scan(scanner =>
            {
                scanner.AssemblyContainingType<DeeplProxyRegistry>();
                scanner.WithDefaultConventions();
            });

            For<ITextTranslationRequestFactory>().Use<TextTranslationRequestFactory>().Singleton();
            For<ITextTranslationService>().Use<TextTranslationService>().Singleton();
            For<ITextTranslationResultAdapter>().Use<TextTranslationResultAdapter>().Singleton();
        }
    }
}