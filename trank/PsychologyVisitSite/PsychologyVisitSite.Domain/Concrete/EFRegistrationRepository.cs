
namespace PsychologyVisitSite.Domain.Concrete
{
    using System.Collections.Generic;

    using PsychologyVisitSite.Domain.Abstract;
    using PsychologyVisitSite.Domain.Entities;

    public class EFRegistrationRepository : IRegistrationRepository
    {
        private readonly EFDbContext context;

        public EFRegistrationRepository(EFDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<RegistrationForm> Registrations { get; private set; }

        public void Save(RegistrationForm registrationForm)
        {
            if (registrationForm.Id == 0)
                context.Registrations.Add(registrationForm);
            else
            {
                RegistrationForm dbEntry = context.Registrations.Find(registrationForm.Id);
                if (dbEntry != null)
                {
                    dbEntry.FirstName = registrationForm.FirstName;
                    dbEntry.LastName = registrationForm.LastName;
                    dbEntry.Location = registrationForm.Location;
                    dbEntry.Skype = registrationForm.Skype;
                    dbEntry.PhoneNumber = registrationForm.PhoneNumber;
                    dbEntry.Email = registrationForm.Email;
                    dbEntry.ContactType = registrationForm.ContactType;
                    dbEntry.Comment = registrationForm.Comment;
                }
            }

            context.SaveChanges();
        }

        public RegistrationForm Delete(int id)
        {
            RegistrationForm dbEntry = context.Registrations.Find(id);
            if (dbEntry != null)
            {
                context.Registrations.Remove(dbEntry);
                context.SaveChanges();
            }

            return dbEntry;
        }
    }
}
