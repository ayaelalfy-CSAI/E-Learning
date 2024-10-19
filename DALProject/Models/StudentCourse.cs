using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using DALProject.Models;

public class StudentCourse  : ModelBase
{   
    public int StudentId { get; set; }   
    public int CourseId { get; set; }

    public ICollection<Exam> Exams { get; set; } = new List<Exam>();
    public ICollection<Assignment> Assignments { get; set; } = new List<Assignment>();

    //public Student Student { get; set; }

    // public Course Course { get; set; }
}
