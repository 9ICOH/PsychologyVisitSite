
namespace PsychologyVisitSite.Domain.Concrete
{

    using PsychologyVisitSite.Domain.Abstract;
    using PsychologyVisitSite.Domain.Entities;

    public class EFRoleRepository : EfRepository<EFDbContext, Role>, IRoleRepository
    {
    }
}
