
namespace PsychologyVisitSite.WebUI.Controllers
{
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Web.Http;

    using PsychologyVisitSite.Domain.Abstract;
    using PsychologyVisitSite.Domain.Entities;
    using PsychologyVisitSite.WebUI.Infrastructure;

    public class InformationApiController : ApiController
    {
        private readonly ICollector repositoryCollector;

        private readonly IContentService contentService;

        public InformationApiController(ICollector repositoryCollector, IContentService contentService)
        {
            this.repositoryCollector = repositoryCollector;
            this.contentService = contentService;
        }

        [HttpPost]
        public Information AddInformationItem(Information informationItem)
        {
            return this.repositoryCollector.InformationRepository.Create(informationItem);
        }

        [HttpGet]
        public Information LastInformation()
        {
            var lastInformation = this.repositoryCollector.InformationRepository.LastOrDefault();
            return lastInformation;
        }

        [HttpGet]
        public string GetMainImgUrl()
        {
            var inform = this.repositoryCollector.InformationRepository.LastOrDefault();
            return inform != null ? inform.ImageUrl : string.Empty;
           // return string.Empty;
        }

        [HttpPost]
        public async Task<IHttpActionResult> UploadFile()
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

                this.repositoryCollector.InformationRepository.Create(new Information
                                                                          {
                                                                              ImageUrl = this.contentService.GenerateContentUrl(filename)
                                                                          });
            }
            return this.Ok("файлы загружены");
        }
    }
}