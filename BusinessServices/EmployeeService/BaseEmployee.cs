using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessServices.EmployeeService
{
    public abstract class BaseEmployee
    {
        public   decimal CalculatePATETax(decimal salary, string country)
        {
            decimal taxAmount = 0;
            var txtRate = new[]
                {
                        new { Lower = 0m, Upper = 100000m, Rate = 0.0m, Country= "Sri Lanka" },
                        new { Lower = 100000m, Upper = 249999.99m, Rate = 5m , Country= "Sri Lanka"},
                        new { Lower = 100000m, Upper =  decimal.MaxValue, Rate = 10m , Country= "Sri Lanka"},

                        new { Lower = 0m, Upper = 299999.99m, Rate = 0.0m, Country= "India" },
                        new { Lower = 100000m, Upper = 299999.99m, Rate = 4m , Country= "India"},
                        new { Lower =  300000m , Upper =  decimal.MaxValue, Rate = 7m , Country= "India"},

                        new { Lower = 0m, Upper = 500000m, Rate = 0.0m, Country= "Pakistan" },
                        new { Lower = 500000m, Upper =  decimal.MaxValue, Rate = 10m , Country= "Pakistan"},

                    };

            foreach (var band in txtRate)
            {
                if ((salary >= band.Lower && salary <= band.Upper) && band.Country.Trim().ToLower() == country.Trim().ToLower())
                {
                    taxAmount = (salary / 100) * band.Rate;
                }
            }

            return taxAmount;
        }
    }
}
