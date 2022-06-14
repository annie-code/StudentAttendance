using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentAttendance.Models;

namespace StudentAttendance.Data
{
    public class StudentAttendanceContext : DbContext
    {
        public StudentAttendanceContext (DbContextOptions<StudentAttendanceContext> options)
            : base(options)
        {
        }

        public DbSet<StudentAttendance.Models.StudentAttendanceModel> StudentAttendanceModel { get; set; }
    }
}
