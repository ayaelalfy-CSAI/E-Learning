using DALProject.Models;
using E_Learning.Helpers;
using System.Reflection.Metadata;

namespace E_Learning.ViewModels
{
    public class CourseViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Photo { get; set; }
        public IFormFile? formFile { get; set; }
        public string Description { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public int InstructorId { get; set; }

        public Instructor? Instructor { get; set; }

        public ICollection<Student> Students { get; set; } = new List<Student>();

        public ICollection<Topic> Topics { get; set; } = new List<Topic>();

        public static explicit operator CourseViewModel(Course model)
        {
            return new CourseViewModel
            {
                Id = model.Id,
                Title = model.Title,
                Photo = model.Photo,
                Price = model.Price,
                Description = model.Description,
                InstructorId = model.InstructorId,
                // Students = model.Students,
                // Topics = model.Topics,

            };
        }

        public static explicit operator Course(CourseViewModel ViewModel)
        {
            if (ViewModel.formFile is not null)
            {
                ViewModel.Photo = DocumentSettings.UploadFile(ViewModel.formFile, "img");  // Correctly handle file upload
            }

            return new Course
            {
                Id = ViewModel.Id,
                Title = ViewModel.Title,
                //Photo = ViewModel.Photo,
                Photo = string.IsNullOrEmpty(ViewModel.Photo) ? null : ViewModel.Photo,
                Price = ViewModel.Price,
                Description = ViewModel.Description,
                InstructorId = ViewModel.InstructorId,
                //Students = ViewModel.Students,
                //Topics = ViewModel.Topics,

            };
        }


    }

}









