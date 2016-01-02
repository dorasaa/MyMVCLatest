using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyMVCLatest.Models
{
    [Table("tbldepartment")]

    public class Department
    {

        public int id { get; set; }
        public string name { get; set; }
        public List<Employee> employees;
      


    }

}