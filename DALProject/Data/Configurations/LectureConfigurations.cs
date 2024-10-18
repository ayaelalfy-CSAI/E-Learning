using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALProject.Data.Configurations
{
    public class LectureConfigurations : IEntityTypeConfiguration<Lecture>
    {
        public void Configure(EntityTypeBuilder<Lecture> builder)
        {
            builder.Property(l => l.Title)
                 .IsRequired()
                 .HasMaxLength(200);

            builder.HasOne(l => l.Topic)
                 .WithMany(t => t.Lectures)
                 .HasForeignKey(l => l.TopicId);

        }
    }
}
