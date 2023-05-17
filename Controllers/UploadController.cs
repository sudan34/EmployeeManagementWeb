using EmployeeManagementWeb.Data;
using EmployeeManagementWeb.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using EmployeeManagementWeb.Models;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace EmployeeManagementWeb.Controllers
{
    public class UploadController : Controller
    {
        private readonly ApplicationContext context;
        private readonly IHostingEnvironment environment;
        public UploadController(ApplicationContext context, IHostingEnvironment environment)
        {
            this.context = context;
            this.environment = environment;
        }
        [HttpGet]
        public IActionResult UploadImage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult UploadImage(ImageCreateModel model)
        {
            if (ModelState.IsValid)
            {
                var path = environment.WebRootPath;
                var filePath = "Content/Image/" + model.ImagePath.FileName;
                var fullPath = Path.Combine(path, filePath);
                UploadFile(model.ImagePath, fullPath);
                var data = new Image()
                {
                    Name = model.Name,
                    ImagePath = filePath
                };
                context.Add(data);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }
        public void UploadFile(IFormFile file, string path)
        {
            FileStream stream = new FileStream(path, FileMode.Create);
            file.CopyTo(stream);
        }

        public IActionResult Index()
        {
            var result = context.Images.ToList();
            return View(result);
        }
        public IActionResult Delete(int id)
        {
            var img = context.Images.SingleOrDefault(e => e.Id == id);
            context.Images.Remove(img);
            context.SaveChanges();
            TempData["error"] = "Image Deleted !";
            return RedirectToAction("Index");
        }
        
    }
}
