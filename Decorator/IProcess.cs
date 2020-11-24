namespace DesignPattern.Decorator
{
    public interface IProcess
    {
        byte[] Read(string path);

        void Write(string writePath, byte[] buffer);
    }
}
