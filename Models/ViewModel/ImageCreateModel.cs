using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementWeb.Models.ViewModel
{
    public class ImageCreateModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Please enter namme")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please choose Image/file")]
        [Display(Name= "Choose Image")]
        public IFormFile ImagePath { get; set; }
    }
}
