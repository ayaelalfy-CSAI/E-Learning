using System.ComponentModel.DataAnnotations;

public class Instructor
{
    public int Id { get; set; }

    public string FName { get; set; } = null!;

    public string LName { get; set; } = null!;

    [Required, EmailAddress, MaxLength(150)]
    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Bio { get; set; } = null!;

    // Navigation properties
    public ICollection<Course> Courses { get; set; } = new List<Course>();
}
