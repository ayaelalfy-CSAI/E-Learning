using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALProject.Data.Configurations
{
    internal class StudentConfigurations : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.Property(s => s.FName)
                .HasMaxLength(50);

            builder.Property(s => s.LName)
                .HasMaxLength(50);

            builder.Property(s => s.Email)
                .HasMaxLength(100)
                .HasAnnotation("EmailAddress", true);

          
            builder.HasMany(s => s.StudentCourseExams)
                   .WithOne(sce => sce.Student)
                   .HasForeignKey(sce => sce.StudentId);

        }
    }
}
