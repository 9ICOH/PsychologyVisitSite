
namespace PsychologyVisitSite.Domain.Concrete
{
    using PsychologyVisitSite.Domain.Abstract;
    using PsychologyVisitSite.Domain.Entities;

    public class EFSettingsRepository : EfRepository<Settings>, ISettingsRepository
    {
        public EFSettingsRepository(EFDbContext context)
            : base(context)
        {
        }

        public int Delete(int id)
        {
            return this.Delete(x => x.VersionId == id);
        }
    }
}
