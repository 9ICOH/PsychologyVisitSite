
namespace PsychologyVisitSite.WebUI.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;

    using PsychologyVisitSite.Domain.Abstract;
    using PsychologyVisitSite.Domain.Entities;
    using PsychologyVisitSite.WebUI.Infrastructure;

    public class RegistrationApiController : ApiController
    {
        private readonly ICollector repositoryCollector;

        private readonly IRegisterProcessor registerProcessor;

        public RegistrationApiController(ICollector repositoryCollector, IRegisterProcessor registerProcessor)
        {
            this.repositoryCollector = repositoryCollector;
            this.registerProcessor = registerProcessor;
        }

        [HttpGet]
        public RegistrationForm LastRegistration()
        {
            var lastRegistration = this.repositoryCollector.RegistrationRepository.LastOrDefault();
            return lastRegistration;
        }

        [HttpDelete]
        public void DeleteRegistration(int id)
        {
            this.repositoryCollector.RegistrationRepository.Delete(id);
        }

        [HttpGet]
        public IEnumerable<RegistrationForm> Registrations(int eventId)
        {
            return this.repositoryCollector.RegistrationRepository.FindAll(reg => reg.EventId == eventId).ToArray();
        }

        [HttpGet]
        public IEnumerable<RegistrationForm> Registrations()
        {
            return this.repositoryCollector.RegistrationRepository.All().ToArray();
        }

        [HttpPost]
        public RegistrationForm AddRegistrationItem(RegistrationForm registration)
        {
            return this.registerProcessor.ProcessRegistration(registration);
        }

    }
}
