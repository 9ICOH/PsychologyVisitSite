
namespace PsychologyVisitSite.WebUI.Infrastructure
{
    using PsychologyVisitSite.Domain.Abstract;

    public interface ICollector
    {
        IEventsRepository EventsRepository { get; }

        IRegistrationRepository RegistrationRepository { get; }

        ISettingsRepository SettingsRepositoryRepository { get; }

        IInformationRepository InformationRepository { get; }
    }
}
