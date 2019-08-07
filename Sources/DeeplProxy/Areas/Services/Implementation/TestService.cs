using System;
using System.Threading.Tasks;
using Mmu.Mlh.RestExtensions.Areas.Models;
using Mmu.Mlh.RestExtensions.Areas.RestProxies;

namespace Mmu.Dt.DeeplProxy.Areas.Services.Implementation
{
    public class TestService : ITestService
    {
        private readonly IRestProxy _restProxy;

        public TestService(IRestProxy restProxy)
        {
            _restProxy = restProxy;
        }

        public async Task TestAsync()
        {
            try
            {
                var response = await _restProxy.PerformCallAsync<string>(factory =>
                {
                    return factory.StartBuilding(new Uri("https://api.deepl.com/v2/translate"), RestCallMethodType.Get)
                    .WithQueryParameter("auth_key", "04caaab4-9de1-ec76-7122-cb7468835a05")
                    .WithQueryParameter("text", "Hello World")
                    .WithQueryParameter("target_lang", "DE")
                    .Build();
                });
            }
            catch (Exception ex)
            {

            }

        }
    }
}