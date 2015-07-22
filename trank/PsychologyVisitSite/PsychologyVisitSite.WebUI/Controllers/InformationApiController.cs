
namespace PsychologyVisitSite.WebUI.Controllers
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Web.Http;

    using PsychologyVisitSite.Domain.Abstract;
    using PsychologyVisitSite.Domain.Entities;
    using PsychologyVisitSite.WebUI.Authentication;

    public class InformationApiController : ApiController
    {
        private readonly IInformationRepository informationRepository;

        private readonly IContentService contentService;

        private readonly IAuthentication auth;

        public InformationApiController(IInformationRepository informationRepository, IContentService contentService, IAuthentication auth)
        {
            this.informationRepository = informationRepository;
            this.contentService = contentService;
            this.auth = auth;
        }

        [Authorize]
        [HttpPost]
        public Information AddInformationItem(Information informationItem)
        {
            return this.informationRepository.Create(informationItem);
        }

        [HttpGet]
        public Information LastInformation()
        {
            var lastInformation = this.informationRepository.LastOrDefault();
            return lastInformation;
        }

        [HttpGet]
        public string GetMainImgUrl()
        {
            var inform = this.informationRepository.LastOrDefault();
            return inform != null ? this.contentService.GenerateContentUrl(inform.ImageKey) : string.Empty;
        }

        [HttpGet]
        public IEnumerable<string> GetMainImgUrls()
        {
            var t = ((IUserProvider)auth.CurrentUser.Identity).User;

            var inform = this.informationRepository.All();
            var urls = new List<string>();

            if (inform != null)
            {
                foreach (var information in inform)
                {
                    urls.Add(this.contentService.GenerateContentUrl(information.ImageKey));
                }
            }

            return urls;
        }

        [Authorize]
        [HttpPost]
        public async Task<IHttpActionResult> UploadFiles()
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                return this.BadRequest();
            }

            var provider = new MultipartMemoryStreamProvider();
            await Request.Content.ReadAsMultipartAsync(provider);

            foreach (var file in provider.Contents)
            {
                var filename = file.Headers.ContentDisposition.FileName.Trim('\"');
                var fileStream = await file.ReadAsStreamAsync();
                this.contentService.UploadContentObject(fileStream, filename);

                this.informationRepository.Create(new Information
                {
                    ImageKey = filename
                });
            }
            return this.Ok("файлы загружены");
        }

        protected override void Dispose(bool disposing)
        {
            this.informationRepository.Dispose();

            base.Dispose(disposing);
        }
    }
}