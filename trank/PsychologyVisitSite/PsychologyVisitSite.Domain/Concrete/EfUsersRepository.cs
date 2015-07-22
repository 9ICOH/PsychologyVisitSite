
namespace PsychologyVisitSite.Domain.Concrete
{
    using PsychologyVisitSite.Domain.Abstract;
    using PsychologyVisitSite.Domain.Entities;

    public class EfUsersRepository : EfRepository<EFDbContext, User>, IUsersRepository
    {
        public User GetUser(string email)
        {
            return this.Find(p => System.String.Compare(p.Email, email, System.StringComparison.OrdinalIgnoreCase) == 0);
        }

        public User Login(string email, string password)
        {
            return this.Find(p => System.String.Compare(p.Email, email, System.StringComparison.OrdinalIgnoreCase) == 0 && p.Password == password);
        }
    }
}
