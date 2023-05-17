using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementWeb.Models
{
    public class Image
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
    }
}
