
namespace PsychologyVisitSite.WebUI.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;

    using PsychologyVisitSite.Domain.Abstract;
    using PsychologyVisitSite.Domain.Entities;

    public class RegistrationApiController : ApiController
    {
        private readonly IRegistrationRepository registrationRepository;

        private readonly IRegisterProcessor registerProcessor;

        public RegistrationApiController(IRegistrationRepository registrationRepository, IRegisterProcessor registerProcessor)
        {
            this.registrationRepository = registrationRepository;
            this.registerProcessor = registerProcessor;
        }

        [HttpGet]
        public RegistrationForm LastRegistration()
        {
            var lastRegistration = this.registrationRepository.LastOrDefault();
            return lastRegistration;
        }

        [HttpDelete]
        public void DeleteRegistration(int id)
        {
            this.registrationRepository.Delete(id);
        }

        [HttpGet]
        public IEnumerable<RegistrationForm> Registration(int eventId)
        {
            return this.registrationRepository.FindAll(reg => reg.EventId == eventId).ToArray();
        }

        [HttpGet]
        public IEnumerable<RegistrationForm> Registrations()
        {
            return this.registrationRepository.All().ToArray();
        }

        [HttpPost]
        public RegistrationForm AddRegistrationItem(RegistrationForm registration)
        {
            return this.registerProcessor.ProcessRegistration(registration);
        }

    }
}
