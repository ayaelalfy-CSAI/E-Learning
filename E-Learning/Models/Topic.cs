using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class Topic
{
    [Key]
    public int Id { get; set; }

    [Required, MaxLength(200)]
    public string Title { get; set; }

    public int Crs_Id { get; set; }

    // Navigation properties
    [ForeignKey("Crs_Id")]
    public Course Course { get; set; }

    public ICollection<Lecture> Lectures { get; set; }
    public ICollection<Assignment> Assignments { get; set; }
    public ICollection<Exam> Exams { get; set; }
}
