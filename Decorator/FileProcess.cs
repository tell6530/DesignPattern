using System.IO;

namespace DesignPattern.Decorator
{
    public class FileProcess : IProcess
    {
        public void Write(string writePath, string content)
        {
            File.WriteAllText(writePath, content);
        }
    }
}
