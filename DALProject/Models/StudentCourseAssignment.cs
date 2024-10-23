 using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using DALProject.Models;

public class StudentCourseAssignment : ModelBase
{

    public int StudentId { get; set; }

    public int CourseId { get; set; }

    public int AssignmentId { get; set; }

    public Student Student { get; set; }

    public Course Course { get; set; }
    public Assignment Assignment { get; set; }
}
