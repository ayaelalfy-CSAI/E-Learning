using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using DALProject.Models;

public class Exam : ModelBase
{
    public TimeSpan Duration { get; set; }
    public int TopicId { get; set; }

    public Topic Topic { get; set; }

    public ICollection<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();

    //public ICollection<StudentCourseExam> StudentCourseExams { get; set; }=new List<StudentCourseExam>();
}
