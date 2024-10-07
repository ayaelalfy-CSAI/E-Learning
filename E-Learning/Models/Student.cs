using System.ComponentModel.DataAnnotations;

public class Student
{
    [Key]
    public int Id { get; set; }

    [Required, MaxLength(50)]
    public string FName { get; set; }

    [Required, MaxLength(50)]
    public string LName { get; set; }

    [Required, EmailAddress, MaxLength(100)]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }

    // Navigation properties
    public ICollection<StudentCourse> StudentCourses { get; set; }
    public ICollection<StudentCourseAssignment> StudentCourseAssignments { get; set; }
    public ICollection<StudentCourseExam> StudentCourseExams { get; set; }
}
