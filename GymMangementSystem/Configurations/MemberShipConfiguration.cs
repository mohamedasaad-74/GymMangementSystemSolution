using GymMangementSystem.Entities;
using Microsoft.EntityFrameworkCore;

namespace GymMangementSystem.Configurations
{
    public class MemberShipConfiguration : IEntityTypeConfiguration<MemberShip>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<MemberShip> builder)
        {
           builder.HasKey(m => m.Id);
            builder.Property(X => X.CreatedAt).HasDefaultValueSql("GetDate()");

            builder.HasOne(m=>m.plan).WithMany(p=>p.MemberShips).HasForeignKey(m=>m.PlanId).OnDelete(DeleteBehavior.Restrict);

        }

    }
}
