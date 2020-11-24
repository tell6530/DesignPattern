using ICSharpCode.SharpZipLib.Core;
using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPattern.Decorator
{
    public class ZipProcess : ProcessBase
    {
        public string PassWord { get; set; }
        public string FileName { get; set; }

        public override byte[] Read(string path)
        {
            byte[] buffer = _process.Read(path);
            return ZipReader(path, buffer);
        }

        public override void Write(string writePath, byte[] data)
        {
            byte[] buffer = ZipWriter(data);
            _process.Write(writePath, buffer);
        }

        private byte[] ZipWriter(byte[] buffer)
        {
            using (MemoryStream outputMemStream = new MemoryStream())
            using (ZipOutputStream zipStream = new ZipOutputStream(outputMemStream))
            using (MemoryStream memStreamIn = new MemoryStream(buffer))
            {
                //zipStream.SetLevel(9);

                ZipEntry newEntry = new ZipEntry(FileName);
                newEntry.DateTime = DateTime.Now;
                zipStream.Password = PassWord;
                zipStream.PutNextEntry(newEntry);

                StreamUtils.Copy(memStreamIn, zipStream, new byte[4096]);//將zip流搬到memoryStream中
                zipStream.CloseEntry();

                zipStream.IsStreamOwner = false;
                zipStream.Close();

                return outputMemStream.ToArray();
            }
        }

        /// <summary>
        /// 讀取zip檔
        /// </summary>
        /// <param name="buffer">zip檔案byte</param>
        /// <returns></returns>
        private byte[] ZipReader(string filePath, byte[] buffer)
        {
            byte[] zipBuffer = default(byte[]);
            using (MemoryStream memoryStream = new MemoryStream(buffer))
            {
                memoryStream.Seek(0, SeekOrigin.Begin);
                var zip = new ZipFile(memoryStream);
                zip.Password = PassWord;
                using (MemoryStream streamWriter = new MemoryStream())
                {
                    byte[] bufferReader = new byte[4096];
                    var file = zip.GetEntry(FileName); //設置要去得的檔名
                                                       //如果有檔案
                    if (file != null)
                    {
                        var zipStream = zip.GetInputStream(file);
                        StreamUtils.Copy(zipStream, streamWriter, bufferReader);
                        zipBuffer = streamWriter.ToArray();
                    }
                }
            }
            return zipBuffer;
        }
    }
}
