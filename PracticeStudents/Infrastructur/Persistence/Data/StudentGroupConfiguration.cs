using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PracticeStudents.Domain.Entities;


public class StudentsGroupsConfiguration : IEntityTypeConfiguration<StudentsGroup>
{
    public void Configure(EntityTypeBuilder<StudentsGroup> builder)
    {
        builder.HasKey(e => e.Id);

        builder.HasOne(e => e.Student)
            .WithMany(u => u.StudentsInGroups)
            .HasForeignKey(e => e.StudentId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(e => e.Group)
            .WithMany(g => g.StudentsInGroups)
            .HasForeignKey(e => e.GroupId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
