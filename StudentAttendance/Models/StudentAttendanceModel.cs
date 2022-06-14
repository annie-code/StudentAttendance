using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace StudentAttendance.Models
{
    public class StudentAttendanceModel
    {
        [Key]
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public double AttendancePercentage { get; set; }

    }
}
