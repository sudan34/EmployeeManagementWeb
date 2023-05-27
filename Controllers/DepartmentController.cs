﻿using EmployeeManagementWeb.Data;
using EmployeeManagementWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementWeb.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly ApplicationContext context;

        public DepartmentController(ApplicationContext context)
        {
            this.context = context;
        }
        public async Task<IActionResult> Index()
        {
            var data = await context.Departments.ToListAsync();
            return View(data);
        }

        public IActionResult AddDepartment()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddDepartment(Department department)
        {
            if (!ModelState.IsValid)
            {
                return View(department);
            }
            else
            {
                await context.Departments.AddAsync(department);
                await context.SaveChangesAsync();
                TempData["success"] = "Department has been created!";
            }
            return RedirectToAction("Index");
        }
    }
}
