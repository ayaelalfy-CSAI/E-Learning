using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class Course
{
    [Key]
    public int Id { get; set; }

    [Required, MaxLength(200)]
    public string Title { get; set; }

    public string Photo { get; set; }

    [Required]
    public string Description { get; set; }

    [Required]
    public decimal Price { get; set; }

    public int Ins_Id { get; set; }

    // Navigation properties
    [ForeignKey("Ins_Id")]
    public Instructor Instructor { get; set; }

    public ICollection<StudentCourse> StudentCourses { get; set; }
    public ICollection<Topic> Topics { get; set; }
}
