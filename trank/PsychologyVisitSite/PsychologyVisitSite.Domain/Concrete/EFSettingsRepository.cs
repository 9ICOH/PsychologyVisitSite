
namespace PsychologyVisitSite.Domain.Concrete
{
    using PsychologyVisitSite.Domain.Abstract;
    using PsychologyVisitSite.Domain.Entities;

    public class EFSettingsRepository : EfRepository<EFDbContext, Settings>, ISettingsRepository
    {
        public int Delete(int id)
        {
            return this.Delete(x => x.VersionId == id);
        }
    }
}
