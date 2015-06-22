
namespace PsychologyVisitSite.Domain.Abstract
{
    using PsychologyVisitSite.Domain.Entities;

    public interface ISettingsRepository : IRepository<Settings>
    {
        int Delete(int id);
    }
}
