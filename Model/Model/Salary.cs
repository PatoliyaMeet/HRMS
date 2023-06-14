using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Model
{
    public class Salary
    {
        [Key]
        public int salaryId {  get; set; }  

        public int EmployeeId { get; set; } 

        public decimal BaseSalary { get; set; }


    }
}
