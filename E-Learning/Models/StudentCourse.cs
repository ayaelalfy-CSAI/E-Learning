using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class StudentCourse
{
    [Key, Column(Order = 1)]
    public int St_Id { get; set; }

    [Key, Column(Order = 2)]
    public int Crs_Id { get; set; }

    // Navigation properties
    [ForeignKey("St_Id")]
    public Student Student { get; set; }

    [ForeignKey("Crs_Id")]
    public Course Course { get; set; }
}
