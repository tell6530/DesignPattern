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

        public override void Write(string path, byte[] buffer)
        {
            byte[] outputBytes = EncryptData(buffer);
            _process.Write(path, outputBytes);
        }

        public override byte[] Read(string path)
        {
            byte[] encryptBytes = _process.Read(path);
            return DecryptData(encryptBytes);
        }

        private byte[] EncryptData(byte[] data)
        {
            byte[] outputBytes = null;
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (CryptoStream encryptStream = new CryptoStream(memoryStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    MemoryStream inputStream = new MemoryStream(data);
                    inputStream.CopyTo(encryptStream);
                    encryptStream.FlushFinalBlock();
                    outputBytes = memoryStream.ToArray();
                }
            }

            return outputBytes;
        }

        private byte[] DecryptData(byte[] encryptBytes)
        {
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
