using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter.Models
{
    public class CurrencyIndexes
    {
        public CurrencyIndex[] Indexes;
        public CurrencyIndexes()
        {
            this.Indexes = new CurrencyIndex [2];
            Indexes[0] = new CurrencyIndex { Index = 34, TextboxIndex = 0};
            Indexes[1] = new CurrencyIndex { Index = 10, TextboxIndex = 1};
        }

        public void SetIndex(CurrencyIndex index)
        {
            Indexes[index.TextboxIndex] = new CurrencyIndex { Index = index.Index };
        }
    }
}
