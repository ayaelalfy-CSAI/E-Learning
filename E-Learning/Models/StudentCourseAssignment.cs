using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class StudentCourseAssignment
{
    [Key, Column(Order = 1)]
    public int St_Id { get; set; }

    [Key, Column(Order = 2)]
    public int Crs_Id { get; set; }

    [Key, Column(Order = 3)]
    public int Assignment_Id { get; set; }

    // Navigation properties
    [ForeignKey("St_Id")]
    public Student Student { get; set; }

    [ForeignKey("Crs_Id")]
    public Course Course { get; set; }

    [ForeignKey("Assignment_Id")]
    public Assignment Assignment { get; set; }
}
