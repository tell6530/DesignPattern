namespace DesignPattern.Decorator
{
    public class DecoratorFactory
    {
        IProcess _original;

        public DecoratorFactory(IProcess original)
        {
            _original = original;
        }

        public DecoratorFactory SetProcess(ProcessBase process)
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
