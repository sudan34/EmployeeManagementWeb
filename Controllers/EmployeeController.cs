using EmployeeManagementWeb.Data;
using EmployeeManagementWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;

namespace EmployeeManagementWeb.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationContext context;

        public EmployeeController(ApplicationContext context) 
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var result = context.Employees.ToList();
            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee Model)
        {
            if (ModelState.IsValid)
            {
                var emp = new Employee();
                {
                    emp.Name = Model.Name;
                    emp.City = Model.City;
                    emp.State= Model.State;
                    emp.Salary= Model.Salary;
                };
                context.Employees.Add(emp);
                context.SaveChanges();
                TempData["error"] = "Record Saved !";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["message"] = "Empty field can't sunmit";
                return View();
            }
        }
        public IActionResult Delete(int id)
        {
            var emp = context.Employees.SingleOrDefault(e => e.Id == id);
            context.Employees.Remove(emp);
            context.SaveChanges();
            TempData["error"] = "Record Deleted !";
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var emp = context.Employees.SingleOrDefault(e => e.Id == id);  
            var result = new Employee()
            {
                Name = emp.Name,
                City = emp.City,
                State = emp.State,
                Salary = emp.Salary
            };
            return View(result);
        }
        [HttpPost]
        public IActionResult Edit(Employee model)
        {
            var emp = new Employee()
            {
                Id= model.Id,
                Name = model.Name,
                City = model.City,
                State = model.State,
                Salary = model.Salary
            };
            context.Employees.Update(emp);
            context.SaveChanges();
            TempData["error"] = "Record Updated !";
            return RedirectToAction("Index");
        }

    }
}
