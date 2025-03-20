using mega.Api.Infrastructure.Db.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace mega.Api.Infrastructure.Db.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasIndex(x => x.Username).IsUnique();
            builder.HasIndex(x => x.Email).IsUnique();

            builder.HasMany(x => x.Accounts)
                .WithOne(a => a.User)
                .HasForeignKey(a => a.UserId)
                .HasConstraintName("FK_Accounts_Users_UserId")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
