using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using DALProject.Models;

public class Lecture : ModelBase
{
    public string Title { get; set; } = null!;

    public string? Video { get; set; } 

    public int TopicId { get; set; }

    public Topic Topic { get; set; } = null!;
}
