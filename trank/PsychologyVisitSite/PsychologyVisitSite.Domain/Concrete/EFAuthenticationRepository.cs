
namespace PsychologyVisitSite.Domain.Concrete
{
    using PsychologyVisitSite.Domain.Abstract;
    using PsychologyVisitSite.Domain.Entities;

    public class EFAuthenticationRepository : EfRepository<EFDbContext, User>, IAuthenticationRepository
    {
        public User GetUser(string email)
        {
            return this.Find(p => string.Compare(p.Email, email, true) == 0);
        }

        public User Login(string email, string password)
        {
            return this.Find(p => string.Compare(p.Email, email, true) == 0 && p.Password == password);
        }
    }
}
