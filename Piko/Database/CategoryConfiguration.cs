using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Piko.Models.Entities;

namespace Piko.Database
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
              new Category { Id = 1, Name = "music"},
              new Category { Id = 2, Name = "cinema"},
              new Category { Id = 3, Name = "sport"},
              new Category { Id = 4, Name = "technology"},
              new Category { Id = 5, Name = "fashion"},
              new Category { Id = 6, Name = "nature"},
              new Category { Id = 7, Name = "games"},
              new Category { Id = 8, Name = "other"}
            );
        }
    }
}