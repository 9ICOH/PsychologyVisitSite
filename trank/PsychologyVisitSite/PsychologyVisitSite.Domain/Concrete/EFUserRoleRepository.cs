
namespace PsychologyVisitSite.Domain.Concrete
{
    using PsychologyVisitSite.Domain.Abstract;
    using PsychologyVisitSite.Domain.Entities;

    public class EFUserRoleRepository : EfRepository<EFDbContext, UserRole>, IUserRoleRepository
    {
    }
}
