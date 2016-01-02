using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyMVCLatest.Models;

namespace MyMVCLatest.Controllers
{
    public class DepartmentController : Controller
    {
        //
        // GET: /Department/

        public ActionResult Index()
        {
            EmployeeContext empcontext = new EmployeeContext();
            List<Department> departments = empcontext.Departments.ToList();
            return View(departments);
             
           
            
        }

    }
}
