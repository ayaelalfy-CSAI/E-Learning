using System.ComponentModel.DataAnnotations;

public class Instructor
{
    [Key]
    public int Id { get; set; }

    [Required, MaxLength(50)]
    public string FName { get; set; }

    [Required, MaxLength(50)]
    public string LName { get; set; }

    [Required, EmailAddress, MaxLength(100)]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }

    public string Bio { get; set; }

    // Navigation properties
    public ICollection<Course> Courses { get; set; }
}
