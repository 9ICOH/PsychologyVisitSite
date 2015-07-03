
namespace PsychologyVisitSite.Domain.Service
{
    public class AwsServiceCredentials
    {
        public AwsServiceCredentials(string bucketName, string secretAccessKeyId, string secretAccessKey)
        {
            this.BucketName = bucketName;
            this.SecretAccessKeyId = secretAccessKeyId;
            this.SecretAccessKey = secretAccessKey;
        }

        public string BucketName { get; private set; }
        public string SecretAccessKeyId { get; private set; }
        public string SecretAccessKey { get; private set; }
    }
}
