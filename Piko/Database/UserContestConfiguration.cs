using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Piko.Models.Entities;


namespace Piko.Database
{
    public class UserContestConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
           builder
                .HasMany(u => u.Contests)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.UserId);

            builder
                .HasMany(u => u.ContestsLiked)
                .WithMany(c => c.UsersLiked)
                .UsingEntity<UserContestsLiked>();

            builder
                .HasMany(u => u.ContestsPassed)
                .WithMany(c => c.UsersPassed)
                .UsingEntity<UserContestsPassed>();
        }
    }
}