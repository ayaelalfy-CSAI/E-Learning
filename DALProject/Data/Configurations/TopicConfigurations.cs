using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALProject.Data.Configurations
{
    public class TopicConfigurations : IEntityTypeConfiguration<Topic>
    {
        public void Configure(EntityTypeBuilder<Topic> builder)
        {
            builder.Property(t => t.Title)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.HasMany(t => t.Lectures)
                  .WithOne(l => l.Topic)
                  .HasForeignKey(l => l.TopicId);

            builder.HasMany(t => t.Assignments)
                  .WithOne(a => a.Topic) 
                  .HasForeignKey(a => a.TopicId);

            builder.HasMany(t => t.Exams)
                   .WithOne(e => e.Topic)
                   .HasForeignKey(e => e.TopicId);





        }
    }
}
