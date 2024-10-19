using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
        
    }

    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Student> Students { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Instructor> Instructors { get; set; }
    public DbSet<Assignment> Assignments { get; set; }
    public DbSet<Exam> Exams { get; set; }
    public DbSet<Topic> Topics { get; set; }
    public DbSet<Lecture> Lectures { get; set; }
    public DbSet<StudentCourse> StudentCourses { get; set; }
    public DbSet<StudentCourseAssignment> StudentCourseAssignments { get; set; }
    public DbSet<StudentCourseExam> StudentCourseExams { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       
    }
}
