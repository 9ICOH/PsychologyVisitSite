
namespace PsychologyVisitSite.Domain.Abstract
{
    using PsychologyVisitSite.Domain.Entities;

    public interface IRegisterProcessor
    {
        RegistrationForm ProcessRegistration(RegistrationForm registrationForm);
    }
}
