
namespace PsychologyVisitSite.Domain.Entities
{
    using PsychologyVisitSite.Domain.Enums;

    public class RegistrationForm
    {
        public int Id { get; set; }

        public int EventId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Location { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Skype { get; set; }

        public ContactType ContactType { get; set; }

        public string Comment { get; set; }
    }
}
