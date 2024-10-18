using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using DALProject.Models;

public class Assignment : ModelBase
{
    public string Name { get; set; } = null!;

    public int TopicId { get; set; }

    public Topic Topic { get; set; } = null!;

    // public ICollection<StudentCourseAssignment> StudentCourseAssignments { get; set; } = new List<StudentCourseAssignment>();
}

