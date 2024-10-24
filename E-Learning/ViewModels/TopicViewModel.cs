using E_Learning.Helpers;

namespace E_Learning.ViewModels
{
    public class TopicViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;

        public int CourseId { get; set; }

        public Course? Course { get; set; } 

        public ICollection<Lecture> Lectures { get; set; } = new List<Lecture>();
        public ICollection<Assignment> Assignments { get; set; } = new List<Assignment>();
        public ICollection<Exam> Exams { get; set; } = new List<Exam>();

        public static explicit operator TopicViewModel(Topic model)
        {
            return new TopicViewModel
            {
                Id = model.Id,
                Title = model.Title,
                CourseId = model.CourseId,
                Lectures = model.Lectures,
                

            };
        }

        public static explicit operator Topic(TopicViewModel ViewModel)
        {
            return new Topic
            {
                Id = ViewModel.Id,
                Title = ViewModel.Title,
                CourseId = ViewModel.CourseId,       
                Lectures = ViewModel.Lectures,
                                               
            };
        }
    }
}
