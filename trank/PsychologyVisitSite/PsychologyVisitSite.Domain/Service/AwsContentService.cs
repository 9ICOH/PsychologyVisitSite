
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
                var fileTransferUtility = new TransferUtility(new AmazonS3Client(this.credentials.SecretAccessKeyId, this.credentials.SecretAccessKey, Amazon.RegionEndpoint.USEast1));
                fileTransferUtility.Upload(objectStream, this.credentials.BucketName, key);

                //// 4.Specify advanced settings/options.
                //var fileTransferUtilityRequest = new TransferUtilityUploadRequest
                //{
                //    BucketName = this.bucketName,
                //    FilePath = filePath,
                //    StorageClass = S3StorageClass.ReducedRedundancy,
                //    PartSize = 6291456, // 6 MB.
                //    Key = key,
                //    CannedACL = S3CannedACL.PublicRead
                //};

                //fileTransferUtilityRequest.Metadata.Add("param1", "Value1");
                //fileTransferUtilityRequest.Metadata.Add("param2", "Value2");
                //fileTransferUtility.Upload(fileTransferUtilityRequest);
            }
            catch (AmazonS3Exception s3Exception)
            {
                var t = s3Exception;
            }
        }
    }
}
