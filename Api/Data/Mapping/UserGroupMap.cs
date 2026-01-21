using Api.Features.UserGroups.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping;

public sealed class UserGroupMap : IEntityTypeConfiguration<UserGroup>
{
    public void Configure(EntityTypeBuilder<UserGroup> builder)
    {
        builder.ToTable("UserGroups");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("Id")
            .HasColumnType("uniqueidentifier")
            .IsRequired();

        builder.Property(x => x.Created)
            .HasColumnName("Created")
            .HasColumnType("datetime2")
            .IsRequired();

        builder.Property(x => x.UserId)
            .HasColumnName("UserId")
            .HasColumnType("uniqueidentifier")
            .IsRequired();

        builder.Property(x => x.GroupId)
            .HasColumnName("GroupId")
            .HasColumnType("uniqueidentifier")
            .IsRequired();

        builder.Property(x => x.Role)
            .HasColumnName("Role")
            .HasColumnType("tinyint")
            .IsRequired();
    }
}