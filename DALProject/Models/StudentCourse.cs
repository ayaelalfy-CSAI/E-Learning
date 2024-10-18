using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using DALProject.Models;

public class StudentCourse : ModelBase
{   
    public int StudentId { get; set; }   
    public int CourseId { get; set; }

    public Student Student { get; set; } = new Student();

    public Course Course { get; set; } = new Course();
}
