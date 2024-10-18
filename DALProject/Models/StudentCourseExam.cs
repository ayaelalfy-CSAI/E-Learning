using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using DALProject.Models;

public class StudentCourseExam : ModelBase
{
    public int StudentId { get; set; }

    public int CourseId { get; set; }

    public int ExamId { get; set; }


    public Student Student { get; set; } = new Student();

    public Exam Exam { get; set; } = new Exam();
}





