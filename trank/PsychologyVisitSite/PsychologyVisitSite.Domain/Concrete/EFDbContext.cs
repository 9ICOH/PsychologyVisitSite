
namespace PsychologyVisitSite.Domain.Concrete
{
    using System.Data.Entity;
    using PsychologyVisitSite.Domain.Entities;

    public class EFDbContext : DbContext
    {
        public DbSet<MeetingEvent> MeetingEvents { get; set; }

        public DbSet<RegistrationForm> Registrations { get; set; }

        public DbSet<Information> Information { get; set; }

        public DbSet<Settings> Settings { get; set; }
    }
}
