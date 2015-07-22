
namespace PsychologyVisitSite.Domain.Entities
{
    public class UserRole
    {
        public int ID { get; set; }

        public int UserID { get; set; }

        public int RoleID { get; set; }

        public Role Role { get; set; }

        public User User { get; set; }
    }
}
