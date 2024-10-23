using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALProject.Data.configrations
{
    public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.Property(i => i.FName)
                   .IsRequired()
                   .HasMaxLength(50);  

            builder.Property(i => i.LName)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(i => i.Email)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(i => i.Password)
                   .IsRequired()
                   .HasMaxLength(255); 

            builder.Property(i => i.Bio)
                   .HasMaxLength(500);



        }
    }
}
