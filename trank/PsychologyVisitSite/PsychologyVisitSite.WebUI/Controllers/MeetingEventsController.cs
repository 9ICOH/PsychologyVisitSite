
namespace PsychologyVisitSite.WebUI.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using PsychologyVisitSite.Domain.Abstract;

    public class MeetingEventsController : Controller
    {
        //private readonly IEventsRepository repository;

        //public MeetingEventsController(IEventsRepository repository)
        //{
        //    this.repository = repository;
        //}

        //public ViewResult EventSummary()
        //{
        //    var lastEvent = this.repository.Events;
        //    return View(lastEvent);
        //}

        //public ViewResult NearMeetingEvent()
        //{
        //    var lastEvent = this.repository.Events.LastOrDefault();
        //    return View(lastEvent);
        //}

        //public FileContentResult GetImage(int id)
        //{
        //    var book = repository.Events.FirstOrDefault(g => g.Id == id);

        //    if (book != null)
        //    {
        //        return File(book.ImageData, book.ImageMimeType);
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}
    }
}