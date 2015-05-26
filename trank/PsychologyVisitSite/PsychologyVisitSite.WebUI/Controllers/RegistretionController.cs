using System.Web.Mvc;

namespace PsychologyVisitSite.WebUI.Controllers
{
    using PsychologyVisitSite.Domain.Abstract;
    using PsychologyVisitSite.Domain.Entities;

    public class RegistretionController : Controller
    {
        // GET: Registretion
        private readonly IRegisterProcessor registerProcessor;

        public RegistretionController(IRegisterProcessor registerProcessor)
        {
            this.registerProcessor = registerProcessor;
        }

        [HttpPost]
        public ViewResult Registrate(RegistrationForm registretionForm)
        {
            if (ModelState.IsValid)
            {
                this.registerProcessor.ProcessRegistration(registretionForm);
                return View("Completed");
            }
            else
            {
                return View(registretionForm);
            }
        }
    }
}