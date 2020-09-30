using CsvHelper.Configuration;
using System;

namespace Model
{
    public class EmployeeModel
    {

        public string EmployeeId { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public DateTime DateofBirth { get; set; }
        public string JoinedDate { get; set; }
        public decimal SalaryUSD { get; set; }
        public decimal NetPay { get; set; }
        public string Branch { get; set; }
        public decimal LocalSalary { get; set; }
        public decimal PATETax { get; set; }

 
    }
    public class EmployeeModelClassMap : ClassMap<EmployeeModel>
    {
        public EmployeeModelClassMap()
        {
            Map(m => m.EmployeeId).Name("Employee Id");
            Map(m => m.FullName).Name(" Full Name");
            Map(m => m.Gender).Name(" Gender");
            Map(m => m.DateofBirth).Name(" Date of Birth");
            Map(m => m.JoinedDate).Name(" Joined Date");
            Map(m => m.SalaryUSD).Name(" Salary (USD)");
            Map(m => m.Branch).Name(" Branch");
        }
    }
}
