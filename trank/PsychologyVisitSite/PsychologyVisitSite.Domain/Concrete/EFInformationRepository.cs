
namespace PsychologyVisitSite.Domain.Concrete
{
    using PsychologyVisitSite.Domain.Abstract;
    using PsychologyVisitSite.Domain.Entities;

    public class EFInformationRepository : EfRepository<EFDbContext, Information>, IInformationRepository
    {
        public int Delete(int id)
        {
            return this.Delete(x => x.VersionId == id);
        }
    }
}
