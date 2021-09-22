using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter.Interfaces
{
    public interface ICurrency
    {
        string CharCode { get; set; }
        int Nominal { get; set; }
        string Name { get; set; }
        decimal Value { get; set; }
    }
}
