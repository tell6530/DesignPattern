using System.IO;

namespace DesignPattern.Decorator
{
    public class FileProcess : IProcess
    {
        public byte[] Read(string path)
        {
            return File.ReadAllBytes(path);
        }

        public void Write(string writePath, byte[] buffer)
        {
            File.WriteAllBytes(writePath, buffer);
        }
    }
}
