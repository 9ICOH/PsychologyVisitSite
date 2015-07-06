
namespace PsychologyVisitSite.Domain.Service
{
    using System;
    using System.IO;

    using Amazon.S3;
    using Amazon.S3.Model;
    using Amazon.S3.Transfer;

    using PsychologyVisitSite.Domain.Abstract;

    public class AwsContentService : IContentService
    {
        private readonly AwsServiceCredentials credentials;

        public AwsContentService(AwsServiceCredentials credentials)
        {
            this.credentials = credentials;
        }

        public string GenerateContentUrl(string key)
        {
            using (IAmazonS3 client = new AmazonS3Client(this.credentials.SecretAccessKeyId, this.credentials.SecretAccessKey, Amazon.RegionEndpoint.USEast1))
            {
                var request = new GetPreSignedUrlRequest
                                  {
                                      BucketName = this.credentials.BucketName,
                                      Key = key,
                                      Expires = DateTime.Now.AddMinutes(32),
                                      Protocol = Protocol.HTTP
                                  };

                var url = client.GetPreSignedURL(request);
                return url.Replace(this.credentials.BucketName + "." + this.credentials.BucketName, this.credentials.BucketName);
            }
        }


        public void GetContentObject(string key)
        {
            using (IAmazonS3 client = new AmazonS3Client(this.credentials.SecretAccessKeyId, this.credentials.SecretAccessKey, Amazon.RegionEndpoint.USEast1))
            {
                var request = new GetObjectRequest
                {
                    BucketName = this.credentials.BucketName,
                    Key = key
                };

                ////only for test
                using (GetObjectResponse response = client.GetObject(request))
                {
                    var dest = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), key);
                    if (!File.Exists(dest))
                    {
                        response.WriteResponseStreamToFile(dest);
                    }
                }
            }
        }

        public void UploadContentObject(Stream objectStream, string key)
        {
            try
            {
                var client = new AmazonS3Client(this.credentials.SecretAccessKeyId, this.credentials.SecretAccessKey, Amazon.RegionEndpoint.USEast1);

                var fileTransferUtility = new TransferUtility(client);
                var fileTransferUtilityRequest = new TransferUtilityUploadRequest
                {
                    BucketName = this.credentials.BucketName,
                    Key = key,
                    InputStream = objectStream,
                    CannedACL = S3CannedACL.PublicRead,
                    StorageClass = S3StorageClass.ReducedRedundancy,
                };

                fileTransferUtility.Upload(fileTransferUtilityRequest);
            }
            catch (Exception s3Exception)
            {
                var t = s3Exception;
            }
        }
    }
}
