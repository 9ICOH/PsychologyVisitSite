
namespace PsychologyVisitSite.WebUI.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;

    using PsychologyVisitSite.Domain.Entities;
    using PsychologyVisitSite.WebUI.Infrastructure;

    public class MeetingEventsApiController : ApiController
    {
        private readonly ICollector repositoryCollector;

        public MeetingEventsApiController(ICollector repositoryCollector)
        {
            this.repositoryCollector = repositoryCollector;
        }

        [HttpGet]
        public MeetingEvent NearestEvent()
        {
            var lastEvent = this.repositoryCollector.EventsRepository.LastOrDefault();
            return lastEvent;
        }

        [HttpGet]
        public IEnumerable<MeetingEvent> AllEvents()
        {
            var events = this.repositoryCollector.EventsRepository.All().ToArray();
            return events;
        }
    }
}
