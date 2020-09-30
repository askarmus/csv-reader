using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Queries
{
    public class EmployeeSearchQuery : Query
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
    }
}
