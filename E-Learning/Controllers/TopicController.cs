using BLLProject.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_Learning.Controllers
{
    public class TopicController : Controller
    {
        private readonly IGenericRepository<Topic> TopicRepository;
        private readonly IWebHostEnvironment webHost;
        public TopicController(IGenericRepository<Topic> TopicRepository, IWebHostEnvironment webHost)
        {
            this.TopicRepository = TopicRepository;
            this.webHost = webHost;
        }
        public IActionResult Index()
        {
            return View();
        }





    }
}
