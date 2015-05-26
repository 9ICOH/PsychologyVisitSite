
namespace PsychologyVisitSite.WebUI.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;

    using PsychologyVisitSite.Domain.Abstract;
    using PsychologyVisitSite.Domain.Entities;

    public class WebController : ApiController
    {
        private IRegistrationRepository registrationRepository;
        private readonly IEventsRepository repository;
        private readonly IRegisterProcessor registerProcessor;

        public WebController(IEventsRepository repository, IRegisterProcessor registerProcessor, IRegistrationRepository registrationRepository)
        {
            this.repository = repository;
            this.registerProcessor = registerProcessor;
            this.registrationRepository = registrationRepository;
        }

        [HttpGet]
        public RegistrationForm LastRegistrationForm()
        {
            var lastRegistration = this.registrationRepository.Registrations.LastOrDefault();
            return lastRegistration;
        }

        [HttpGet]
        public IEnumerable<RegistrationForm> RegistrationForms()
        {
            return this.registrationRepository.Registrations;
        }

        [HttpPost]
        public RegistrationForm AddRegistrationItem(RegistrationForm registration)
        {
            return this.registerProcessor.ProcessRegistration(registration);
        }
    }
}
