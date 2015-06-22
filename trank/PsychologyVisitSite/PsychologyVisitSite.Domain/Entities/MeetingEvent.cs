
namespace PsychologyVisitSite.Domain.Entities
{
    using System;
    using PsychologyVisitSite.Domain.Enums;

    public class MeetingEvent
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }

        public decimal Price { get; set; }

        public byte[] ImageData { get; set; }

        public string ImageMimeType { get; set; }

        public DateTime EventDateTime { get; set; }

        public RelevantType NotRelevant { get; set; }

        public int RegisteredPeopleNumber { get; set; }
    }
}
