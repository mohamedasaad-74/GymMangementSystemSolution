using GymMangementSystem.Entities;
using Microsoft.EntityFrameworkCore;

namespace GymMangementSystem.Configurations
{
    public class SessionConfiguration : IEntityTypeConfiguration<Session>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Session> builder)
        {
            builder.Property(X => X.CreatedAt).HasDefaultValueSql("GetDate()");
            builder.HasOne(x => x.Trainer).WithMany(t => t.Sessions).OnDelete(DeleteBehavior.Restrict);

            builder.ToTable(t => {
                t.HasCheckConstraint("SessionCapacityConstraint","Capacity between 1 and 25");
                t.HasCheckConstraint("SessionEndDateAfterStartDate", " EndDate>StartDate");
            });
        }
    }
}
