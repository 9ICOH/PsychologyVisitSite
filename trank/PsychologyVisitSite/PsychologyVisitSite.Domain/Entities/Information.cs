
namespace PsychologyVisitSite.Domain.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class Information
    {
        [Key]
        public int VersionId { get; set; }

        public string ContactInformation { get; set; }

        public string SiteName { get; set; }

        public string SiteDescription { get; set; }

        public string ImageUrl { get; set; }
    }
}
