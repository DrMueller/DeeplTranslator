using System;
using System.Collections.Generic;
using System.Linq;

namespace Mmu.Dt.Domain.Areas.JsonTranslation.SubAreas.Json.JsonAlignment.Models
{
    internal class JsonKey
    {
        public string FullKey { get; }
        public string ObjectElementKey { get; }
        public IReadOnlyCollection<string> ObjectElementKeyParts { get; }
        public string ValueElementKey { get; }

        private JsonKey(string key)
        {
            var keyParts = key.Split('_');
            ValueElementKey = keyParts.Last();
            ObjectElementKeyParts = keyParts.Take(keyParts.Count() - 1).ToList();
            ObjectElementKey = string.Join('_', ObjectElementKeyParts);
            FullKey = key;
        }

        public static JsonKey Create(string key)
        {
            return new JsonKey(key);
        }

        public IReadOnlyCollection<string> FetchMissingObjectElementKeyParts(string key)
        {
            var missingKey = ObjectElementKey;
            if (!string.IsNullOrEmpty(key))
            {
                missingKey = missingKey.Replace(key, string.Empty, StringComparison.Ordinal);
            }

            return missingKey
                  .Split('_', StringSplitOptions.RemoveEmptyEntries)
                  .ToList();
        }
    }
}