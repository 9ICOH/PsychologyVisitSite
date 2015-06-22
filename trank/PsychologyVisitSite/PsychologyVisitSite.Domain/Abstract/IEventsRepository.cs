
namespace PsychologyVisitSite.Domain.Abstract
{
    using PsychologyVisitSite.Domain.Entities;

    public interface IEventsRepository : IRepository<MeetingEvent>
    {
        int Delete(int bookId);
    }
}
