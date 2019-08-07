using System;
using System.Collections.Generic;
using System.Linq;

namespace Mmu.Dt.Domain.Areas.JsonTranslation.SubAreas.Json.JsonAlignment.Models
{
    public class JsonKey
    {
        public string FullKey { get; }
        public string ObjectElementKey { get; }
        public IReadOnlyCollection<string> ObjectElementKeyParts { get; }
        public string ValueElementKey { get; }

        private JsonKey(string key)
        {
            var keyParts = key.Split('_');
            ObjectElementKeyParts = keyParts.Except(new List<string> { keyParts.Last() }).ToList();
            ValueElementKey = keyParts.Last();
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