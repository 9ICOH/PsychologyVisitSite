
namespace PsychologyVisitSite.WebUI.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Web.Mvc;

    using Moq;

    using Ninject;

    using PsychologyVisitSite.Domain.Abstract;
    using PsychologyVisitSite.Domain.Concrete;
    using PsychologyVisitSite.Domain.Entities;
    using PsychologyVisitSite.Domain.Enums;
    using PsychologyVisitSite.Domain.Service;

    public class NinjectDependencyResolver : IDependencyResolver
    {
        private readonly IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            this.kernel = kernelParam;
            this.AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return this.kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return this.kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            var mockEvents = new Mock<IEventsRepository>();
            mockEvents.Setup(m => m.All()).Returns<List<MeetingEvent>>(list =>
                {
                    list.Add(
                        new MeetingEvent
                            {
                                Id = 1,
                                Name = "Алтарь Афродиты",
                                Price = 300,
                                Category = "Тренинги",
                                Description =
                                    "Цель тренинга Алтарь Афродиты - запустить магический женский процесс, чтобы открыть в себе энергию страсти и чувственности. \r\n"
                                    + "В процессе тренинга, шаг за шагом, создавая Альтарь Афродиты Вы почувствуете, как волны уносят Вас в царство Афродиты - в царство, где Вы подобно Афродите управляете способностью наслаждаться любовью и красотой, сексуальностью и чувственностью. "
                                    + "Алтарь Афродиты - особое место в сердце женщины, забота о котором приводит в действие могущественные силы и пробуждает чувственность. "
                                    + "С Божествами нужно взаимодействовать дабы они откликнулись на Ваши молитвы - с Афродитой нужно особо бережное взаимодействие, исполненное верой в этот сильнейший архетип. "
                                    + "Правильно обустроенный алтарь - залог сильнейшего женского магнетизма, притягивающий мужчин в эротически заряженное поле, усиливающий сексуальный настрой мужского сознания. "
                                    + "Придя на тренинг Алтарь Афродиты, Вы обеспечите себе рост доверия, любви к своему телу, ощутите постепенное уменьшение скованности, почувствуете положительные изменения во время сексуальных отношений, которые станут ярче и глубже.\r\n"
                                    + "Вам будет полезен тренинг Алтарь Афродиты, если Вы:\r\n"
                                    + "- неудовлетворены отношениями с мужчинами\r\n"
                                    + "- не принимаете, не любите свое тело, \r\n"
                                    + "- хотите острее телесно реагировать; \r\n"
                                    + "- чувствуете, что отношения с партнером стали скучными; \r\n"
                                    + "- хотите пробудить умение производить на окружающих положительное впечатление; \r\n"
                                    + "- хотите пробудить свой творческий потенциал;\r\n"
                                    + "- чувствуете недостаток радости и вдохновения; \r\n"
                                    + "- хотите глубже соприкоснутся со своей женской силой; \r\n"
                                    + "- мечтаете быть более уверенной в себе, раскованной и свободной."
                            });
                    list.Add(new MeetingEvent { Id = 2, Name = "Дорогу осилит идущая: семь дорог женственности ", Price = 200, Category = "Тренинги" });
                    list.Add(new MeetingEvent { Id = 3, Name = "Стрела Артемиды", Price = 300, Category = "Мастер-классы" });
                    list.Add(
                new MeetingEvent
                    {
                        Id = 4,
                        Name = "Дочки-матери ",
                        Price = 100,
                        Category = "Тематически встречи",
                        Description = "На встрече Вы научитесь смотреть на свои проблемы более трезво, узнаете, как переоценить себя и наладить отношения с самими дорогими для себя людьми." +
                        "Вам будет полезна эта встреча, если: " +
                        "1) вы - мать и у вас есть конфликты,обиды, недопонимания в отношениях с дочерью;" +
                        "2) вы - дочь, и у вас накопилось много обид, ссор, конфликтов в отношениях с мамой."
                    });

                    return null;
                });

            var mockRegistration = new Mock<IRegistrationRepository>();
            mockRegistration.Setup(m => m.All()).Returns<List<RegistrationForm>>(list =>
                    {
                        list.Add(new RegistrationForm
                            {
                                Id = 1,
                                FirstName = "I",
                                LastName = "Y",
                                Email = "iy@mail.ru",
                                Location = "this",
                                PhoneNumber = "41425",
                                Skype = "iy",
                                Comment = "fdfd",
                                ContactType = ContactType.Email
                            });
                        return null;
                    });

            ///DB Repositories
            var efDbContext = new EFDbContext();
           // this.kernel.Bind<IEventsRepository>().ToConstant(mockEvents.Object).WithConstructorArgument(efDbContext);
            this.kernel.Bind<IEventsRepository>().To<EFEventsRepository>().WithConstructorArgument(efDbContext);
            this.kernel.Bind<IRegistrationRepository>().To<EFRegistrationRepository>().WithConstructorArgument(efDbContext);
            this.kernel.Bind<IRegisterProcessor>().To<RegisterProcessor>().WithConstructorArgument(efDbContext);
            this.kernel.Bind<ISettingsRepository>().To<EFSettingsRepository>().WithConstructorArgument(efDbContext);
            this.kernel.Bind<IInformationRepository>().To<EFInformationRepository>().WithConstructorArgument(efDbContext);
            this.kernel.Bind<ICollector>().To<RepositoryCollector>();

            var credentials = new AwsServiceCredentials("freeimg", "AKIAJEWFJ4CAGVG2VENQ", "R+uqBsWUB+xQ2YirL+RtYX5oP4eD9stc06lEvuYg");
            this.kernel.Bind<IContentService>().To<AwsContentService>().WithConstructorArgument(credentials);
        }
    }
}