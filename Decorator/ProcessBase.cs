namespace DesignPattern.Decorator
{
    public abstract class ProcessBase : IProcess
    {
        /// <summary>
        /// 儲存被裝飾的物件
        /// </summary>
        protected IProcess _process;

        public abstract byte[] Read(string path);

        public abstract void Write(string writePath, byte[] buffer);

        public virtual void SetDecorated(IProcess process)
        {
            _process = process;
        }
    }
}
