using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace DesignPattern.Decorator
{
    public class AESCrypProcess : ProcessBase
    {
        private AesCryptoServiceProvider aes;

        public string AESKey { get; set; } = "1776D8E110124E75";
        public string AESIV { get; set; } = "B890E7F6BA01C273";

        public AESCrypProcess()
        {
            aes = new AesCryptoServiceProvider();
            aes.Key = Encoding.UTF8.GetBytes(AESKey);
            aes.IV = Encoding.UTF8.GetBytes(AESIV);
        }

        public override void Write(string path, string content)
        {
            _process.Write(path, content);

            byte[] outputBytes = EncryptData(path);
            File.WriteAllBytes(path, outputBytes);
        }

        private byte[] EncryptData(string writePath)
        {
            byte[] bytes = File.ReadAllBytes(writePath);

            byte[] outputBytes = null;
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (CryptoStream encryptStream = new CryptoStream(memoryStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    MemoryStream inputStream = new MemoryStream(bytes);
                    inputStream.CopyTo(encryptStream);
                    encryptStream.FlushFinalBlock();
                    outputBytes = memoryStream.ToArray();
                }
            }

            return outputBytes;
        }

        private byte[] DecryptData(string readPath)
        {
            byte[] encryptBytes = File.ReadAllBytes(readPath);

            byte[] outputBytes = null;
            using (MemoryStream memoryStream = new MemoryStream(encryptBytes))
            {
                using (CryptoStream decryptStream = new CryptoStream(memoryStream, aes.CreateDecryptor(), CryptoStreamMode.Read))
                {
                    MemoryStream outputStream = new MemoryStream();
                    decryptStream.CopyTo(outputStream);
                    outputBytes = outputStream.ToArray();
                }
            }
            return outputBytes;
        }
    }
}
