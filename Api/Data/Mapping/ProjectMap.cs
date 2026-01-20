using Api.Features.Projects.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping;

public sealed class ProjectMap : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.ToTable("Projects");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("Id")
            .HasColumnType("uniqueidentifier")
            .IsRequired();

        builder.Property(x => x.Name)
            .HasColumnName("Name")
            .HasColumnType("nvarchar(100)")
            .IsRequired();

        builder.Property(x => x.Created)
            .HasColumnName("Created")
            .HasColumnType("datetime2")
            .IsRequired();

        builder.Property(x => x.Status)
            .HasColumnName("Status")
            .HasColumnType("tinyint")
            .IsRequired();

        builder.Property(x => x.Deadline)
            .HasColumnName("Deadline")
            .HasColumnType("datetime2");

        builder.Property(x => x.OwnerId)
            .HasColumnName("OwnerId")
            .HasColumnType("uniqueidentifier")
            .IsRequired();

        builder.Property(x => x.IsPersonal)
            .HasColumnName("IsPersonal")
            .HasColumnType("bit")
            .IsRequired();
    }
}