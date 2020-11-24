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

        public override byte[] Read(string path)
        {
            byte[] encryptBytes = _process.Read(path);
            return DecryptData(encryptBytes);
        }

        /// <summary>
        /// 進行解密
        /// </summary>
        /// <param name="encryptBytes"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 裝飾者呼叫方法
        /// </summary>
        /// <param name="path"></param>
        /// <param name="data"></param>
        public override void Write(string path, byte[] data)
        {
            byte[] outputBytes = EncryptData(data);
            _process.Write(path, outputBytes);
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
    }
}
