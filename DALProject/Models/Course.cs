using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class Course
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Name is required"), MaxLength(200)]
    public string Title { get; set; } = null!;

    public string Photo { get; set; } = null!;

    [Required(ErrorMessage = "Description is required")]
    public string Description { get; set; } = null!;
   
    public decimal Price { get; set; }
    public int Ins_Id { get; set; }

    // Navigation properties
    [ForeignKey("Ins_Id")]
    public Instructor? Instructor { get; set; }
    public ICollection<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();
    public ICollection<Topic> Topics { get; set; }=new List<Topic>();


}

