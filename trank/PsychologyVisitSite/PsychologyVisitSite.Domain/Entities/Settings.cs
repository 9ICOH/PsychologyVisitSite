
namespace PsychologyVisitSite.Domain.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class Settings
    {
        [Key]
        public int VersionId { get; set; }

        public int LastEventsShowQuantity { get; set; }

    }
}
