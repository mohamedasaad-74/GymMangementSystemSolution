using System.ComponentModel.DataAnnotations;

namespace GymMangementSystem.Entities
{
    
    public class Plan :BaseEntity
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
       // [Range(1,365,ErrorMessage = "Out of Duratoin Range")]
        public int DurationDays { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
        public ICollection<MemberShip> MemberShips { get; set; } = new HashSet<MemberShip>();
    }
}
