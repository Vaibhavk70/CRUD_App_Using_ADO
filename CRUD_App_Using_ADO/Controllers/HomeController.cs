using CRUD_App_Using_ADO.Models;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Linq;
using System.Linq.Expressions;

namespace CRUD_App_Using_ADO.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            EmployeeDBContext db = new EmployeeDBContext();
            List<Employee> Obj = db.GetEmployees();
            return View(Obj);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee emp)
        {
            try
            {
                if (ModelState.IsValid == true)
                {
                    EmployeeDBContext Context = new EmployeeDBContext();
                    bool Check = Context.AddEmployee(emp);
                    if (Check == true)
                    {
                        TempData["InsertMessage"] = "Data has been inserted Successfuly.";
                        ModelState.Clear();
                        return RedirectToAction("Index");
                    }

                }

                return View();
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Edit(int ID)
        {
            EmployeeDBContext Context = new EmployeeDBContext();
            var row = Context.GetEmployees().Find(model => model.ID == ID);

            return View(row);
        }

        [HttpPost]
        public ActionResult Edit( Employee emp)
        {

            try
            {
                if (ModelState.IsValid == true)
                {
                    EmployeeDBContext Context = new EmployeeDBContext();
                    bool Check = Context.UpdateEmployee(emp);
                    if (Check == true)
                    {
                        TempData["UpdateMessage"] = "Data has been Updated Successfuly.";
                        ModelState.Clear();
                        return RedirectToAction("Index");
                    }

                }

                return View();
            }
            catch
            {
                return View();
            }

        }
        public ActionResult Delete(int ID)
        {
            EmployeeDBContext Context = new EmployeeDBContext();
            var row = Context.GetEmployees().Find(model => model.ID == ID);

            return View(row);
        }

        [HttpPost]
        public ActionResult Delete(int ID, Employee emp)
        {

            EmployeeDBContext Context = new EmployeeDBContext();
            bool Check = Context.DeleteEmployee(ID);
            if (Check == true)
            {
                TempData["DeleteMessage"] = "Data has been Deleted Successfuly.";
                return RedirectToAction("Index");
            }
            return View();

        }
    }
}