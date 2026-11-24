namespace GymMangementSystem.Entities
{
    public class MemberShip : BaseEntity
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int MemberId { get; set; }

        public Member Member{ get; set; } = default!;
        public int PlanId { get; set; }
        public Plan plan { get; set; } = default!;
        public string Status => StartDate > DateTime.Now ? "Upcoming" : EndDate > DateTime.Now ? "Active" : "Expired";

    }
}
