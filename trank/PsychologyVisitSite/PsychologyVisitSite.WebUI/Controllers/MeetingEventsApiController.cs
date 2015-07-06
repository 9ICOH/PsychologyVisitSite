
namespace PsychologyVisitSite.WebUI.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;

    using PsychologyVisitSite.Domain.Abstract;
    using PsychologyVisitSite.Domain.Entities;

    public class MeetingEventsApiController : ApiController
    {
        private readonly IEventsRepository eventsRepository;

        public MeetingEventsApiController(IEventsRepository eventsRepository)
        {
            this.eventsRepository = eventsRepository;
        }

        [HttpGet]
        public MeetingEvent NearestEvent()
        {
            var lastEvent = this.eventsRepository.LastOrDefault();
            return lastEvent;
        }

        [HttpGet]
        public IEnumerable<MeetingEvent> AllEvents()
        {
            var events = this.eventsRepository.All().ToArray();
            return events;
        }

        [HttpPost]
        public MeetingEvent AddMeetingEvent(MeetingEvent meetingEvent)
        {
            return this.eventsRepository.Create(meetingEvent);
        }

        [HttpDelete]
        public void DeleteMeetingEvent(int id)
        {
            this.eventsRepository.Delete(id);
        }
    }
}
