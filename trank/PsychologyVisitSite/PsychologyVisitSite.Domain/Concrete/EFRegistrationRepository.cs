
namespace PsychologyVisitSite.Domain.Concrete
{
    using PsychologyVisitSite.Domain.Abstract;
    using PsychologyVisitSite.Domain.Entities;

    public class EFRegistrationRepository : EfRepository<RegistrationForm>, IRegistrationRepository
    {

        public EFRegistrationRepository(EFDbContext context)
            : base(context)
        {
        }

        public int Delete(int id)
        {
          return this.Delete(x => x.Id == id);
        }
    }
}
