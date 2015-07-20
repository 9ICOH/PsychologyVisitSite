
namespace PsychologyVisitSite.WebUI.Authentication
{
    using PsychologyVisitSite.Domain.Entities;

    public interface IUserProvider
    {
        User User { get; set; }
    }
}