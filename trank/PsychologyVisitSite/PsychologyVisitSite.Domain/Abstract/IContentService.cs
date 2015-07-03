
namespace PsychologyVisitSite.Domain.Abstract
{
    using System.IO;

    public  interface IContentService
    {
        string GenerateContentUrl(string key);

        void GetContentObject(string key);

        void UploadContentObject(Stream objectStream, string key);


    }
}
