using EmployeeManagementWeb.Models;
using EmployeeManagementWeb.Models.ViewModel;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagementWeb.Data
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext>options) : base(options) { }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        [NotMapped]
        public DbSet<EmployeeDepartmentSummaryViewModel> employeeDepartmentSummaryViewModels { get; set; }
    }
}
