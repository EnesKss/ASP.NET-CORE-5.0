using Microsoft.AspNetCore.Mvc;
using App.Services;
using App.ViewModels;

namespace App.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public IActionResult Index()
        {
            var studentList = _studentService.GetAllStudents();
            
            var viewModel = new StudentListViewModel 
            {
                Students = studentList
            };

            return View(viewModel);
        }
    }
}
