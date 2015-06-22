
namespace PsychologyVisitSite.Domain.Abstract
{
    using PsychologyVisitSite.Domain.Entities;

    public interface IInformationRepository : IRepository<Information>
    {
        int Delete(int id);
    }
}
