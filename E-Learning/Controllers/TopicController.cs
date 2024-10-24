using BLLProject.Interfaces;
using BLLProject.Repositories;
using E_Learning.ViewModels;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using System.Security.Cryptography.X509Certificates;

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

        // topic/index/25    (getall)
        // Id refers to courseId
        public IActionResult Index(int Id)
        {
            IEnumerable<Topic> topics = TopicRepository.GetAll();

            var filteredTopics = topics.Where(topic => topic.CourseId == Id);

            var courseViewModels = filteredTopics.Select(topic => (TopicViewModel)topic).ToList();

            ViewData["CourseId"] = Id;

            return View(courseViewModels);
        }

        // topic/ addnewtopic
        public IActionResult AddNewTopic(int courseId)
        {
            ViewData["CourseId"] = courseId;
            return View();
        }

        // topic/SaveTopic
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveTopic(TopicViewModel TopicViewModel)
        {

            if (ModelState.IsValid)
            {
                var course = (Topic)TopicViewModel; // Convert ViewModel to Model
                var count = TopicRepository.Add(course);

                if (count > 0)
                {
                    TempData["Message"] = "Course Created Successfully";
                    return RedirectToAction(nameof(Index), new { Id = TopicViewModel.CourseId });
                }
            }
            return View("AddNewCourse", TopicViewModel);
        }

        // Topic/Delete/25
        public IActionResult Delete(int Id)
        {
            var topic = TopicRepository.GetById(Id);

            if (topic == null)
            {
                return NotFound(); // If the topic does not exist, return a 404
            }

            int result = TopicRepository.Delete(topic);

            if (result > 0)
            {
                TempData["Message"] = "Topic Deleted Successfully";
                return RedirectToAction(nameof(Index), new { Id = topic.CourseId });
            }

            TempData["Error"] = "Unable to delete topic";
            return RedirectToAction(nameof(Index), new { Id = topic.CourseId });
        }



        // public IActionResult SaveDelete()
        //{                                  
        //}











    }
}
