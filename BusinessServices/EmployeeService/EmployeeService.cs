using BusinessServices.EmployeeService;
using CsvHelper;
using Model;
using Model.Queries;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Services
{
    public interface IEmployeeService
    {
        EmployeeModel FetchEmployeeById(string id);
        List<EmployeeModel> SearchEmployee(EmployeeSearchQuery query);
    }

    public class EmployeeService: BaseEmployee, IEmployeeService
    {
        public EmployeeModel FetchEmployeeById(string id)
        {
            using (var reader = new StreamReader(@"..\data\employee.csv"))

            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Configuration.RegisterClassMap<EmployeeModelClassMap>();

                var records = csv.GetRecords<EmployeeModel>().Where(w => w.EmployeeId == id).FirstOrDefault();

                return records;
            }
        }

        private List<CurrencyModel>  GetCurrencyTable()
        {
            using (var reader = new StreamReader(@"..\api\data\currency.csv"))

            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Configuration.RegisterClassMap<CurrencyModelClassMap>();
                var records = csv.GetRecords<CurrencyModel>().ToList();

                return records;
            }
        }

        public List<EmployeeModel> SearchEmployee(EmployeeSearchQuery query)
        {
            var currencyTable = GetCurrencyTable();
            using (var reader = new StreamReader(@"..\api\data\employee.csv"))

            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Configuration.RegisterClassMap<EmployeeModelClassMap>();

                var searchResult = csv.GetRecords<EmployeeModel>();

                if (query.Country != string.Empty)
                    searchResult = searchResult.Where(w => w.Branch.Trim().ToLower() == query.Country.Trim().ToLower());

                if (!string.IsNullOrEmpty(query.FirstName) && query.FirstName.Contains("*"))
                    searchResult = searchResult.Where(w => w.FullName.Trim().ToLower().Split(" ")[0].Contains(query.FirstName.Replace("*", "").Trim().ToLower()));

                if (!string.IsNullOrEmpty(query.FirstName) && !query.FirstName.Contains("*"))
                    searchResult = searchResult.Where(w => w.FullName.Trim().ToLower().Split(" ")[0].Contains(query.FirstName.Trim().ToLower()));
                if (!string.IsNullOrEmpty(query.LastName) && query.FirstName.Contains("*"))
                    searchResult = searchResult.Where(w => w.FullName.Trim().ToLower().Split(" ")[1].Contains(query.LastName.Replace("*", "").Trim().ToLower()));

                if (!string.IsNullOrEmpty(query.LastName) && !query.LastName.Contains("*"))
                    searchResult = searchResult.Where(w => w.FullName.Trim().ToLower().Split(" ")[1].Contains(query.LastName.Trim().ToLower()));


                // ordet by skiped since cvs file already sorted by employye no 
                searchResult = searchResult.Skip(query.Offset * query.Limit).Take(query.Limit);

                var skipedResult = searchResult.ToList();

                // calculate local salary 
                foreach (var item in skipedResult)
                {
                    var currencyRate = currencyTable.FirstOrDefault(w => w.Country.Trim().ToLower() == item.Branch.Trim().ToLower());
                    if (currencyRate != null)
                    {
                        item.LocalSalary = item.SalaryUSD * currencyRate.Rate;
                        item.PATETax = base.CalculatePATETax(item.LocalSalary, item.Branch);
                        item.NetPay = item.LocalSalary - item.PATETax;
                    }
                }

                return skipedResult;
            }
        }

      
    }
}
