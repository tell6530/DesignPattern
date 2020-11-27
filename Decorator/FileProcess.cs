using System.IO;

namespace DesignPattern.Decorator
{
    public class FileProcess : IProcess
    {
        public void Write(string writePath, byte[] buffer)
        {
            File.WriteAllBytes(writePath, buffer);
        }

        public byte[] Read(string path)
        {
            return File.ReadAllBytes(path);
        }
    }
}
