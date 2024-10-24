using BLLProject.Interfaces;
using BLLProject.Repositories;
using E_Learning.Helpers;
using E_Learning.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace E_Learning.Controllers
{
    public class LectureController : Controller
    {
        private readonly IGenericRepository<Lecture> lectureRepository;
        private readonly IWebHostEnvironment webHost;

        // inject
        public LectureController(IGenericRepository<Lecture> lectureRepository, IWebHostEnvironment webHost)
        {
            this.lectureRepository = lectureRepository;
            this.webHost = webHost;
        }



        // lecture/index/1
        // id refer to topicId index(getAllLectures)   
        public IActionResult Index(int Id)
        {
            var lectures = lectureRepository.GetAll().Where(l => l.TopicId == Id);

            // Convert to ViewModel if needed
            var lectureViewModels = lectures.Select(lecture => (LectureViewModel)lecture).ToList();

            ViewData["TopicId"] = Id;

            return View(lectureViewModels);
        }

        [HttpGet]
        // id refere to topicId
        // Lecture/AddNewLecture/1
        public IActionResult AddNewLecture(int Id)
        {
            //ViewData["TopicId"] = Id;
            //return View();
            var lectureViewModel = new LectureViewModel
            {
                TopicId = Id // Pre-set the TopicId
            };

            return View(lectureViewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveLecture(LectureViewModel lectureViewModel)
        {
            if (ModelState.IsValid)
            {
                // Handle file upload
                if (lectureViewModel.VideoFile != null)
                {
                    // Ensure you have a method to save the file and get the filename
                    string fileName = DocumentSettings.UploadVideo(lectureViewModel.VideoFile);
                    lectureViewModel.Video = fileName; // Set the video path in the model
                }

                // Convert ViewModel to Model
                var lecture = (Lecture)lectureViewModel;

                // Save lecture in the database
                var count = lectureRepository.Add(lecture);

                if (count > 0)
                {
                    TempData["Message"] = "Lecture created successfully.";
                    return RedirectToAction("Index", new { Id = lectureViewModel.TopicId }); // Redirect to Index with the TopicId
                }
            }

            return View("AddNewLecture", lectureViewModel); // Show the form again with validation errors

            

        }











    }
}













