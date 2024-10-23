using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using DALProject.Models;

public class StudentCourseExam  :ModelBase
{
    public int StudentId { get; set; }

    public int CourseId { get; set; }
    public int ExamId { get; set; }

   // public ICollection<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();
    public Student Student { get; set; }

    public Course Course { get; set; }

    public Exam Exam { get; set; }
}
