
namespace PsychologyVisitSite.Domain.Concrete
{
    using PsychologyVisitSite.Domain.Abstract;
    using PsychologyVisitSite.Domain.Entities;

    public class RegisterProcessor : IRegisterProcessor
    {
        private readonly IRegistrationRepository repository;

        public RegisterProcessor(IRegistrationRepository repository)
        {
            this.repository = repository;
        }

        public RegistrationForm ProcessRegistration(RegistrationForm registrationForm)
        {
            this.repository.Create(registrationForm);
            return registrationForm;
        }
    }
}
