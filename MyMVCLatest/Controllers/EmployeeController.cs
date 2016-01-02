using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyMVCLatest.Models;
namespace MyMVCLatest.Controllers
{
    public class EmployeeController : Controller
    {
        //
        // GET: /Employee/

        
        public ActionResult Index()

        {
          //  return HttpNotFound();
            
            return View();
          
            //return View();
        }
        public ActionResult Details(int id)
        {
            EmployeeContext empContext = new EmployeeContext();

            Employee employee= empContext.Employees.Single(emp => emp.employeeid == id);
            return View(employee);

        }

        public ActionResult DeptList()
        {
            EmployeeContext deptContext = new EmployeeContext();
            List<Department> depts = deptContext.Departments.ToList();
            return View(depts);
        }

        public ActionResult All(int DepartmentId)
        {
            EmployeeContext empcontext = new EmployeeContext();
            List<Employee> employees = empcontext.Employees.Where(emp => emp.deptid == DepartmentId).ToList();
            if (employees == null)
            {
                return HttpNotFound();
            }
            return View(employees);
         }

        public ActionResult DeleteDept(int DepartmentId)
        {
            
            EmployeeContext empcontext = new EmployeeContext();
            //Remove all employees from the department

            empcontext.Employees.RemoveRange(empcontext.Employees.Where(x=>x.deptid == DepartmentId));

           
            //Delete department from the database.
            //Select dept record object then call for delete

            var removerec = empcontext.Departments.SingleOrDefault(z => z.id == DepartmentId);
            string deptname="";

            if (removerec != null)
            {
                deptname = removerec.name;
                empcontext.Departments.Remove(removerec);
            }
            empcontext.SaveChanges();

            ViewBag.Acknowledgement = deptname + " has been removed from the database";
            return View();
            
        }


        [HttpGet]
        public ActionResult Create()
        {

            return View();
        
        }


        public ActionResult View1()
        {
            return View();
        }

    }
}
