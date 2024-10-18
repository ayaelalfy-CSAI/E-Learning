using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class Exam
{
    public int Id { get; set; }

    [Required]
    public TimeSpan Duration { get; set; }

    public int Topic_Id { get; set; }

    // Navigation properties
    [ForeignKey("Topic_Id")]
    public Topic Topic { get; set; }

    public ICollection<StudentCourseExam> StudentCourseExams { get; set; }=new List<StudentCourseExam>();
}
