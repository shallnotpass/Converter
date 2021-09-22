using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Converter.Interfaces;

namespace Converter.Models
{
    [DataContract]
    public class Currency : ICurrency
    {
        [DataMember]
        public string ID { get; set; }
        [DataMember]
        public string NumCode { get; set; }
        [DataMember]
        public string CharCode { get; set; }
        [DataMember]
        public int Nominal { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public decimal Value { get; set; }
        [DataMember]
        public decimal Previous { get; set; }
    }
}
