
namespace PsychologyVisitSite.Domain.Abstract
{
    using PsychologyVisitSite.Domain.Entities;

    public interface IUsersRepository : IRepository<User>
    {
        User GetUser(string email);

        User Login(string email, string password);
    }
}
