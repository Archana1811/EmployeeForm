using EmployeeForm.Models;
using System;
using System.Web.Mvc;

namespace EmployeeForm.Controllers
{
    public class EmployeeController : Controller
    {

        // 1. *************RETRIEVE ALL EMPLOYEE DETAILS ******************
        // GET: Employee
        public ActionResult Index()
        {
            EmployeeDBHandle dbhandle = new EmployeeDBHandle();
            ModelState.Clear();
            return View(dbhandle.GetEmployee());
        }
      

        // 2. *************ADD NEW EMPLOYEE ******************
       // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(EmployeeModel emodel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    EmployeeDBHandle sdb = new EmployeeDBHandle();
                    if (sdb.AddEmployee(emodel))
                    {
                        ViewBag.Message = "Employee Details Added Successfully.";
                        ModelState.Clear();
                    }
                }
                return View();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
