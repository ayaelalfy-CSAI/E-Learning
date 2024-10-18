using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using DALProject.Models;

public class Course : ModelBase
{       
    public string Title { get; set; } = null!;
    public string Photo { get; set; } = null!;
    public string Description { get; set; } = null!;   
    public decimal Price { get; set; }
    public int? InstructorId { get; set; }

    public Instructor? Instructor { get; set; }

    //public ICollection<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();
    public ICollection<Topic> Topics { get; set; }=new List<Topic>();


}

