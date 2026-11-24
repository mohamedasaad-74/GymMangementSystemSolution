using GymMangementSystem.Entities.Enums;

namespace GymMangementSystem.Entities
{
    public class Trainer :GymUser
    {
        public DateTime HireDate { get; set; }
        public Specialties specialties { get; set; }

        public ICollection<Session> Sessions { get; set; } = new HashSet<Session>(); 
    }
}
