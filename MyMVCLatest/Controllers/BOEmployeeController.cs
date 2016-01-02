using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;
 
namespace MyMVCLatest.Controllers
{
    public class BOEmployeeController : Controller
    {
        //
        // GET: /BOEmployee/

        public ActionResult Index()
        {
            EmployeeBusinessLayer ebl = new EmployeeBusinessLayer();
            IList<Employee> EmployeesList = ebl.employees.ToList();
            return View(EmployeesList);
        }

        //This means it only responds for GET method.


        

        [HttpGet]
        [ActionName("Create")]
        public ActionResult Create_Get()
        {
            return View();
        }


        //using UpdateModel function
        
        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post()
        {
            Employee emp = new Employee();

            TryUpdateModel(emp);
            if (ModelState.IsValid)
            {
                
                
                EmployeeBusinessLayer eblayer = new EmployeeBusinessLayer();
                eblayer.AddEmployee(emp);

                return RedirectToAction("Index");
            }

            return View();

        }


        [HttpGet]
        [ActionName("Edit")]
        public ActionResult Edit_Get(int Id)
        {
            
            EmployeeBusinessLayer eblayer = new EmployeeBusinessLayer();
            Employee emp= eblayer.employees.Single(e => e.id == Id);
            return View(emp);

        }


        ////this code submit all properties of model
        //[HttpPost]
        //[ActionName("Edit")]
        //public ActionResult Edit_Post(Employee emp)
        //{
        //    if(ModelState.IsValid)
        //    {
        //    EmployeeBusinessLayer eblayer = new EmployeeBusinessLayer();
        //    eblayer.UpdateEmployee(emp);
        //    return RedirectToAction("Index");
        //    }

        //    return View(emp);
        //}


        
        ////this code submit only required properties (include) 
        //[HttpPost]
        //[ActionName("Edit")]
        //public ActionResult Edit_Post(int id)
        //{
        //    EmployeeBusinessLayer eblayer = new EmployeeBusinessLayer();
        //    Employee emp = eblayer.employees.Single(e => e.id == id);
        //    UpdateModel(emp, new string[] { "employeeid","gender","city","deptid"});

        //    if (ModelState.IsValid)
        //    {
                
        //        eblayer.UpdateEmployee(emp);

        //        return RedirectToAction("Index");
        //    }

        //    return View(emp);
        //}

        ////Bind the model using BIND property

        
        //[HttpPost]
        //[ActionName("Edit")]
        //public ActionResult Edit_Post([Bind(Include="employeeid, gender, city, deptid")]Employee emp)
        //{
        //    EmployeeBusinessLayer eblayer = new EmployeeBusinessLayer();
        //    emp.name = eblayer.employees.Single(e => e.id == emp.id).name;
            

        //    if (ModelState.IsValid)
        //    {

        //        eblayer.UpdateEmployee(emp);

        //        return RedirectToAction("Index");
        //    }

        //    return View(emp);
        //}


        //Bind the model using BIND property


        //Bind model with interface
        [HttpPost]
        [ActionName("Edit")]
        public ActionResult Edit_Post(int id)
        {
            EmployeeBusinessLayer eblayer = new EmployeeBusinessLayer();
            Employee emp= eblayer.employees.Single(e => e.id== id);
            UpdateModel<IEmployee>(emp);

            if (ModelState.IsValid)
            {

                eblayer.UpdateEmployee(emp);

                return RedirectToAction("Index");
            }

            return View(emp);
        }


       
        [HttpPost]
        public ActionResult Delete(int id)
        {
            EmployeeBusinessLayer eblayer = new EmployeeBusinessLayer();
            eblayer.Delete(id);
                
           return RedirectToAction("Index");
        }

        ////using employee object
        //[HttpPost]
        //public ActionResult Create(Employee emp)
        //{
        //    if(ModelState.IsValid)
        //    {
        //        EmployeeBusinessLayer eblayer = new EmployeeBusinessLayer();
        //        eblayer.AddEmployee(emp);

        //        return RedirectToAction("Index");
        //    }

        //    return View();

        //}

        ////Calling method with parameters
        //[HttpPost]
        //public ActionResult Create(string name, string gender, string city,int deptid)
        //{
        //    Employee emp = new Employee();
        //    emp.name = name;
        //    emp.gender = gender;
        //    emp.city = city;
        //    emp.deptid = deptid;

        //    EmployeeBusinessLayer eblayer = new EmployeeBusinessLayer();
        //    eblayer.AddEmployee(emp);

        //    return RedirectToAction("Index");
 
        //}

        //Calling method object
        //[HttpPost]
        //public ActionResult Create(FormCollection formCollection)
        //{

        //    /* FOR TEST PURPOSE only - Print all submitted controls */
        //        /*foreach(string frmkey in formCollection.AllKeys)
        //        {
        //        Response.Write("key " + frmkey);
        //        Response.Write(", " +formCollection[frmkey]);
        //        Response.Write("<br>");
        //    }
        //     * */
           
        //    //In this action method, we are reading each of the input
        //    //i.e without binding controls.
        //    Employee emp = new Employee();
        //    emp.name = formCollection["name"];
        //        emp.gender = formCollection["gender"];
        //            emp.city = formCollection["city"];
        //            emp.deptid = Convert.ToInt32(formCollection["deptid"]);

        //                EmployeeBusinessLayer eblayer = new EmployeeBusinessLayer();
        //                eblayer.AddEmployee(emp);

        //                return RedirectToAction("Index");

             
        //}

        

         
    }
}
