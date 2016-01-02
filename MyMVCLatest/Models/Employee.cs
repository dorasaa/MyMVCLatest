using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyMVCLatest.Models
{

    [Table("tblemployee")]
    public class Employee
    {
         
        public int employeeid { get; set; }
        public string  name { get; set; }
        public string gender { get; set; }
        public string city { get; set; }
        public int deptid { get; set; }




    }
}