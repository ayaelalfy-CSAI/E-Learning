using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
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
        // Composite keys
        modelBuilder.Entity<StudentCourse>()
            .HasKey(sc => new { sc.St_Id, sc.Crs_Id });

        modelBuilder.Entity<StudentCourseAssignment>()
            .HasKey(sca => new { sca.St_Id, sca.Crs_Id, sca.Assignment_Id });

        modelBuilder.Entity<StudentCourseExam>()    
            .HasKey(sce => new { sce.St_Id, sce.Crs_Id, sce.Exam_Id });
    }
}
