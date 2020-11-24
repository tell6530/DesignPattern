namespace DesignPattern.Decorator
{
    public class DecorateFactory
    {
        IProcess _original;

        public DecorateFactory(IProcess original)
        {
            _original = original;
        }

        public DecorateFactory SetProcess(ProcessBase process)
        {
            process.SetDecorated(_original);
            _original = process;
            return this;
        }

        public IProcess GetProcess()
        {
            return _original;
        }
    }
}
