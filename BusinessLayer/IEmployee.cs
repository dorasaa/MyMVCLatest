using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayer
{
    public interface IEmployee
    {
         int id { get; set; }
        
        
        string gender { get; set; }
        
        string city { get; set; }
        
        int? deptid { get; set; }
    }
}
