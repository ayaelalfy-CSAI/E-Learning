using DALProject.Models;
using System.ComponentModel.DataAnnotations;

public class Instructor :ModelBase
{
    public string FName { get; set; } = null!;

    public string LName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Bio { get; set; } = null!;

    public ICollection<Course> Courses { get; set; } = new List<Course>();
}
