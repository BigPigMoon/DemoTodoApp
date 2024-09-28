using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoService.Domain.Entities;

namespace TodoService.Infrastructure.Database.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> entity)
    {
        entity.HasKey(x => x.Id);

        entity.HasMany(x => x.Todos)
              .WithOne(x => x.Owner)
              .HasForeignKey(x => x.UserId);
    }
}
