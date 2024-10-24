using DALProject.Models;
using E_Learning.Helpers;

namespace E_Learning.ViewModels
{
    public class LectureViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;

        public string? Video { get; set; }

        public int TopicId { get; set; }

        public Topic? Topic { get; set; }
        public IFormFile? VideoFile { get; set; }


        public static explicit operator LectureViewModel(Lecture model)
        {
            return new LectureViewModel
            {
                Id = model.Id,
                Title = model.Title,
                Video = model.Video,
                TopicId = model.TopicId,
                Topic = model.Topic
            };
        }

        public static explicit operator Lecture(LectureViewModel ViewModel)
        {
            if (ViewModel.VideoFile is not null)
            {
                ViewModel.Video = DocumentSettings.UploadFile(ViewModel.VideoFile, "video");  // Correctly handle file upload
            }
            return new Lecture
            {
                Id = ViewModel.Id,
                Title = ViewModel.Title,
                Video = string.IsNullOrEmpty(ViewModel.Video) ? null : ViewModel.Video,               
                TopicId = ViewModel.TopicId,
                Topic = ViewModel.Topic

            };
        }





    }
}
