using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementWeb.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required (ErrorMessage ="* Name can't be Blank")]
        public string Name { get; set; }
        [Required(ErrorMessage = "* City can't be Blank")]
        public string City { get; set; }
        [Required(ErrorMessage = "* State can't be Blank")]
        public string State { get; set; }
        [Required(ErrorMessage = "* Salary can't be Blank")]
        public decimal? Salary  { get; set; }

    }
}
