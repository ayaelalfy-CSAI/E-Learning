using Microsoft.AspNetCore.Mvc;

namespace E_Learning.Controllers
{
    public class LectureController : Controller
    {           
        // lecture/index             index(getAllLectures)   
        public IActionResult Index()
        {
             return View();
        }
    }
}











