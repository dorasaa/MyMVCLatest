using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace BusinessLayer
{
    //Model entity only
    public class Employee:IEmployee
    {
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string gender { get; set; }
        [Required]
        public string city { get; set; }
        [Required]
        public int? deptid { get; set; }
    }
}
