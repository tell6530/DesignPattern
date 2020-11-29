namespace DesignPattern.Decorator
{
    public abstract class ProcessBase : IProcess
    {
        /// <summary>
        /// 儲存被裝飾的物件
        /// </summary>
        protected IProcess _process;

        public abstract void Write(string writePath, string content);

        public virtual void SetDecorated(IProcess process)
        {
            _process = process;
        }
    }
}
