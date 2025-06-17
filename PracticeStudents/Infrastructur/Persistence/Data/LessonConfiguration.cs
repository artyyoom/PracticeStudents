using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PracticeStudents.Domain.Entities;


public class LessonConfiguration : IEntityTypeConfiguration<Lesson>
{
    public void Configure(EntityTypeBuilder<Lesson> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Date)
            .IsRequired();

        builder.Property(e => e.Topic)
            .IsRequired()
            .HasMaxLength(255);

        builder.HasOne(e => e.Group)
            .WithMany(g => g.Lessons)
            .HasForeignKey(e => e.GroupId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
