using System.ComponentModel.DataAnnotations;

public class Student
{
    public int Id { get; set; }

    [Required, MaxLength(50)]
    public string FName { get; set; } = null!;

    [Required, MaxLength(50)]
    public string LName { get; set; } = null!;

    [Required, EmailAddress, MaxLength(100)]
    public string Email { get; set; } = null!;

    [Required]
    public string Password { get; set; } = null!;

    // Navigation properties
    public ICollection<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();
    public ICollection<StudentCourseAssignment> StudentCourseAssignments { get; set; } = new List<StudentCourseAssignment>();
    public ICollection<StudentCourseExam> StudentCourseExams { get; set; } = new List<StudentCourseExam>();
}
