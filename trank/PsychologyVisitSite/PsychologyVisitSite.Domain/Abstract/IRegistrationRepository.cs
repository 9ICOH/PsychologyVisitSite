
namespace PsychologyVisitSite.Domain.Abstract
{
    using System.Collections.Generic;

    using PsychologyVisitSite.Domain.Entities;

    public interface IRegistrationRepository
    {
        IEnumerable<RegistrationForm> Registrations { get; }

        void Save(RegistrationForm registrationForm);

        RegistrationForm Delete(int id);
    }
}
