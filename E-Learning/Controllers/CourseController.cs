using BLLProject.Interfaces;
using BLLProject.Repositories;
using E_Learning.ViewModels;
using Microsoft.AspNetCore.Mvc;
using DALProject.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace E_Learning.Controllers
{ 
    public class CourseController : Controller 
    {
        private readonly IGenericRepository<Course> courseRepository; 
        private readonly IWebHostEnvironment webHost; 
        public CourseController(IGenericRepository<Course> courseRepository,IWebHostEnvironment webHost)
        {
            this.courseRepository = courseRepository; 
            this.webHost = webHost;                     
        }      
        public IActionResult Index()
        {      
            IEnumerable<Course> courses = courseRepository.GetAll();
            var courseViewModels = courses.Select(course => (CourseViewModel)course).ToList(); // Map to ViewModel

            return View(courseViewModels);
        }

        #region Create
        // course/AddNewCourse
        [HttpGet] 
        public IActionResult AddNewCourse()
        {
            return View();
        }

        // course/SaveCourse
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveCourse(CourseViewModel courseViewModel)
        {
            
            if (ModelState.IsValid)
            {
                var course = (Course)courseViewModel; // Convert ViewModel to Model
                var count = courseRepository.Add(course);

                if (count > 0)
                {
                    TempData["Message"] = "Course Created Successfully";
                    return RedirectToAction(nameof(Index));
                }
            }
            return View("AddNewCourse", courseViewModel);
        }
        #endregion

        // course/Detail/id
        public IActionResult Detail(int? id,string ViewName= "Detail")
        {
            if (!id.HasValue)
                return BadRequest();

            var course = courseRepository.GetById(id.Value);

            if(course is null)
                return NotFound();

            var courseViewModel = (CourseViewModel)course; // Convert Model to ViewModel
            return View(ViewName, courseViewModel);

           // return View(ViewName, course);
        }

        // course/Edit/id
        [HttpGet]       
        public IActionResult Edit (int? id)
        {           
            return Detail(id, nameof(Edit));
        }

        //course/SaveEdit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveEdit([FromRoute] int Id, CourseViewModel courseViewModel)
        {
            if (Id != courseViewModel.Id)
                return BadRequest();

            if (!ModelState.IsValid)
                return View(nameof(Edit), courseViewModel);

            try
            {
                // Retrieve the existing course from the repository
                var existingCourse = courseRepository.GetById(Id);
                if (existingCourse == null)
                {
                    return NotFound();
                }

                // If a new image is uploaded, update the Photo field
                if (courseViewModel.formFile != null && courseViewModel.formFile.Length > 0)
                {
                    var fileName = Path.GetFileName(courseViewModel.formFile.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        courseViewModel.formFile.CopyTo(stream);
                    }

                    existingCourse.Photo = fileName; // Update the Photo field in the existing course
                }

                // Update other properties
                existingCourse.Title = courseViewModel.Title;
                existingCourse.Description = courseViewModel.Description;
                existingCourse.Price = courseViewModel.Price;
                existingCourse.InstructorId = courseViewModel.InstructorId;

                // Update the course in the repository
                courseRepository.Update(existingCourse);

                TempData["Message"] = "Course Updated Successfully";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, webHost.IsDevelopment() ? ex.Message : "An Error Occurred During Updating the Course");
                return View(nameof(Edit), courseViewModel);
            }
        }

        //public IActionResult SaveEdit([FromRoute] int Id, CourseViewModel courseViewModel)
        //{
        //    //if (Id != courseViewModel.Id)
        //    //    return BadRequest();

        //    //if (!ModelState.IsValid)
        //    //    return View(nameof(Edit), courseViewModel);

        //    //try
        //    //{
        //    //    // Retrieve the existing course to check the current image path
        //    //    var existingCourse = courseRepository.GetById(Id);
        //    //    if (existingCourse == null)
        //    //    {
        //    //        return NotFound();
        //    //    }

        //    //    // Update the properties of the existing course
        //    //    existingCourse.Title = courseViewModel.Title;
        //    //    existingCourse.Description = courseViewModel.Description;
        //    //    existingCourse.Price = courseViewModel.Price;
        //    //    existingCourse.InstructorId = courseViewModel.InstructorId;

        //    //    // Check if a new image file is uploaded
        //    //    if (courseViewModel.formFile != null && courseViewModel.formFile.Length > 0)
        //    //    {
        //    //        // Generate a new file name to avoid conflicts
        //    //        var fileName = Path.GetFileName(courseViewModel.formFile.FileName);
        //    //        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", fileName);

        //    //        // Ensure to delete the old file if needed
        //    //        var oldFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", existingCourse.Photo);
        //    //        if (System.IO.File.Exists(oldFilePath))
        //    //        {
        //    //            System.IO.File.Delete(oldFilePath);
        //    //        }

        //    //        // Save the new image
        //    //        using (var stream = new FileStream(filePath, FileMode.Create))
        //    //        {
        //    //            courseViewModel.formFile.CopyTo(stream);
        //    //        }

        //    //        // Update the Photo field in the existing course
        //    //        existingCourse.Photo = fileName;
        //    //    }

        //    //    // Update the course in the repository
        //    //    courseRepository.Update(existingCourse);

        //    //    TempData["Message"] = "Course Updated Successfully";
        //    //    return RedirectToAction(nameof(Index));
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    if (webHost.IsDevelopment())
        //    //        ModelState.AddModelError(string.Empty, ex.Message);
        //    //    else
        //    //        ModelState.AddModelError(string.Empty, "An Error Occurred During Updating the Course");

        //    //    return View(nameof(Edit), courseViewModel);
        //    //}
        //    //////////////////////////////////////////////// (simple that i writen)
        //    if (Id != courseViewModel.Id)
        //        return BadRequest();

        //    if (!ModelState.IsValid)
        //        return View(nameof(Edit), courseViewModel);

        //    try
        //    {
        //        var course = (Course)courseViewModel; // Convert ViewModel to Model
        //        courseRepository.Update(course);

        //        TempData["Message"] = "Course Updated Successfully";
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch (Exception ex)
        //    {
        //        if (webHost.IsDevelopment())
        //            ModelState.AddModelError(string.Empty, ex.Message);
        //        else
        //            ModelState.AddModelError(string.Empty, "An Error Occured During Updating the Course");

        //        return View(nameof(Edit), courseViewModel);
        //    }
        //    //////////////////////////////////////////////////////////

        //}

        [HttpGet]
        public IActionResult Delete(int? id)
        {           
            return Detail(id, nameof(Delete));
        } 

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveDelete([FromRoute] int Id, CourseViewModel courseViewModel)
        {
            if (Id != courseViewModel.Id)
                return BadRequest();

            try
            {
                //casting
                courseRepository.Delete((Course)courseViewModel);
                TempData["Message"] = "Course Deleted Successfully";
                return RedirectToAction(nameof(Index));
            }

            catch (Exception ex)
            {
                if (webHost.IsDevelopment())
                    ModelState.AddModelError(string.Empty, ex.Message);
                else
                    ModelState.AddModelError(string.Empty, "An Error Occured During Updating the Course");
                return View(nameof(Delete), courseViewModel);
            }
        }

        // course/Manage
        public IActionResult Manage()
        {
            return View();
        }




    }

 }
