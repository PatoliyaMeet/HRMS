using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Model
{
    public class Attendance
    {
        [Key]
        public DateTime Date { get; set; }

        [ForeignKey("EmployeeId")]
        public int EmployeeId { get; set; }

        public TimeSpan TimeIn { get; set; }

        public TimeSpan TimeOut { get; set; }

        public double _TotalHours;

        public double TotalHours
        {
            get { return _TotalHours; }

            set
            {
                Double hrs = TimeOut.Subtract(TimeIn).TotalHours;

                _TotalHours = hrs;
            }
        }


    }
}
