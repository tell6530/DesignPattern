using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPattern.Decorator
{
    public class ZipProcess : ProcessBase
    {
        public string PassWord { get; set; }

        public string ZipFileName { get; set; }

        public override void Write(string writePath, string content)
        {
            _process.Write(writePath, content);

            this.ZipWriter(writePath);
        }

        private void ZipWriter(string writePath)
        {
            var directory = Path.GetDirectoryName(writePath);
            var zipFilePath = Path.Combine(directory, this.ZipFileName);

            using (var fs = new FileStream(zipFilePath, FileMode.OpenOrCreate))
            {
                using (ZipArchive zipArchive = new ZipArchive(fs, ZipArchiveMode.Create))
                {
                    var fileName = Path.GetFileName(writePath);

                    var zipArchiveEntry = zipArchive.CreateEntry(fileName);
                    using (var zipStream = zipArchiveEntry.Open())
                    {
                        byte[] bytes = File.ReadAllBytes(writePath);
                        zipStream.Write(bytes, 0, bytes.Length);

                        zipStream.Close();
                    }
                }
            }
        }

        private string[] ZipReader(string filePath)
        {
            var result = new List<string>();

            using (var fs = new FileStream(filePath, FileMode.Open))
            {
                using (ZipArchive zipArchive = new ZipArchive(fs, ZipArchiveMode.Read))
                {
                    foreach (ZipArchiveEntry zipArchiveEntry in zipArchive.Entries)
                    {
                        var directory = Path.GetDirectoryName(filePath);

                        string tempFilePath = Path.Combine(directory, zipArchiveEntry.FullName);
                        zipArchiveEntry.ExtractToFile(tempFilePath);

                        result.Add(tempFilePath);
                    }
                }
            }

            return result.ToArray();
        }
    }
}
