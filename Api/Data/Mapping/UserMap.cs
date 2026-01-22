using Api.Features.Users.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping;

public sealed class UserMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

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

        builder.Property(x => x.Email)
            .HasColumnName("Email")
            .HasColumnType("nvarchar(255)")
            .IsRequired();

        builder.HasIndex(x => x.Email, "Unique_Key_Users_Email")
            .IsUnique();

        builder.Property(x => x.Phone)
            .HasColumnName("Phone")
            .HasColumnType("nvarchar(15)")
            .IsRequired();

        builder.HasIndex(x => x.Phone, "Unique_Key_Users_Phone")
            .IsUnique();

        builder.Property(x => x.Password)
            .HasColumnName("Password")
            .HasColumnType("nvarchar(255)")
            .IsRequired();
    }
}