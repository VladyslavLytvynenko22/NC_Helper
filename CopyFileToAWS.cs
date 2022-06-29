using System;
using System.Threading.Tasks;

namespace NC_Helper
{
    public class CopyFileToAWS
    {
        private async Task<bool> CopyFile()
        {
            var filePath = @"C:\Users\Vladyslav\Downloads\Acord-125-126-140-v2014-01.pdf";
            var fileGuid = new Guid("56FD2F34-AB9D-4715-B5A4-A262B1C9725A");
            var fileName = "Acord-125-126-140-v2014-01";
            var fileDate = new DateTime(2014, 01, 01);



            var bytes = System.IO.File.ReadAllBytes(filePath);

            var sampleFile = new Domain.Models.File();

            sampleFile.Id = fileGuid;
            sampleFile.Name = fileName;
            sampleFile.Path = null;
            sampleFile.CreateDate = fileDate;
            sampleFile.ChangeDate = fileDate;
            sampleFile.LastChangeUserId = new Guid("53da90ac-87ba-44d5-a99c-adb6af94b9ea");
            sampleFile.MIME = "application/pdf";
            sampleFile.Type = FileType.OriginalPdfForm;
            sampleFile.Size = bytes.Length;

            var d = await connection.GetAsync<Domain.Models.File>(sampleFile.Id);

            if (d == null)
            {
                await connection.InsertAsync(sampleFile);
            }

            S3FileInfo s3File = new S3FileInfo(_s3Client, ConfigurationHelper.S3SiteInstanceName, sampleFile.Id.ToString().ToLower());

            if (!s3File.Exists)
            {
                using (Stream s3Stream = s3File.Create())
                {
                    using (MemoryStream ms = new MemoryStream(bytes))
                    {
                        if (ms.CanSeek)
                        {
                            ms.Seek(0, SeekOrigin.Begin);
                        }

                        ms.CopyTo(s3Stream);
                    }
                }
            }

            return true;
        }
    }
}
