
namespace PsychologyVisitSite.Domain.Concrete
{
    using PsychologyVisitSite.Domain.Abstract;
    using PsychologyVisitSite.Domain.Entities;

    public class EFEventsRepository : EfRepository<EFDbContext, MeetingEvent>, IEventsRepository
    {
        public int Delete(int id)
        {
            return this.Delete(x => x.Id == id);
        }
    }
}
