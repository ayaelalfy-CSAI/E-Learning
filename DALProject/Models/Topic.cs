using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using DALProject.Models;

public class Topic : ModelBase
{
    public string Title { get; set; } = null!;

    public int CourseId { get; set; }
 
    public Course? Course { get; set; } 

    public ICollection<Lecture> Lectures { get; set; }=new List<Lecture>();
    public ICollection<Assignment> Assignments { get; set; }=new List<Assignment>();
    public ICollection<Exam> Exams { get; set; }=new List<Exam>();


}








