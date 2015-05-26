
namespace PsychologyVisitSite.Domain.Abstract
{
    using System.Collections.Generic;

    using PsychologyVisitSite.Domain.Entities;

    public interface IEventsRepository
    {
        IEnumerable<MeetingEvent> Events { get; }
        void Save(MeetingEvent book);
        MeetingEvent Delete(int bookId);
    }
}
