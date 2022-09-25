namespace DotNetCoreExamples
{
    public abstract class ExampleBase
    {
        protected ExampleBase(IUiOutput output = default)
        {
            Output = output ?? new ConsoleOutput();
        }

        public IUiOutput Output { get; private set; }

        public abstract void Run();
    }
}
