﻿
namespace PsychologyVisitSite.Domain.Concrete
{
    using PsychologyVisitSite.Domain.Abstract;
    using PsychologyVisitSite.Domain.Entities;

    public class EFEventsRepository : EfRepository<MeetingEvent>, IEventsRepository
    {
        public EFEventsRepository(EFDbContext context)
            : base(context)
        {
        }

        public int Delete(int id)
        {
            return this.Delete(x => x.Id == id);
        }
    }
}
