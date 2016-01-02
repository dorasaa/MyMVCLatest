using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
 
namespace MyMVCLatest.Models
{
    public class EmployeeContext: DbContext

    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}