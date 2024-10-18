using DALProject.Models;
using System.ComponentModel.DataAnnotations;

public class Student :ModelBase
{
    public string FName { get; set; } = null!;

    public string LName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

   
    public ICollection<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();
    public ICollection<StudentCourseAssignment> StudentCourseAssignments { get; set; } = new List<StudentCourseAssignment>();
    public ICollection<StudentCourseExam> StudentCourseExams { get; set; } = new List<StudentCourseExam>();
}



