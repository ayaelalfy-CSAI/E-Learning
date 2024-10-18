using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class Topic
{
    public int Id { get; set; }

    [Required, MaxLength(200)]
    public string Title { get; set; } = null!;

    public int Crs_Id { get; set; }

    // Navigation properties
    [ForeignKey("Crs_Id")]
    public Course Course { get; set; } = null!;

    public ICollection<Lecture> Lectures { get; set; }=new List<Lecture>();
    public ICollection<Assignment> Assignments { get; set; }=new List<Assignment>();
    public ICollection<Exam> Exams { get; set; }=new List<Exam>();


}








