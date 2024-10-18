using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALProject.Data.Configurations
{
    public class CourseConfigurations : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> course)
        {
            course.Property(c => c.Title)
                .HasColumnType("nvarchar")
                .HasMaxLength(50);

            course.Property(c => c.Description)
               .HasColumnType("nvarchar")
               .HasMaxLength(150);

            //course.HasOne(c => c.Instructor) 
            //   .WithMany(i => i.Courses) 
            //   .HasForeignKey(c => c.InstructorId);

            //course.HasMany(c => c.Topics)
            //    .WithOne() 
            //    .HasForeignKey(t => t.CourseId);
        }
    }
}
