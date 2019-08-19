using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Mmu.Dt.Domain.Areas.Translations.Resx.SubAreas.ResxParsing.Models;

namespace Mmu.Dt.Domain.Areas.Translations.Resx.SubAreas.ResxComparison.Services.Servants
{
    internal class DataElementEqualityComparer : IEqualityComparer<DataElement>
    {
        public bool Equals(DataElement x, DataElement y)
        {
            return x.Name == y.Name;
        }

        public int GetHashCode(DataElement obj)
        {
            return obj.Name.GetHashCode(StringComparison.Ordinal);
        }
    }
}