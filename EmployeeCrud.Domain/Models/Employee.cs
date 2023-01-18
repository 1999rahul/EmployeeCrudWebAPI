using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeCrud.Domain.Models
{
    public class Employee
    {
        public int? EmployeeId { get; set; }
        public string FullName { get; set; }   
        public string DOB { get; set; }
        public string Address { get; set; }
        

    }
}
