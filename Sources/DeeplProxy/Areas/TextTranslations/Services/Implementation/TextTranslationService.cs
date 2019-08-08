using System;
using System.Threading.Tasks;
using Mmu.Dt.Common.Areas.Settings.Services;
using Mmu.Dt.DeeplProxy.Areas.TextTranslations.DeeplResponses;
using Mmu.Dt.DeeplProxy.Areas.TextTranslations.Models;
using Mmu.Dt.DeeplProxy.Areas.TextTranslations.Services.Servants;
using Mmu.Mlh.LanguageExtensions.Areas.Collections;
using Mmu.Mlh.RestExtensions.Areas.Models;
using Mmu.Mlh.RestExtensions.Areas.RestCallBuilding;
using Mmu.Mlh.RestExtensions.Areas.RestProxies;

namespace Mmu.Dt.DeeplProxy.Areas.TextTranslations.Services.Implementation
{
    internal class TextTranslationService : ITextTranslationService
    {
        private readonly IRestCallBuilderFactory _restCallBuilderFactory;
        private readonly IRestProxy _restProxy;
        private readonly ITextTranslationResultAdapter _resultAdapter;
        private readonly ISettingsProvider _settingsProvider;

        public TextTranslationService(
            IRestProxy restProxy,
            IRestCallBuilderFactory restCallBuilderFactory,
            ISettingsProvider settingsProvider,
            ITextTranslationResultAdapter resultAdapter)
        {
            _restProxy = restProxy;
            _restCallBuilderFactory = restCallBuilderFactory;
            _settingsProvider = settingsProvider;
            _resultAdapter = resultAdapter;
        }

        public async Task<TextTranslationResult> TranslateAsync(TextTranslationRequest request)
        {
            var restCall = BuildRestCall(request);

            var tra = restCall.AbsoluteUri.ToString();
            var response = await _restProxy.PerformCallAsync<TextTranslationResultDto>(restCall);
            var result = _resultAdapter.Adapt(request, response);
            return result;
        }

        private RestCall BuildRestCall(TextTranslationRequest request)
        {
            var apiKey = _settingsProvider.ProvideSettings().DeeplApiKey;
            var builder = _restCallBuilderFactory
                .StartBuilding(new Uri("https://api.deepl.com/v2/translate"), RestCallMethodType.Post)
                .WithQueryParameter("auth_key", apiKey)
                .WithQueryParameter("target_lang", request.TargetLanguage.Code);

            request.ApplyIgnoreMarkUp();

            request.SourceLanguage.Evaluate(language =>
            {
                builder.WithQueryParameter("source_lang", language.Code);
            });

            request.TextParts.ForEach(part =>
            {
                builder.WithQueryParameter("text", part.Text);
            });

            return builder.Build();
        }
    }
}