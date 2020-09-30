using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class CurrencyModel
    {
        public string Country { get; set; }
        public string Type { get; set; }
        public decimal Rate { get; set; }
    }

    public class CurrencyModelClassMap : ClassMap<CurrencyModel>
    {
        public CurrencyModelClassMap()
        {
            Map(m => m.Country).Name("Country");
            Map(m => m.Type).Name(" Type");
            Map(m => m.Rate).Name(" Rate");
        }
    }

}
