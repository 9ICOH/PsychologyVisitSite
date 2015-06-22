﻿
namespace PsychologyVisitSite.Domain.Abstract
{
    using PsychologyVisitSite.Domain.Entities;

    public interface IRegistrationRepository : IRepository<RegistrationForm>
    {
        int Delete(int id);
    }
}
