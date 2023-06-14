using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Model
{
    public class Leave
    {
        [Key]
        public int LeaveID { get; set; }

        [ForeignKey("EmployeeId")]
        public string EmployeeId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int Totaldays => (EndDate - StartDate).Days;

        public Employee Employee;
    }
}
