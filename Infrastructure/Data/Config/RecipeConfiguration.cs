using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config;

public class RecipeConfiguration : IEntityTypeConfiguration<Recipe>
{
    public void Configure(EntityTypeBuilder<Recipe> builder)
    {
        builder.Property(r => r.Id).IsRequired();
        builder.Property(r => r.Name).IsRequired().HasMaxLength(100);
        builder.Property(r => r.Description).IsRequired().HasMaxLength(1000);
        builder.Property(r => r.PreparationMinutes).HasColumnType("int").HasDefaultValue(30);
        builder.Property(r => r.CookingMinutes).HasColumnType("int").HasDefaultValue(30);
        builder.Property(r => r.Servings).IsRequired().HasDefaultValue(4);
        builder.Property(r => r.PictureUrl).IsRequired();
        builder.HasOne(rt => rt.RecipeType).WithMany()
            .HasForeignKey(r => r.RecipeTypeId);
    }
}