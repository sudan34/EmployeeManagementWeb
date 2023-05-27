using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace EmployeeManagementWeb.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        [Display(Name = "Department Name")]
        [Required(ErrorMessage = "Please enter department name")]
        public string DepartmentName { get; set; } = default!;
        [Display(Name = "Department Code")]
        [Required(ErrorMessage = "Please enter department code")]
        public string DepartmentCode { get; set; } = default!;
    }
}
