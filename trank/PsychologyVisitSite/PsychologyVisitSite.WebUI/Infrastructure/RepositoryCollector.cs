
namespace PsychologyVisitSite.WebUI.Infrastructure
{
    using PsychologyVisitSite.Domain.Abstract;

    public class RepositoryCollector : ICollector
    {
        public RepositoryCollector(
            IEventsRepository eventsRepository, 
            IRegistrationRepository registrationRepository, 
            ISettingsRepository settingsRepositoryRepository, 
            IInformationRepository informationRepository)
        {
            this.EventsRepository = eventsRepository;
            this.RegistrationRepository = registrationRepository;
            this.SettingsRepositoryRepository = settingsRepositoryRepository;
            this.InformationRepository = informationRepository;
        }

        public IEventsRepository EventsRepository { get; private set; }

        public IRegistrationRepository RegistrationRepository { get; private set; }

        public ISettingsRepository SettingsRepositoryRepository { get; private set; }

        public IInformationRepository InformationRepository { get; private set; }
    }
}