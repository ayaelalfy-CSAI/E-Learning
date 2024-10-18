using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class Lecture
{
    public int Id { get; set; }

    [Required, MaxLength(200)]
    public string Title { get; set; } = null!;

    public string? Video { get; set; } 

    public int Topic_Id { get; set; }

    // Navigation properties
    [ForeignKey("Topic_Id")]
    public Topic Topic { get; set; } = null!;
}
