
namespace PsychologyVisitSite.Domain.Concrete
{
    using PsychologyVisitSite.Domain.Abstract;
    using PsychologyVisitSite.Domain.Entities;

    public class EFInformationRepository : EfRepository<Information>, IInformationRepository
    {
        public EFInformationRepository(EFDbContext context)
            : base(context, true)
        {
        }

        public int Delete(int id)
        {
            return this.Delete(x => x.VersionId == id);
        }
    }
}
