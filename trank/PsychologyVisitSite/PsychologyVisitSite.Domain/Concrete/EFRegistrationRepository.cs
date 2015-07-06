
namespace PsychologyVisitSite.Domain.Concrete
{
    using PsychologyVisitSite.Domain.Abstract;
    using PsychologyVisitSite.Domain.Entities;

    public class EFRegistrationRepository : EfRepository<EFDbContext, RegistrationForm>, IRegistrationRepository
    {
        public int Delete(int id)
        {
            return this.Delete(x => x.Id == id);
        }
    }
}
