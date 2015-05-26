
namespace PsychologyVisitSite.Domain.Concrete
{
    using System.Collections.Generic;

    using PsychologyVisitSite.Domain.Abstract;
    using PsychologyVisitSite.Domain.Entities;

    public class EFEventsRepository : IEventsRepository
    {
        private readonly EFDbContext context;

        public EFEventsRepository(EFDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<MeetingEvent> Events
        {
            get { return this.context.MeetingEvents; }
        }

        public void Save(MeetingEvent meetingEvent)
        {
            if (meetingEvent.Id == 0)
                context.MeetingEvents.Add(meetingEvent);
            else
            {
                MeetingEvent dbEntry = context.MeetingEvents.Find(meetingEvent.Id);
                if (dbEntry != null)
                {
                    dbEntry.Name = meetingEvent.Name;
                    dbEntry.Description = meetingEvent.Description;
                    dbEntry.Price = meetingEvent.Price;
                    dbEntry.Category = meetingEvent.Category;
                    dbEntry.ImageData = meetingEvent.ImageData;
                    dbEntry.ImageMimeType = meetingEvent.ImageMimeType;
                    dbEntry.NotRelevant = meetingEvent.NotRelevant;
                    dbEntry.EventDateTime = meetingEvent.EventDateTime;
                    dbEntry.RegisteredPeopleNumber = meetingEvent.RegisteredPeopleNumber;
                }
            }

            context.SaveChanges();
        }

        public MeetingEvent Delete(int id)
        {
            MeetingEvent dbEntry = context.MeetingEvents.Find(id);
            if (dbEntry != null)
            {
                context.MeetingEvents.Remove(dbEntry);
                context.SaveChanges();
            }

            return dbEntry;
        }
    }
}
