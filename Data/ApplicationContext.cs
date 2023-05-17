using EmployeeManagementWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementWeb.Data
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext>options) : base(options) { }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Image> Images { get; set; }
    }
}
